
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DataToExcelLoader
{
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Команда сохранения данных.
        /// </summary>
        public RelayCommand SaveDataToExcelCommand => new RelayCommand(x => SaveDataToExcel());

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Сохранение данных в excel-файл.
        /// </summary>
        public void SaveDataToExcel()
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    var railways = db.Railways
                        .Select(x =>
                            new
                            {
                                x.Name,
                                LastStation = x.Stations
                                    .OrderBy(s => s.Name)
                                    .FirstOrDefault().Name,
                                OpenStationsCount = x.Stations.Where(s => s.FreightSign).Count(),
                                AllStationsCount = x.Stations.Count()
                            })
                        .ToList();

                    var itogOpenStationsCount = railways.Sum(x => x.OpenStationsCount);
                    var itogAllStationsCount = railways.Sum(x => x.AllStationsCount);

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Лист 1");

                        worksheet.Cells["A1"].Value = "Наименование ж/д дороги";
                        worksheet.Cells["B1"].Value = "Наименование последней обновленной станции";
                        worksheet.Cells["C1"].Value = "Кол-во станций открытых для грузовой работы";
                        worksheet.Cells["D1"].Value = "Общее кол-во станций на дороге";

                        worksheet.Cells["A1:D1"].Style.Font.Bold = true;

                        worksheet.Cells["A2"].LoadFromCollection(railways);

                        var rowCount = railways.Count() + 2;
                        worksheet.Cells[$"B{rowCount}"].Value = "Итого:";
                        worksheet.Cells[$"C{rowCount}"].Value = itogOpenStationsCount;
                        worksheet.Cells[$"D{rowCount}"].Value = itogAllStationsCount;

                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                        worksheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        SaveFileDialog saveFileDialog1 = new SaveFileDialog
                        {
                            Title = "Save Excel sheet",
                            Filter = "Excel files|*.xlsx|All files|*.*",
                            FileName = "ЖД_дороги_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx"
                        };

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                            excelPackage.SaveAs(fi);
                            MessageBox.Show("Данные успешно сохранены!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"При сохранении данных произошла ошибка.\r\nПодробный текст ошибки:\r\n{ex.Message}");
            }
        }


    }
}
