using System.Collections.Generic;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>s
    /// Чтение данных.
    /// </summary>
    public interface IReader<T>
    {
        IList<T> Read();
    }
}
