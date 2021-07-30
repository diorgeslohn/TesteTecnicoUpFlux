using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TesteUpFlux.v3.Models
{
    public class Loan
    {
        public string User { get; set; }

        public DateTime Borrowed { get; set; }

        public DateTime Returned { get; set; }

        private int idBook { get; set; }

    }
}
