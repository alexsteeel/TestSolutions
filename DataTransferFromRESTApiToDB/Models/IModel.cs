using System;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Модель данных.
    /// </summary>
    public interface IModel : IComparable
    {
        int ID { get; set; }
    }
}
