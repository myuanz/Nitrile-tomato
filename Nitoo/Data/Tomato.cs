using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Nitoo.Data
{
    public enum TomatoState
    {
        待完成,
        已完成,
        已放弃,
    };
    public class Comment{
        public DateTime datetime { get; set; }
        public string content { get; set; }

    }
    public class Tomato
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        public string person { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string target { get; set; }
        public List<Comment> comments { get; set; }
        public TomatoState state { get; set; }

    }
}
