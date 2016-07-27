using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Libraries
{
    public class Repository
    {
        public T PopulateDbObjectFromWeb<T>(T webObject, T dbObject, string[] allowedProps = null)
        {
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                if ((allowedProps == null || allowedProps.Contains(prop.Name))
                    && prop.CanWrite)
                {
                    prop.SetValue(dbObject, prop.GetValue(webObject));
                }
            }

            return dbObject;
        }
    }
}