using System.Collections.Generic;

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
                dbSet.AddRange(source);

                db.SaveChanges();
            }
        }
    }
}
