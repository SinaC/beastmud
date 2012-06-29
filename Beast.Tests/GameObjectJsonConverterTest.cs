﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Beast.Tests
{
    
    
    /// <summary>
    ///This is a test class for GameObjectJsonConverterTest and is intended
    ///to contain all GameObjectJsonConverterTest Unit Tests
    ///</summary>
	[TestClass()]
	public class GameObjectJsonConverterTest : TestBase
	{

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		private const string ExpectedJsonFormat = "{0}\"Id\":\"{2}\",\"Name\":\"{3}\",\"Description\":\"{4}\",\"prop1\":{5}{1}";
		private const string Name = "TestObject";
		private const string Desc = "Test object's description...";
		private const int Prop1Value = 25;

		[TestMethod()]
		public void GameObjectJsonSerializationTest()
		{
			var id = Guid.NewGuid().ToString();

			var expectedJson = string.Format(ExpectedJsonFormat, "{","}", id, Name, Desc, Prop1Value);

			var obj = new GameObject
			          	{
			          		Id = id,
			          		Name = Name,
			          		Description = Desc
			          	};
			obj[TestObject.Prop1] = Prop1Value;

			var json = JsonConvert.SerializeObject(obj, new GameObjectJsonConverter());
			TestContext.WriteLine("JSON: {0}", json);

			Assert.AreEqual(json, expectedJson);
		}

		[TestMethod()]
		public void GameObjectJsonDeserializationTest()
		{
			var id = Guid.NewGuid().ToString();

			var json = string.Format(ExpectedJsonFormat, "{", "}", id, Name, Desc, Prop1Value);
			var obj = JsonConvert.DeserializeObject<TestObject>(json, new GameObjectJsonConverter());
			
			TestContext.WriteLine("DESERIALIZED OBJECT JSON: {0}", JsonConvert.SerializeObject(obj, new GameObjectJsonConverter()));

			Assert.IsNotNull(obj);
			Assert.AreEqual(obj.Id, id);
			Assert.AreEqual(obj.Name, Name);
			Assert.AreEqual(obj.Description, Desc);
			Assert.AreEqual(obj[TestObject.Prop1], Prop1Value);
		}

		public class TestObject : GameObject
		{
			public static readonly Property Prop1 = new Property("prop1", typeof(int), 0);
		}
	}
}
