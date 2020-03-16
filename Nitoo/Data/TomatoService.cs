using MongoDB.Driver;
using MongoDB.Bson;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Nitoo.Data
{
    public class TomatoService
    {
        MongoClient client;
        IMongoDatabase database;
        public IMongoCollection<Tomato> tomato_col;

        public TomatoService()
        {
            client = new MongoClient("mongodb://127.0.0.1:27017");
            database = client.GetDatabase("Nitoo");
            tomato_col = database.GetCollection<Tomato>("Tomato");
        }

        public Tomato[] GetTomatos(int page=0, int page_size=20)
        {
            var ret = tomato_col
                .Find(x => true)
                .SortByDescending(x => x.start_date)
                .Skip(page * page_size)
                .Limit(page_size);

            return ret.ToList().ToArray();
        }
        public Tomato? FindTomato(ObjectId _id)
        {
            return tomato_col.Find(x => x._id == _id).FirstOrDefault();
        }
        public async Task<ReplaceOneResult> AddTomato(Tomato t){
            var ret = await tomato_col.ReplaceOneAsync(
                filter: x=>x._id == t._id,
                options: new ReplaceOptions { IsUpsert = true },
                replacement: t
            );
            return ret;
        }
    }
}
