using System;
using System.Collections.Generic;
using System.Text;

namespace DBSerialization
{
    class Document

    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string idType { get; set; }
        public string Annotatoin { get; set; }
        public int idAuthor { get; set; }
        public int idResponseble { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool isActive { get; set; }


    }

}
