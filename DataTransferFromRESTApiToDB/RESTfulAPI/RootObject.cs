using System.Collections.Generic;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Служебный класс для конвертации данных из JSON в модель.
    /// </summary>
    /// <typeparam name="T">Тип данных, в который необходимо сконвертировать JSON.</typeparam>
    public class RootObject<T>
    {
        /// <summary>
        /// Коллекция данных.
        /// </summary>
        public List<T> Data { get; set; }
    }
}
