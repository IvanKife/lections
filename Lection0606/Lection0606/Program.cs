namespace Lection0606
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("database access");
            /* ADO.Net - технология для доступа в БД, предоставляет набор классов и интерфейсов,
             * позволяющие получать и редактировать данные в БД
             * в связанном и автономном режиме */

            /* Провайдер данных обеспечивает соединение с БД
             * MySQL
             * MSSQL
             * PostgreSQL
             * 
             * Есть провайдеры для других источников данных, провайдеры типа ODBC
             */

            /* Подключенный уровень:
             * Требует открытого подключения к БД
             * В названиях класса подключенного уровня обычно отображается название файлов
             * 
             * Отключенный уровень:
             * Позволяет сохранить локальную копию данных из БД в клиентском приложении
             * DataSet - набор объектов DataTable и связи между ними DataRelation
             * 
             * 1. Добавление провайдеров в БД:
             * 1) Создаем статический класс для храниения всей работы с БД
             * 2) Создаем строку подключения
             * 
             * 2. Открытие соединения для работы с БД:
             * 
             * 3. Создание SQL-команды и её выполнение:
             * можно выполнить несколько SQL-команд в одной транзакции
             * используя класс подключенного уровня Transaction
             * 
             * SqlCommand - класс, отправляющий запрос серверу и возвращающий результат
             * Запрос лучше хранить в отдельной переменной query 
             * Получение таблицы или результата запроса
             */

            /* DataAdapter - набор DML-команд и команды SELECT
             * DML-команды на основе команды SELECT
             */

            Console.WriteLine(DataAccessLayer.GetConnectionString());

            // DataAccessLayer.ChangePrice();
            Console.WriteLine(DataAccessLayer.GetMaxPrice());

            Console.WriteLine(DataAccessLayer.GetGames());

            // как отображать данные 
            // DataTable можно указать как источник данных 
            // grid.ItemSource = table.DefaultView;

            Console.WriteLine(DataAccessLayer.AddGameByName("смута4"));
            Console.WriteLine(DataAccessLayer.GetGamesByPrice(700));
        }
    }
}
