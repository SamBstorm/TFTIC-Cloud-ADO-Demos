using System.Data.SqlClient;

namespace Demo_ADO01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Récupérer la ConnectionString dans VS2022
            //Dans explorateur de serveur, retrouver serveur voulu (ou le connecter)
            //Cliquez dessus et choisir propriétés
            //Dans les propriétés copiez "Chaine de connection"
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                Console.WriteLine(connection.State);
                connection.Open();
                Console.WriteLine(connection.State);
                connection.Close();
                Console.WriteLine(connection.State);
            }
        }
    }
}
