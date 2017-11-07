using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoggingTest.Data
{
    public class LogRepository
    {


        public void SaveLog(WebLog entity)
        {
            using (var db = new LoggingModel())
            {
                db.WebLogs.Add(entity);
                db.SaveChanges();
            }
        }

    }
}