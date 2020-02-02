using EFBulkInsert;
using System.Collections.Generic;
using System.Linq;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Запись данных в БД.
    /// </summary>
    public class DbWriter<T> : IWriter<IModel>
    {
        public void Write(IList<IModel> source)
        {
            using (UserContext db = new UserContext())
            {
                var dbSet = db.Set(typeof(T));

                var sourceList = source.Cast<T>().ToList();

                db.BulkInsert(sourceList);               

                db.SaveChanges();
            }
        }
    }
}
