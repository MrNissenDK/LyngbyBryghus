using System.Data.SqlClient;

namespace Duser
{
    public static class Conn
    {
        // Koden kan bruges fridt så længe denne tekst bliver i toppen af filen.
        // Copyright 2016 E-train I/S, Udviklet af Henrik Obsen

        /// <summary>
        /// Metoden indeholder formindelsesindstillinger til databaen
        /// </summary>
        /// <returns>Retunere en MS SQL connection string</returns>
        public static SqlConnection GetCon(string IP, string DB, string USER, string PASS)
        {
            string url = "server=[IP];database=[DB];uid=[USER];pwd=[PASS];MultipleActiveResultSets=True";
            url = url.Replace("[IP]", IP);
            url = url.Replace("[DB]", DB);
            url = url.Replace("[USER]", USER);
            url = url.Replace("[PASS]", PASS);
            SqlConnection con = new SqlConnection(url);
            
            return con;
        }

        /// <summary>
        /// Metoden retunere en åben forbindelse til databasen der er defineret i GetCon()
        /// </summary>
        /// <returns>Retunere en åben forbindelse til databasen</returns>
        public static SqlConnection CreateConnection()
        {
            var cn = GetCon("HOST", "DB", "NAME", "PASS");
            cn.Open();
            return cn;
        }
    }
}


