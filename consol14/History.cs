using System;
using System.Collections.Generic;
using System.Text;

namespace DBSerialization
{
    class History
    {
        public int id { get; set; }
        public string Document { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
