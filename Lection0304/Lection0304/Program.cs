using System.IO; // Работа с файлами ^_^

Console.WriteLine("File system");

// Класс Path
var path = Path.Combine(Environment.CurrentDirectory, "asd", "123"); // Путь

// Очень удобно. Запомнить!!!
Console.WriteLine(path);
Console.WriteLine(Path.GetRelativePath(path, Environment.CurrentDirectory));
Console.WriteLine(Path.HasExtension(path));

Console.WriteLine();

// Класс DriveInfo - предоставляет информацию о дисках
// DriveInfo drive = new(path); // Получение информацию об одном диске 

/*var drives = DriveInfo.GetDrives(); // Получить информацию обо всех дисках
foreach (var drive in drives)
{
    Console.WriteLine(drive.Name); // Имя диска
    Console.WriteLine(drive.VolumeLabel); 
    Console.WriteLine(drive.IsReady); // Он работает?
    Console.WriteLine(drive.DriveFormat); // Какой формат
    Console.WriteLine(drive.DriveType); // Тип диска (флешка, SSD, HHD)
    Console.WriteLine(drive.TotalSize);
    Console.WriteLine(drive.AvailableFreeSpace); // Доступное место
    Console.WriteLine();
}*/

// Работа с каталогами или папками
// Класс Directory - содержит набор статических методов для управления каталогом и получением информации

// Общий вид:
// Directory.ИмяМетода(path, параметры);

// Получение пути:
// var path = Environment.CurrentDirectory;
// var path = Path.Combine(...);
// var path = @"C:\Temp\ispp21";

// DirectoryInfo - предоставляет набор методов экземпляров для управления каталогом и свойств для получения информации о каталоге

// Общий вид:
// DirectoryInfo объект = new(path);
// объект.ИмяМетода(параметры)
// объект.ИмяСвойства

// У методов GetDirectories или GetFiles есть дополнительные параметры
// * в шаблоне - любой символ. "Lab*", "*.pdf"

var path1 = @"C:\Temp";
var directories = Directory.GetDirectories(path1, "*",
    SearchOption.AllDirectories);
foreach (var directory in directories)
    Console.WriteLine(directory);

var files = Directory.GetFiles(path1, "*.cs", SearchOption.AllDirectories);
foreach (var file in files)
    Console.WriteLine(file);

// File - представляет набор статических методов для работы с файлами и получении о них информации
// File.ИмяМетода(filename, параметры)

// FileInfo - представляет методы экземпляров для работы с файлами и свойства для получения информации о файле
// FileInfo объект = new(filename)
// объект.ИмяМетода(параметры)
// объект.ИмяСвойства

// Создание - file.Create();
// Удаление - file.Delete();
// Копирование - file.CopyTo("новое имя");
// Проверка существования - fiel.Exists

// Свойства переменной FileInfo
// Name - имя без пути
// Extension - расширение файла
// DirectoryName - полное имя папки
// FullName - полная имя файла (путь+имя+расширение)
// Length - длина (размер файла в байтах)

// Методы класса File для чтения и записи данных:
// Общая форма:
// File.ReadДанные(имя файла) - чтение данных из файла
// File.WriteДанные(имя файла, записываемые данные); - запись данных в файл
// File.AppendДанные(имя файла, дозаписываемые данные); - дозапись данных в конец файла
// Последний параметр методов может записана кодировка - Encoding.Кодировка
// Если файла не существует, то он будет создан

// Виды данных:
// Вместо слова "Данные" из примеров:
// 1) AllBytes - массив байтов
// Пример:
// File.WriteAllBytes(filename, new byte[] {65, 66, 67});
//
// 2) AllLines - массив строк
// Пример дозаписи массива строк:
// File.AppendAllLines(filename, ["hello", "world"]);
//
// 3) AllText - считать весь текст
// Пример чтения всего файла:
// string text = File.ReadAllText(filename);