using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wine_Shop_Balkaran.Bussiness
{
    public class CustomerMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public Nullable<int> RateListMasterID { get; set; }
        public Nullable<int> WineMasterID { get; set; }

        public virtual RateListMaster RateListMaster { get; set; }
        public virtual WineMaster WineMaster { get; set; }
    }
}
