using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcce; 
namespace Dominio
{
    public class Usermodel
    {
        UserDao User = new UserDao();
        public bool LoginUser(string cedula)
        {
            return User.LoginUsu(cedula);
        }
        public bool LoginAdmin(string user, string pass)
        {
            return User.LoginAdmin(user, pass);
        }
    }
}
