using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplikasiKendaraan.Data;
using AplikasiKendaraan.Model;

namespace AplikasiKendaraan.Pages.KendaraanPage
{
    public class CreateModel : PageModel
    {
        private readonly AplikasiKendaraan.Data.AplikasiKendaraanContext _context;

        public CreateModel(AplikasiKendaraan.Data.AplikasiKendaraanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KendaraanModel KendaraanModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {                
                return Page();
            }

            //cek data
            if (KendaraanModelExists(KendaraanModel.no_register))
            {           
                return RedirectToPage("./DataSudahAda");
            }

            _context.KendaraanModel.Add(KendaraanModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        //Untuk Cek Apakah data sudah ada di database
        private bool KendaraanModelExists(string id)
        {
            return _context.KendaraanModel.Any(e => e.no_register == id);
        }
    }
}
