using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginwpfK020.datos
{
    class Usuariosdao
    {
        private const string Connstring = "server = (localdb)\\MSSQLLocalDB; database=proyectok020;Trusted_Connection=True";
        private const string sqllogin = "select * from Usuarios where username =@nombreusuario";

        public Usuario buscarUsuarioPorUsername(string Username, string Password)
        {
            Usuario user = null;
            using (SqlConnection Connection = new  SqlConnection () )
            {
                Connection.ConnectionString = Connstring;
                Connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = sqllogin;
                command.Connection = Connection;
                SqlParameter usernameParameter = new SqlParameter("@nombreusuario", Username);
                command.Parameters.Add(usernameParameter);
                SqlDataReader dr = command.ExecuteReader();
                Console.WriteLine("se encontraron registros" + dr.HasRows);
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        if (Password == dr.GetString("password"))
                        user = new Usuario();
                        user.Id = dr.GetInt32("id");
                        user.Username = Username;
                        user.Password = dr.GetString("password");
                        user.NombreCompleto = dr.GetString(3);
                        break;

                    }

                }
                return user;

            } 
            
        }
    }
}
