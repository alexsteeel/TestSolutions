using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataToExcelLoader
{
    /// <summary>
    /// Железная дорога.
    /// </summary>
    public class Railway
    {
        public Railway()
        {
            Stations = new List<Station>();
        }

        /// <summary>
        /// Идентификатор дороги.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        /// <summary>
        /// Код дороги.
        /// </summary>
        public short Code { get; set; }

        /// <summary>
        /// Наименование полное.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Наименование сокращенное.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Условный идентификатор страны дороги.
        /// </summary>
        public int CountryID { get; set; }

        /// <summary>
        /// Короткое наименование для телеграфа.
        /// </summary>
        public string TelegraphName { get; set; }

        /// <summary>
        /// Дата создания записи.
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Дата обновления записи.
        /// </summary>
        public DateTime DateUpdate { get; set; }

        /// <summary>
        /// Ж/д станции.
        /// </summary>
        public ICollection<Station> Stations { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
