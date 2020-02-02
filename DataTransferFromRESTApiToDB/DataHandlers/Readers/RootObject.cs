using System.Collections.Generic;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Служебный класс для конвертации данных из JSON в модель.
    /// </summary>
    public class RootObject<IModel>
    {
        /// <summary>
        /// Коллекция данных.
        /// </summary>
        public IList<IModel> Data { get; set; }
    }
}
