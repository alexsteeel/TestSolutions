using System.Collections;
using System.Collections.Generic;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Запись данных.
    /// </summary>
    public interface IWriter<T>
    {
        void Write(IList<T> source);
    }
}
