﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using Beast.Commands;
using Beast.IO;
using Beast.Net;
using Beast.Security;

namespace Beast
{
	public class Game
	{
		public static Game Current { get; private set; }

		[Import(typeof(IRepository), AllowDefault = true)]
		public IRepository Repository { get; set; }

		[ImportMany(AllowRecomposition = true, RequiredCreationPolicy = CreationPolicy.Shared)]
		private IEnumerable<Lazy<IModule, IModuleMetaData>> LoadedModules { get; set; }

		[ImportMany(typeof(ILogger), AllowRecomposition = true)]
		private IEnumerable<ILogger> Loggers { get; set; }

		public bool IsRunning { get; private set; }
		public GameTime GameTime { get; private set; }
		public World World { get; private set; }

		private readonly GameSettings _settings;
		private readonly GameClock _clock;

		private List<IModule> _modules = new List<IModule>();

		public Game(GameSettings settings)
		{
			_settings = settings;
			_clock = new GameClock();
			GameTime = new GameTime();

			Current = this;
		}

		#region Start and Stop
		public void Start()
		{
			if (IsRunning)
				return;

			// ====================================================================================
			// LOAD MODULES FROM EXTERNAL SOURCES
			// ====================================================================================
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(new AssemblyCatalog(typeof(Game).Assembly));

			if (!string.IsNullOrEmpty(_settings.ModulesDirectory) && Directory.Exists(_settings.ModulesDirectory))
				catalog.Catalogs.Add(new DirectoryCatalog(_settings.ModulesDirectory));

			if (_settings.ModuleTypes != null)
				catalog.Catalogs.Add(new TypeCatalog(_settings.ModuleTypes));

			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);

			// ====================================================================================
			// INITIALIZE LOGGING
			// ====================================================================================
			Log.Initialize(Loggers);

			// ====================================================================================
			// INITIALIZE STARTUP VARIABLES
			// ====================================================================================
			// Signal that the game is running.
			IsRunning = true;

			// ====================================================================================
			// INITIALIZE BASIC SYSTEMS
			// ====================================================================================
			// Data repository
			if (Repository == null)
			{
				var path = _settings.FileRepositoryPath;
				if (string.IsNullOrEmpty(path))
					path = Directory.GetCurrentDirectory();
				Repository = new FileRepository(path);
			}
			Log.Info("Initialized repository {0}", Repository);

			// Crypto services
			Cryptography.Initialize(_settings.CryptoKeyProvider);
			Log.Info("Initialized the cryptography service.");

			// Connection manager
			ConnectionManager.Initialize(_settings.ConnectionTimeout);
			Log.Info("Initialized the connection manager.");

			// Command manager
			CommandManager.Initialize();
			Log.Info("Initialized the command manager.");

			// Game World
			World = new World();
			Log.Info("Initialized the game world.");


			// ====================================================================================
			// INITIALIZE MODULES
			// ====================================================================================
			_modules = LoadedModules.OrderByDescending(m => (int)m.Metadata.Priority).Select(m => m.Value).ToList();
			foreach (var module in _modules)
			{
				module.Initialize();
			}

			// ====================================================================================
			// START THE MAIN GAME LOOP
			// ====================================================================================
			_clock.Start(_settings.GameStepInterval.TotalMilliseconds, Update);
		}

		public void Stop()
		{
			_clock.Stop();
			IsRunning = false;
		}
		#endregion

		#region Update
		public void Update()
		{
			// Update the game time.
			GameTime.Update(_clock.TotalGameTime);

			// Process input from the network.
			ConnectionManager.CheckInput(); // Handle dead connections and new commands.

			// Process module updates.
			foreach (var module in _modules)
			{
				module.Update(GameTime);
			}

			// Process output to clients.
			ConnectionManager.Flush(); // Send all queued output to the connections.
		}
		#endregion

		//#region ExecuteCommand
		//public bool ExecuteCommand(string connectionId, IDictionary<string, object> args, IConnectionFactory connectionFactory)
		//{
		//    var command = new Command(args);
		//    IConnection connection = null;

		//    // If command is auth command then create a new connection.
		//    if (AuthenticationModule.IsAuthenticationCommand(command.Name))
		//    {
		//        connection = ConnectionManager.Create(connectionFactory);
		//    }

		//    if (connection == null)
		//    {
		//        // A connection must exist for the specified connectionId.
		//        connection = ConnectionManager.Find(connectionId);
		//        if (connection == null)
		//        {
		//            return false;
		//        }
		//    }

		//    connection.EnqueueCommand(command);
		//    return true;
		//}
		//#endregion
	}
}