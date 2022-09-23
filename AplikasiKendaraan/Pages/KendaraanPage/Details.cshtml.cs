using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplikasiKendaraan.Data;
using AplikasiKendaraan.Model;

namespace AplikasiKendaraan.Pages.KendaraanPage
{
    public class DetailsModel : PageModel
    {
        private readonly AplikasiKendaraan.Data.AplikasiKendaraanContext _context;

        public DetailsModel(AplikasiKendaraan.Data.AplikasiKendaraanContext context)
        {
            _context = context;
        }

        public KendaraanModel KendaraanModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KendaraanModel = await _context.KendaraanModel.FirstOrDefaultAsync(m => m.no_register == id);

            if (KendaraanModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
