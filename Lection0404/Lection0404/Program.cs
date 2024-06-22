// Использование COM-библиотеки Microsoft.Office.Interop
// using ПсевдонимБиблиотеки = Microsoft.Office.Interop.Приложение;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

Console.WriteLine("MS Office");

// var app = new Псевдоним.Application();
var wordApp = new Word.Application();
var excelApp = new Excel.Application();

// app.Visible = true;
wordApp.Visible = true;
excelApp.Visible = true;

// Создание книги с заданным количеством листов:
excelApp.SheetsInNewWorkbook = 10;
var workbook = excelApp.Workbooks.Add();
workbook.Worksheets.Add();
workbook.Worksheets.Add(After: workbook.Worksheets[3], Count: 2);
// Переименовать лист
var worksheet = workbook.Worksheets[3];
worksheet.Name = "new name";
// Запись значений в ячейку:
worksheet.Cells[2][5] = 12345; // [column][row]

// app.Коллекция 
// wordApp.Documents
// excelApp.Workbooks

// 1 Создание документа:
// var документ = app.Коллекция.Add();

// 2 Создание документа на основе шаблона:
// object template = имяФайлаШаблона;
// var документ = app.Коллекция.Add(template)

// 3 Открытие документа:
// string filename = имяФайла;
// var документ = app.Коллекция.Open(filename)

var document = wordApp.Documents.Add();


/*
var document2 = wordApp.Documents.Add(Path.Combine(Environment.CurrentDirectory, "template.docx"));
var workbook2 = excelApp.Workbooks.Add(Path.Combine(Environment.CurrentDirectory, "template.xlsx"));

var document3 = wordApp.Documents.Open(Path.Combine(Environment.CurrentDirectory, "template.docx"));
var workbook3 = excelApp.Workbooks.Open(Path.Combine(Environment.CurrentDirectory, "template.xlsx")); */

// 1 Сохранение:
// документ.Save();

// 2 Сохранение с указанным именем:
// object filename = имяФайла;
// документ.SaveAs(filename);

// 3 Сохранение документа в указанном формате:
// документ.SaveAs(filename, Псевдоним.ПеречислениеФормата.Формат);

workbook.Close(false);
excelApp.Quit();
if (workbook != null)
    Marshal.ReleaseComObject(workbook);
if (excelApp != null)
    Marshal.ReleaseComObject(excelApp);
workbook = null;
excelApp = null;
GC.Collect();

var processes = Process.GetProcessesByName("Excel");
foreach (var process in processes)
    process.Kill();