using MyApp.API.Security.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.API.Interfaces
{
    public interface ISecurityManager : IDisposable
    {
        Task<string> LogIn(string username, string password);
        Task<string> GetNameByToken(string token);
        Task<GlobalUser> GetUser(string token);
    }
}
