using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Data.Model.Member
{
    public class ZTreeVM
    {
        public double Id { get; set; }

        public int? Pid { get; set; }

        public string Name { get; set; }

        public bool @checked
        {
            get;
            set;
        }
        public bool IsParent { get; set; }

        public bool Open { get; set; }
    }
}
