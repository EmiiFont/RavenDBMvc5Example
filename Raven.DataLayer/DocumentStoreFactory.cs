using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;

namespace Raven.DataLayer
{
   public class DocumentStoreFactory : IDocumentStoreFactory
   {
       private IDocumentStore _databaseDatabase;
       private readonly string _connectionString;
       public DocumentStoreFactory(string connectionString)
       {
           _connectionString = connectionString;
       }

       public IDocumentStore Get()
       {

           _databaseDatabase = new DocumentStore
                               {
                                   ConnectionStringName = _connectionString
                               }.Initialize();
           return _databaseDatabase;
       }
    }
}
