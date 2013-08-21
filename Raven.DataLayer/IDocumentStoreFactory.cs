using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;

namespace Raven.DataLayer
{
    public interface IDocumentStoreFactory
    {
        IDocumentStore Get();
        
    }
}
