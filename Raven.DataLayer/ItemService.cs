using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using RavenDBMvc5.Core.Entities;

namespace Raven.DataLayer
{
    public class ItemService : RavenDbService, IItemService
    {
        public ItemService(IDocumentSession documentSession)
            : base(documentSession)
        {

        }

        public Items StoreOrUpdate(Items item)
        {
                var existingItem = DocumentSession.Load<Items>(item.Name);
          if (existingItem != null)
           {
                    existingItem.Name = item.Name;
                    existingItem.Price = item.Price;
                    existingItem.CreationDate = item.CreationDate;
                    existingItem.LastUpdateTime = DateTime.Now;
                
            }
            else
            {
                DocumentSession.Store(item);
            }
            
            DocumentSession.SaveChanges();

            return item;
        }

        public IEnumerable<Items> GetAllItems()
        {
            return DocumentSession.Query<Items>();
        }
    }
}
