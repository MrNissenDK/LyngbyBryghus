using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using Repos.Models;
using System.Data.SqlClient;

namespace Repos.Factories
{
    public class CustomerFac : AutoFac<Customers>
    {
        public Customers Login(string email, string password)
        {
            string sql = "SELECT * From Users Where Email=@Username AND Password=@Password";
            using (SqlCommand cmd = new SqlCommand(sql, Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Username", email);
                cmd.Parameters.AddWithValue("@Password", password);

                Mapper<Customers> mapper = new Mapper<Customers>();
                SqlDataReader r = cmd.ExecuteReader();
                Customers bruger = new Customers();
                if (r.Read())
                {
                    bruger = mapper.Map(r);
                }
                r.Close();
                cmd.Connection.Close();
                return bruger;
            }
        }
    }
}
