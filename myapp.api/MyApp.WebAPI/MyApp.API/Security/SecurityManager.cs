using MyApp.API.Security.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.API.Security
{
    class SecurityManager : Interfaces.ISecurityManager, IDisposable
    {
        EF.SecurityEF _context = new EF.SecurityEF();

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<string> GetNameByToken(string token)
        {
            return System.Threading.Tasks.Task.Run<string>(async () => {
                var user = _context.GlobalUsers.Where(t => t.Token.ToString() == token).FirstOrDefault();

                if (user != null)
                    return user.Name;
                else
                    return string.Empty;
            });
        }
        
        public Task<string> LogIn(string username, string password)
        {
            return System.Threading.Tasks.Task.Run<string>(async () => {
                var user = _context.GlobalUsers.Where(g => g.Username == username && g.Password == password).FirstOrDefault();

                if (user != null)
                {
                    Guid guid = Guid.NewGuid();

                    user.Token = guid;
                    await _context.SaveChangesAsync();
                    return user.Token.ToString();
                }
                else
                {
                    return string.Empty;
                }
            });
        }

        public Task<GlobalUser> GetUser(string token)
        {
            return System.Threading.Tasks.Task.Run<GlobalUser>(() => {
                var user = _context.GlobalUsers.Where(t => t.Token.ToString() == token).FirstOrDefault();

                if (user != null)
                {
                    return user;
                }
                else return null;
            });
        }
    }
}
