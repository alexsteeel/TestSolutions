using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace DataTransferFromRESTApiToDB
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string StationURL = "http://test.ugmk-trans.com:44000/api/info/station/getall";

        private const string RailwayURL = "http://test.ugmk-trans.com:44000/api/info/railway/getall";

        /// <summary>
        /// Флаг активности загрузчика.
        /// </summary>
        public bool IsLoaderActive { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Команда копирования данных.
        /// </summary>
        public RelayCommand CopyCommand => new RelayCommand(x => CopyDataAsync());

        /// <summary>
        /// Копировать данные из REST API в БД.
        /// </summary>
        public async void CopyDataAsync()
        {
            try
            {
                IsLoaderActive = true;

                await Task.Run(() =>
                {
                    TruncateTables();

                    var restRailwayReader = new RestApiReader<Railway>(RailwayURL);
                    var railways = restRailwayReader.Read();

                    var dbWriterRailway = new DbWriter<Railway>();
                    dbWriterRailway.Write(railways);


                    var restStationReader = new RestApiReader<Station>(StationURL);
                    var stations = restStationReader.Read();                    

                    var dbWriterStation = new DbWriter<Station>();
                    dbWriterStation.Write(stations);
                });

                MessageBox.Show($"Данные успешно переданы.");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"При получении данных возникла ошибка.\r\nПодробный текст ошибки:\r\n{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"При передаче данных возникла ошибка.\r\nПодробный текст ошибки:\r\n{ex.Message}");
            }
            finally
            {
                IsLoaderActive = false;
            }
        }

        /// <summary>
        /// Очистка таблиц перед загрузкой данных.
        /// </summary>
        public void TruncateTables()
        {
            using (UserContext db = new UserContext())
            {
                db.Stations.RemoveRange(db.Stations);
                db.Railways.RemoveRange(db.Railways);
                db.SaveChanges();
            }
        }
    }
}
