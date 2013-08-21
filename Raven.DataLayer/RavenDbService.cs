using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;

namespace Raven.DataLayer
{
    public abstract class RavenDbService
    {
        public IDocumentSession DocumentSession;
        protected RavenDbService(IDocumentSession documentSession)
        {
            DocumentSession = documentSession;
        }

    }
}
