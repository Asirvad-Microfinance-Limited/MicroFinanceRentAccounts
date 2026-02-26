using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ConnectionHandler
{
   public class MongoDBAccessHelper
    {
        //#region "Constructor"
        //PublicConfigManager appConfiguration = new PublicConfigManager();
        //public MongoDBAccessHelper()
        //{
        //    mongoServerSettings = new MongoServerSettings();
        //    mongoServerSettings.Server = new MongoServerAddress(appConfiguration.getmongoAddress);
        //    mongoServerSettings.ServerSelectionTimeout = new TimeSpan(0,0,20,00);
        //     //"10.192.5.55", 27017
        //     mongoServer = new MongoServer(mongoServerSettings);
        //    mongoDatabase = mongoServer.GetDatabase(appConfiguration.getmongoDbName);
        //}
        //#endregion

        #region "Constructor"
        /// <summary>
        /// Created on : 16-03-2023
        /// Created By : 100367 - Nithin
        /// Description: Get Images From Mongo DB
        /// </summary>
        PublicConfigManager appConfiguration = new PublicConfigManager();
        [Obsolete]
        public MongoDBAccessHelper()
        {
            mongoClient = new MongoClient(appConfiguration.getmongoAddress);
            mongoServer = mongoClient.GetServer();
            mongoDatabase = mongoServer.GetDatabase(appConfiguration.getmongoDbName);
        }
        #endregion

        #region "Properties"
        MongoServerSettings mongoServerSettings;
        MongoClient mongoClient;
        MongoServer mongoServer;
        MongoDatabase mongoDatabase;
        #endregion  

        #region "Methods"
        public void Insert<T>(string collectionName, T value)
        {
            try
            {
                mongoServer.Connect();
                MongoCollection<T> mongoCollection = mongoDatabase.GetCollection<T>(collectionName);
                BsonDocument doc = value.ToBsonDocument();
                mongoCollection.Insert(doc);
            }

            catch
            {
                throw;
            }
            finally
            {
                mongoServer.Disconnect();
            }
        }

        public void Update<T>(string collectionName, T value, string feildName, int id)
        {
            try
            {
                mongoServer.Connect();
                MongoCollection<T> mongoCollection = mongoDatabase.GetCollection<T>(collectionName);
                IMongoQuery Marker = Query.EQ(feildName, id);
                BsonDocument doc = value.ToBsonDocument();
                mongoCollection.Insert(doc);
            }

            catch
            {
                throw;
            }
            finally
            {
                mongoServer.Disconnect();
            }
        }

        //public T Select<T>(string collectionName, string feildName, int id)
        //{
        //    try
        //    {
        //        mongoServer.Connect();
        //        T obj;
        //        //5e2693828c96581f38e9a7a5
        //        //IMongoQuery Marker = Query.EQ(feildName, id);
        //        //obj = mongoDatabase.GetCollection<T>(collectionName).Find(Marker).FirstOrDefault();
        //        ObjectId oid = new ObjectId("5e2693828c96581f38e9a7a5");
        //        IMongoQuery Marker = Query.EQ("_Id", oid);
        //        obj = mongoDatabase.GetCollection<T>(collectionName).Find(Marker).FirstOrDefault();
        //        return obj;
        //    }

        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        mongoServer.Disconnect();
        //    }
        //}

        public T Select<T>(string collectionName, string feildName, string id)
        {
            try
            {
                mongoServer.Connect();
                T obj;
                IMongoQuery Marker = Query.EQ(feildName, id);
              //  obj = mongoDatabase.GetCollection<T>(collectionName).FindOne(Marker);

                obj = mongoDatabase.GetCollection<T>(collectionName).FindOne(Marker);

                //ObjectId oid = new ObjectId("5e2693828c96581f38e9a7a5");
                //var file = mongoDatabase.GridFS.FindOne(Query.EQ("_id", oid));

                //Byte[] data = new Byte[0];
                //collectionName = "VOICES";
                //var collection = mongoDatabase.GetCollection<BsonDocument>(collectionName);
                //var filter = Builders<BsonDocument>.Filter.Eq("_id", "5e2693828c96581f38e9a7a5");
                //var result = collection.Find(Marker).ToList();
                //data = (Byte[])result[0][collectionName];


                return obj;
            }

            catch(Exception ex)
            {
                string a = ex.ToString();
                throw;
            }
            finally
            {
                mongoServer.Disconnect();
            }
        }



        #endregion

        #region Select Multiple
        /// <summary>
        /// API Number : 
        /// Created on : 14-Sep-2020
        /// Created By : 100367
        /// Description: get Multi Images
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        public List<T> SelectMultiple<T>(string collectionName, string feildName, string id)
        {
            try
            {
                mongoServer.Connect();
                List<T> obj;
                IMongoQuery Marker = Query.EQ(feildName, id);

                obj = mongoDatabase.GetCollection<T>(collectionName).Find(Marker).ToList();

                //ObjectId oid = new ObjectId("5e2693828c96581f38e9a7a5");
                //var file = mongoDatabase.GridFS.FindOne(Query.EQ("_id", oid));

                //Byte[] data = new Byte[0];
                //collectionName = "VOICES";
                //var collection = mongoDatabase.GetCollection<BsonDocument>(collectionName);
                //var filter = Builders<BsonDocument>.Filter.Eq("_id", "5e2693828c96581f38e9a7a5");
                //var result = collection.Find(Marker).ToList();
                //data = (Byte[])result[0][collectionName];


                return obj;
            }

            catch (Exception ex)
            {
                string a = ex.ToString();
                throw;
            }
            finally
            {
                mongoServer.Disconnect();
            }
        }
        #endregion
    }
}
