using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplikasiKendaraan.Data;
using AplikasiKendaraan.Model;

namespace AplikasiKendaraan.Pages.KendaraanPage
{
    public class EditModel : PageModel
    {
        private readonly AplikasiKendaraan.Data.AplikasiKendaraanContext _context;

        public EditModel(AplikasiKendaraan.Data.AplikasiKendaraanContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KendaraanModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KendaraanModelExists(KendaraanModel.no_register))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KendaraanModelExists(string id)
        {
            return _context.KendaraanModel.Any(e => e.no_register == id);
        }
    }
}
