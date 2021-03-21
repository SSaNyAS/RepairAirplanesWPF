using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
namespace RepairAirplanesWPF.Extensions
{
    static class PrintExtension
    {
        public async static void PrintData(this ObservableCollection<Person> item, ContentControl sender = null)
        {
            object senderContentSave = null;
            if (sender != null)
            {
                sender.IsEnabled = false;
                senderContentSave = sender.Content;
                sender.Content = "Загрузка";
            }
            await Task.Run(() => {
                Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();

                ex.SheetsInNewWorkbook = 2;
                Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
                //Отключить отображение окон с сообщениями
                ex.DisplayAlerts = false;
                //Получаем первый лист документа (счет начинается с 1)
                Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
                var clients = item;

                if (clients.Count == 0)
                {
                    sheet.Cells[1, 1] = "Пользователи отсутствуют";
                }
                else
                {
                    ShowHeaderData(sheet);

                    var headers = new[] { "Пользователь", "Дата рождения", "Паспорт", "Должность" };
                    //Пример заполнения ячеек
                    for (int i = 1; i < headers.Length + 1; i++)
                    {
                        sheet.Cells[6, i] = headers[i - 1];
                        sheet.Cells[6, i].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        sheet.Cells[6, i].Borders.LineStyle = Excel.XlBordersIndex.xlEdgeBottom;
                    }

                    for (int i = 7; i < clients.Count + 7; i++)
                    {
                        var client = clients[i - 7];
                        string[] row = new[] { client.FIO, client.birthday.ToShortDateString(), client.passport.ToString(), client.Permission_group1.name };
                        for (int j = 1; j < headers.Length + 1; j++)
                        {
                            sheet.Cells[i, j] = row[j - 1];
                        }
                    }
                }
                ex.Visible = true;
            });
            if (sender != null)
            {
                sender.IsEnabled = true;
                sender.Content = senderContentSave;
            }
        }

        private static void ShowHeaderData(Worksheet sheet)
        {
            sheet.Cells[1, 1] = "Бугурусланское летное училище ГА (колледж) - филиал ФГБОУ ВО \"Санкт - Петербургский государственный университет ГА\"";
            sheet.Cells[2, 1] = "Адрес:";
            sheet.Cells[2, 2] = "461632, Оренбургская обл., г.Бугуруслан, ул.Аэродромная, 1.";
            sheet.Cells[3, 1] = "Телефон:";
            sheet.Cells[3, 2] = "+7 (35352) 3-21-12";
            sheet.Cells[4, 1] = "Факс:";
            sheet.Cells[4, 2] = "+7 (35352) 3-21-04";
            sheet.Cells[5, 1] = "E-mail:";
            sheet.Cells[5, 2] = "uobluga@mail.ru";
        }

        public async static void PrintData(this ObservableCollection<Student_pilot> item, ContentControl sender = null)
        {
            object senderContentSave = null;
            if (sender != null)
            {
                sender.IsEnabled = false;
                senderContentSave = sender.Content;
                sender.Content = "Загрузка";
            }
            await Task.Run(() => {
                Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();

                ex.SheetsInNewWorkbook = 2;
                Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
                //Отключить отображение окон с сообщениями
                ex.DisplayAlerts = false;
                //Получаем первый лист документа (счет начинается с 1)
                Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
                var clients = item;

                if (clients.Count == 0)
                {
                    sheet.Cells[1, 1] = "Пользователи отсутствуют";
                }
                else
                {
                    ShowHeaderData(sheet);

                    var headers = new[] { "Студент", "Группа","Паспорт", "Дата рождения", "Дата поступления","Документ об образовании" };
                    //Пример заполнения ячеек
                    for (int i = 1; i < headers.Length + 1; i++)
                    {
                        sheet.Cells[6, i] = headers[i - 1];
                        sheet.Cells[6, i].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        sheet.Cells[6, i].Borders.LineStyle = Excel.XlBordersIndex.xlEdgeBottom;
                    }

                    for (int i = 7; i < clients.Count + 7; i++)
                    {
                        var client = clients[i - 7];
                        string[] row = new[] { client.Pilot.Person.FIO, client.Study_group.name, client.Pilot.Person.passport.ToString(), client.Pilot.Person.birthday.ToShortDateString(), client.start_learning_date.ToShortDateString(), client.eduation_sertificate };
                        for (int j = 1; j < headers.Length + 1; j++)
                        {
                            sheet.Cells[i, j] = row[j - 1];
                        }
                    }
                }
                ex.Visible = true;
            });
            if (sender != null)
            {
                sender.IsEnabled = true;
                sender.Content = senderContentSave;
            }
        }
    }
}
