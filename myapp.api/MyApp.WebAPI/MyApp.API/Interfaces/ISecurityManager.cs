using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.API.Interfaces
{
    public interface ISecurityManager
    {
        string LogIn(string username, string password);
        string GetNameByToken(string token);
        string GetUserIDByToken(string token);
    }
}
