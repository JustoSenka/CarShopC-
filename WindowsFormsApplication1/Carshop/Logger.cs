using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Carshop
{
    public static class Logger
    {
        public static void LogToFile(string fileName, IList<string> logToAdd)
        {
            if (!System.IO.File.Exists(@fileName))
            {
                System.IO.File.Create(@fileName).Close();
            }

            IList<string> currLog = System.IO.File.ReadAllLines(@fileName).ToList();

            var fullLog = currLog.Concat(logToAdd);

            System.IO.File.WriteAllLines(@fileName, fullLog);
        }
    }
}
