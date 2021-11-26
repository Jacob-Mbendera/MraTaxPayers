using Microsoft.EntityFrameworkCore;
using MraTaxPayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MraTaxPayers.Data
{
    public class MraTaxpayerDbContext :  DbContext
    {
        public MraTaxpayerDbContext(DbContextOptions options) : base(options){ }
        public DbSet<MraTaxPayer> MraTaxPayers { get; set; }
    }
}
