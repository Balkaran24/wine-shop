using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wine_Shop_Balkaran.Bussiness
{
    public class WineMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CustomerMaster> CustomerMasters { get; set; }
    }
}
