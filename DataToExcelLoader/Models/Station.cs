using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataToExcelLoader
{
    /// <summary>
    /// Ж/д станция.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Код станции.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        [ForeignKey("RailwayID")]
        public Railway Railway { get; set; }

        /// <summary>
        /// Идентификатор страны.
        /// </summary>
        public int? CountryID { get; set; }

        /// <summary>
        /// 12-символьное наименование станции.
        /// </summary>
        [MaxLength(12)]
        public string Name12Char { get; set; }

        /// <summary>
        /// 40-символьное наименование станции.
        /// </summary>
        [MaxLength(40)]
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

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }                

            Station otherStation = obj as Station;

            if (otherStation != null)
            {
                return this.Code.CompareTo(otherStation.Code);
            }               
            else
            {
                throw new ArgumentException("Object is not a Station");
            }                
        }
    }
}
