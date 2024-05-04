using Soneta.Autenti.API;
using Soneta.Business;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: Service(typeof(AutentiSessionService), typeof(AutentiSessionService), ServiceScope.Session)]
namespace Soneta.Autenti.API
{
    public class AutentiSessionService
    {
        public Session Session { get; }
        public AutentiSessionService(Session session)
        {
            Session = session;            
        }
    }
}
