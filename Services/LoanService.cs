using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteUpFlux.v3.Models;

namespace TesteUpFlux.v3.Services
{
    public class LoanService
    {
        private readonly IMongoCollection<Loan> _loans;

        public LoanService(ILoanDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _loans = database.GetCollection<Loan>(settings.BooksCollectionName);
        }

        public List<Loan> Get() => _loans.Find(loan => true).ToList();

        public Loan Get(string id)
        {
            return _loans.Find<Loan>(loan => loan.User == id).FirstOrDefault();
        }

        public Loan Create(Loan loan)
        {
            _loans.InsertOne(loan);
            return loan;
        }

        public void Update(string id, Loan loanIn) => _loans.ReplaceOne(loan => loan.User == id, loanIn);

        public void Remove(Loan bookIn) => _loans.DeleteOne(loan => loan.User == bookIn.User);

        public void Remove(string id) => _loans.DeleteOne(loan => loan.User == id);
    }
}
