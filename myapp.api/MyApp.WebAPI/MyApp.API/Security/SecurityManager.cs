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

        public string GetNameByToken(string token)
        {
            throw new NotImplementedException();
        }

        public string GetUserIDByToken(string token)
        {
            throw new NotImplementedException();
        }

        public string LogIn(string username, string password)
        {
            var user = _context.GlobalUsers.Where(g => g.Username == username && g.Password == password).FirstOrDefault();

            if (user != null)
            {
                Guid guid = Guid.NewGuid();

                user.Token = guid;
                _context.SaveChanges();
                return user.Token.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
