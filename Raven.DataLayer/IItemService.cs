using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenDBMvc5.Core.Entities;

namespace Raven.DataLayer
{
    public interface IItemService
    {

        Items StoreOrUpdate(Items item);
        IEnumerable<Items> GetAllItems();
    }
}
