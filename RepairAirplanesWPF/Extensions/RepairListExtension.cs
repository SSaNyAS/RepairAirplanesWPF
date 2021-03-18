using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
namespace RepairAirplanesWPF.Extensions
{
    static class RepairListExtension
    {
        
        public static string GetStatus(this Repair_list repair_List)
        {
            var status = "Выполняется";
            for (int i = 0; i < repair_List.Required_repair_work.Count; i++)
            {
                var work = repair_List.Required_repair_work.ElementAt(i);

                if (work.Repair_status.id == 1)
                {
                    return work.Repair_status.name;
                }
            }
            status = "Завершено";
            return status;
        }
        public async static void PrintData(this Repair_list item, ContentControl sender = null)
        {

            object senderContentSave = null;
            if (sender != null)
            {
                sender.IsEnabled = false;
                senderContentSave = sender.Content;
                sender.Content = "Загрузка";
            }
            await Task.Run(() => {
                try
                {
                    Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();

                    ex.SheetsInNewWorkbook = 2;
                    Excel.Workbook workBook = ex.Workbooks.Open($@"{Environment.CurrentDirectory}\акт об оказании услуг.xlsx");
                    //Отключить отображение окон с сообщениями
                    ex.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

                    var workList = item.Required_repair_work;

                    for (int i = 0; i < workList.Count; i++)
                    {
                        var element = workList.ElementAt(i);

                        if (i < workList.Count - 1)
                        {
                            ((Excel.Range)sheet.Rows[13]).Copy();
                            ((Excel.Range)sheet.Rows[14]).Insert(Excel.XlDirection.xlDown, Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                        }
                        sheet.Cells[13 + i, 2] = i + 1;
                        sheet.Cells[13 + i, 4] = element.Repair_work.name;
                        sheet.Cells[13 + i, 21] = element.count;

                    }
                    ex.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Произошла ошибка при формировании документа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            });
            if (sender != null)
            {
                sender.IsEnabled = true;
                sender.Content = senderContentSave;
            }
        }
    }
}
