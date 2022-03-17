using loginwpfK020.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginwpfK020.negocio
{
    internal class Loginservice
    // se le conoce como POCO ( PLAIN OLD CLR OBJECT)
    {
        string usernamevalido = " admin";
        string passwordvalido = "nimda";

        public bool Check(string username, string password)
        {
            if (usernamevalido == username &&
                passwordvalido == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  bool checkArchivoTexto(string username, string password)
        {
            LoginDao loginDao = new LoginDao();
            Usuario usuario = loginDao.readFile();
            if (usuario != null)
            {
                if (usuario.Username == username &&
                    usuario.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public bool checkContraBaseDatos( string username, string password)
        {
            Usuariosdao usuariosdao = new Usuariosdao();
            Usuario user = usuariosdao.buscarUsuarioPorUsername(username, password);

            if(user != null)
            {
                Console.WriteLine("usuario" + user.Username + " existe en la base de datos ");
                return true;
            }
            Console.WriteLine("Usuario no existe en la base de datos ");
            return false;
        }
    }
}
