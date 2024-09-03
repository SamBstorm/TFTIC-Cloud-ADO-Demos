using System.Data;
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

            #region Démo - ExecuteScalar
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    //connection.ConnectionString = connectionString;

            //    using (SqlCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT TOP(1) first_name FROM student WHERE last_name='Hanks'";
            //        //J'ouvre la connection qu'une fois la commande prête à être exécutée
            //        connection.Open();
            //        string result = (string)command.ExecuteScalar();
            //        Console.WriteLine(result);
            //    }

            //    //Grâce au Dispose()
            //    //connection.Close();
            //} 
            #endregion

            #region Démo - ExecuteReader
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT student_id, last_name, first_name FROM student";
            //        connection.Open();
            //        using (SqlDataReader reader = command.ExecuteReader()) {
            //            Console.WriteLine($"Il y a {reader.VisibleFieldCount} colonnes");
            //            while (reader.Read())
            //            {
            //                var result = new { 
            //                    student_id = (int)reader["student_id"], 
            //                    last_name = reader[1].ToString(),
            //                    first_name = reader[2].ToString()};
            //                Console.WriteLine($"{result.student_id} - {result.first_name} {result.last_name}");
            //            }
            //        }
            //    }
            //}
            #endregion

            #region Démo - SqlDataAdapter (mode déconnecté)
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT student_id, last_name, first_name FROM student";
            //        SqlDataAdapter adapter = new SqlDataAdapter();
            //        adapter.SelectCommand = command;

            //        DataTable table = new DataTable();
            //        adapter.Fill(table);

            //        foreach (DataRow row in table.Rows)
            //        {
            //            var result = new {
            //                student_id = (int)row[table.Columns["student_id"]],
            //                last_name = row[table.Columns[1]].ToString(),
            //                first_name = row["first_name"].ToString()};
            //            Console.WriteLine($"{result.student_id} - {result.first_name} {result.last_name}");
            //        }
            //    }
            //}
            #endregion

            #region Démo - Insert - Update - Delete - With Parameters

            Section nouvelleSection = new Section
            {
                Section_id = 2627,
                Section_name = null,
                Delegate_id = null
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO section VALUES (@Section_id, @Section_name, @Delegate_id)";
                    SqlParameter p1 = new SqlParameter()
                    {
                        ParameterName = nameof(Section.Section_id),
                        Value = nouvelleSection.Section_id
                    };
                    command.Parameters.Add(p1);

                    SqlParameter p2 = command.CreateParameter();
                    p2.ParameterName = nameof(Section.Section_name);
                    p2.Value = (object)nouvelleSection.Section_name ?? DBNull.Value;
                    command.Parameters.Add(p2);

                    command.Parameters.AddWithValue(
                        nameof(Section.Delegate_id), 
                        (object)nouvelleSection.Delegate_id ?? DBNull.Value);

                    connection.Open();
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Sauvegarde bien effectuée");
                    }
                    else
                    {
                        Console.WriteLine("Sauvegarde non-effectuée");
                    }
                }

                #endregion
            }
        }
    }
}
