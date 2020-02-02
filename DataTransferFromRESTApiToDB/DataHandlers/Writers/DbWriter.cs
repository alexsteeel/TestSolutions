using EFBulkInsert;
using System;
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
                try
                {
                    var dbSet = db.Set(typeof(T));

                    db.Configuration.AutoDetectChangesEnabled = false;

                    db.BulkInsert(source.Cast<T>().ToList());
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    db.Configuration.AutoDetectChangesEnabled = true;
                }
            }
        }
    }
}
