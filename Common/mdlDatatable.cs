using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DataTableParameters
    {
        public List<mdlDataTableColumn> columns { get; set; }
        public int draw { get; set; }
        public int length { get; set; }
        public List<mdlDataOrder> order { get; set; }
        public mdlSearch search { get; set; }
        public int start { get; set; }
    }

    public class mdlSearch
    {
        public bool regex { get; set; }
        public string value { get; set; }
    }

    public class mdlDataTableColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool orderable { get; set; }
        public bool searchable { get; set; }
        public mdlSearch search { get; set; }

    }

    public class mdlDataOrder
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
}
