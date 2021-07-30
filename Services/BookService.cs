using TesteUpFlux.v3.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TesteUpFlux.v3.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> Get() => _books.Find(book => true).ToList();

        //public Book Get(int id) => _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Get(string id)
        {
            try
            {
                int id_number = System.Convert.ToInt32(id);
                return _books.Find<Book>(book => book.Id == id_number).FirstOrDefault();
            }
            catch (System.Exception)
            {
                try
                {
                    return _books.Find<Book>(book => book.Title == id || book.Author == id).FirstOrDefault();
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        
        public void Update(int id, Book bookIn) => _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Book bookIn) => _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(int id) => _books.DeleteOne(book => book.Id == id);
    }
}
