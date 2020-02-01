using System.Collections.Generic;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Служебный класс для конвертации данных из JSON в модель.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RootObject<T>
    {
        public List<T> Data { get; set; }
    }
}
