using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteUpFlux.v3.Models
{
    public class Book
    {
        [BsonId]
        public int Id { get; set; }
        //public string Id { get; set; }


        [BsonElement("Name")]
        public string Title { get; set; }

        //[BsonElement("Name")]
        //public string BookName { get; set; }

        //public decimal Price { get; set; }

        //public string Category { get; set; }

        public string Author { get; set; }
    }
}
