using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionAppToTestDocker
{
	public static class Function1
	{
		[FunctionName("func")]
		public static async Task<IActionResult> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "mongotest")] HttpRequest req,
			ILogger log)
		{
			log.LogInformation("Testing seeding database from inside the container.");
			string connectionString = "mongodb://mongodbtest:27017";
			string database = "DockerTestData";
			bool overwriteDatabase = true;
			string result = null;
			ConventionRegistry.Register(nameof(IgnoreIfNullConvention), new ConventionPack { new IgnoreIfNullConvention(true) }, t => true);
			BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
			BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));
			var client = new MongoClient(connectionString);
			var db = client.GetDatabase(database);
			if (db == null || overwriteDatabase)
			{
				if (db != null)
				{
					await client.DropDatabaseAsync(database);
				}
				db = client.GetDatabase(database);
				try
				{
					var objects = new List<TestObject>() {
						new TestObject
						{
							Id = "Id0001",
							Text = "An item added to the database"
						},
						new TestObject
						{
							Id = "Id0002",
							Text = "Another item added to the database"
						}
					};
					var collection = db.GetCollection<TestObject>("testobjects");
					await collection.InsertManyAsync(objects);
				}
				catch (Exception ex)
				{
					result = ex.Message;
				}
			}
			else
			{
				result = "Database exists and cannot be overwritten.";
			}

			return new OkObjectResult(result);
		}

		public class TestObject
		{
			public string Id { get; set; }
			public string Text { get; set; }
		}
	}
}
