using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Lection0606
{
    public static class DataAccessLayer
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = @"prserver\SQLEXPRESS",
                UserID = "ispp2112",
                Password = "2112",
                InitialCatalog = "ispp2112",
                TrustServerCertificate = true
            };

            return builder.ConnectionString;
        }

        public static void TestConnection()
        {
            using SqlConnection connection = new(GetConnectionString());
            connection.Open();
            // работа с БД (3 шаг)
            connection.Close(); // Необязательно, если есть using 
        }

        public static void ChangePrice()
        {
            using SqlConnection connection = new(GetConnectionString());
            connection.Open();

            var query = "UPDATE Games SET price = price+1";
            SqlCommand command = new(query, connection);

            command.CommandText = "ShowGames";  //Весь запрос, или имя хранимой процедуры, или имя команды

            command.CommandType = CommandType.StoredProcedure; // Полезно только StoredProcedure

            // Parameters - Это коллекция параметров для запросов или процедур
            command.Parameters.AddWithValue("@maxPrice", 200);

            SqlParameter lastId = new("@id", SqlDbType.Int);
            lastId.Direction = ParameterDirection.Output;

            SqlParameter price = new("@price", SqlDbType.Decimal);

            command.Parameters.Add(lastId); // Без значения 
            command.Parameters.Add(price);
            command.Parameters["@price"].Value = 1200; // Со значением

            int changedRowsCount = command.ExecuteNonQuery();
        }

        public static int AddGameByName(string name)
        {
            using SqlConnection connection = new(GetConnectionString());
            connection.Open();

            var query = "AddGame";
            SqlCommand command = new(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static double GetMaxPrice()
        {
            using SqlConnection connection = new(GetConnectionString());
            connection.Open();

            var query = "SELECT MAX(price) From Games";
            SqlCommand command = new(query, connection);


            var result = command.ExecuteScalar(); // Возвращает object, ExecuteScalar - возвращает значене первой ячейки
            return Convert.ToDouble(result);
        }

        public static void EditGames(ref DataTable table)
        {
            using SqlConnection connection = new(GetConnectionString());
            connection.Open();

            var query = "SELECT * From Games";
            SqlCommand command = new(query, connection);

            using SqlDataAdapter adapter = new(query, connection);
            SqlCommandBuilder builder = new(adapter);
            adapter.Update(table); // отправка изменений в БД

            // обновление данных в таблице (в локальной копии)
            table.Clear();
            adapter.Fill(table); // загрузка данных в table 

        }

        public static DataTable GetGames()
        {
            using SqlConnection connection = new(GetConnectionString());
            connection.Open();

            var query = "SELECT * From Games";
            SqlCommand command = new(query, connection);


            var reader = command.ExecuteReader(); // Объект DataReader используется для построчного чтения данных 
            // в цикле или для загрузки всех строк в DataTable

            // 1
            // имена столбцов
            string columnNames = "";
            for (int i = 0; i < reader.FieldCount; i++)
                columnNames += $"{reader.GetName(i)}; ";
            Console.WriteLine(columnNames);

            // построчное чтение данных
            /* object[] cells = new object[reader.FieldCount];
            while (reader.Read())
            {
                reader.GetValues(cells); // запись значений из ячеек строки в массив 
                foreach (object cell in cells)
                    Console.WriteLine(cell);
                Console.WriteLine();
            } */

            // построчное чтение типизированных данных (Game)
            /* List<Game> games = new();
            while (reader.Read())
            {
                var game = new Game
                {
                    Name = reader["name"].ToString(),
                    Price = Convert.ToDouble(reader["price"])
                };
                games.Add(game);
            }
            foreach (var game in games)
                Console.WriteLine($"{game.Name} - {game.Price}$");
            Console.WriteLine();

            // проверка, что есть строки
            if (reader.HasRows)
                ;

            // проверка на NULL
            if (reader["description"] != DBNull.Value)
                ;
            */

            // получение схемы таблицы
            DataTable scheme = new();
            scheme = reader.GetSchemaTable();

            // reader["имя слолбца"]
            // reader[номер слолбца]
            // reader.GetValue(номер столбца)
            // reader.GetТипДанных(номер столбца)

            // 2
            DataTable table = new();
            table.Load(reader);
            return table;
        }

        public static DataTable GetGamesByPrice(int price)
        {
            using SqlConnection connection = new(GetConnectionString());
            connection.Open();

            var query = "ShowGames";
            SqlCommand command = new(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@maxPrice", price);

            var reader = command.ExecuteReader();
            DataTable table = new();
            table.Load(reader);
            return table;
        }
    }
}
