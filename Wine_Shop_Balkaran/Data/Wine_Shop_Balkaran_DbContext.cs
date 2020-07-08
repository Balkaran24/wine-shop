using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wine_Shop_Balkaran.Data
{
    public class Wine_Shop_Balkaran_DbContext: DbContext
    {
        public Wine_Shop_Balkaran_DbContext(DbContextOptions<Wine_Shop_Balkaran_DbContext> options)
            : base(options)
        {
        }

        public DbSet<Bussiness.WineMaster> WineMasters { get; set; }
        public DbSet<Bussiness.RateListMaster> RateListMasters { get; set; }
        public DbSet<Bussiness.CustomerMaster> CustomerMasters { get; set; }
    }
}
