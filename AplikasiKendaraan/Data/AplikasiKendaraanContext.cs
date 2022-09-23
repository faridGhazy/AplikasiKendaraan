using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplikasiKendaraan.Model;

namespace AplikasiKendaraan.Data
{
    public class AplikasiKendaraanContext : DbContext
    {
        public AplikasiKendaraanContext (DbContextOptions<AplikasiKendaraanContext> options)
            : base(options)
        {
        }

        public DbSet<AplikasiKendaraan.Model.KendaraanModel> KendaraanModel { get; set; }
    }
}
