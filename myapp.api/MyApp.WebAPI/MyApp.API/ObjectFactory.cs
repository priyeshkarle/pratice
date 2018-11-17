using MyApp.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MyApp.API.Security;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.API
{
    public static class ObjectFactory
    {
        public static ISecurityManager SecurityManager
        {
            get
            {
                return new SecurityManager();
            }
        }
    }
}
