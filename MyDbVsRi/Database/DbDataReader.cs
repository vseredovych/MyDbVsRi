using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDbVsRi
{
    public class DbDataReader
    {
        public Dictionary<string, List<string>> Dictionary { get; set; }
        public DbDataReader() {
            Dictionary = new Dictionary<string, List<string>>();
        }
        public DbDataReader(Dictionary<string, List<string>> dictionary)
        {
            Dictionary = dictionary;
        }
    }
}
