﻿using System;
using System.Collections.Generic;
using Beast.Commands;
using Beast.Mobiles;

namespace Beast.Net
{
	/// <summary>
	/// Represents a connected player or client.
	/// </summary>
	public interface IConnection
	{
		/// <summary>
		/// Gets or sets the unique identifier for the current connection.
		/// </summary>
		string Id { get; set; }

		/// <summary>
		/// Gets or sets the date of the last activity for the current connection.
		/// </summary>
		DateTime LastActivity { get; set; }

		/// <summary>
		/// Gets or sets the user instance associated with the current connection.
		/// </summary>
		object User { get; set; }

		/// <summary>
		/// Gets or sets the character instance associated with the current connection.
		/// </summary>
		Character Character { get; set; }

		/// <summary>
		/// Enqueues the specified command from processing by the game.
		/// </summary>
		/// <param name="command">The command to process.</param>
		void EnqueueCommand(Command command);

		/// <summary>
		/// Dequeues all current queued commands.
		/// </summary>
		/// <returns>An enumerable list of Command instances queued for the current connection.</returns>
		IEnumerable<Command> DequeueCommands();

		/// <summary>
		/// Writes the specified IMessage instances to the current connection output stream.
		/// </summary>
		/// <param name="messages">The messages to send to the client.</param>
		void Write(params IMessage[] messages);

		/// <summary>
		/// Flushes all output to the connected client.
		/// </summary>
		void Flush();

		/// <summary>
		/// Closes or shutdowns the current connection.
		/// </summary>
		void Close();
	}
}
