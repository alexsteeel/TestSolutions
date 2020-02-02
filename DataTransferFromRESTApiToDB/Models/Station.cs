using System;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Ж/д станция.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Код станции (Первичный ключ).
        /// </summary>
        public int Code { get; set; }
        
        /// <summary>
        /// Идентификатор станции.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Идентификатор отделения дороги.
        /// </summary>
        public int? RailwayDepartmentID { get; set; }

        /// <summary>
        /// Идентификатор дороги.
        /// </summary>
        public int? RailwayID { get; set; }

        /// <summary>
        /// Ж/д дорога.
        /// </summary>
        public Railway Railway { get; set; }

        /// <summary>
        /// Идентификатор страны.
        /// </summary>
        public int? CountryID { get; set; }

        /// <summary>
        /// 12-символьное наименование станции.
        /// </summary>
        public string Name12Char { get; set; }

        /// <summary>
        /// 40-символьное наименование станции.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Признак станции, открытой для грузовой работы.
        /// </summary>
        public bool FreightSign { get; set; }

        /// <summary>
        /// Код станции с контрольным знаком.
        /// </summary>
        public string CodeOSGD { get; set; }

        /// <summary>
        /// Дата создания записи.
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Дата обновления записи.
        /// </summary>
        public DateTime DateUpdate { get; set; }
    }
}
