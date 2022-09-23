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
    public class IndexModel : PageModel
    {
        private readonly AplikasiKendaraan.Data.AplikasiKendaraanContext _context;

        public IndexModel(AplikasiKendaraan.Data.AplikasiKendaraanContext context)
        {
            _context = context;
        }

        public IList<KendaraanModel> KendaraanModel { get;set; }

        public async Task OnGetAsync(string SearchNoReg, string namaPemilik)
        {
            var noReg = from b in _context.KendaraanModel
                        orderby b descending
                        select b;

            if (!String.IsNullOrEmpty(SearchNoReg))
            {
                noReg = (IOrderedQueryable<KendaraanModel>)_context.KendaraanModel.Where(s => s.no_register!.Contains(SearchNoReg));                
            } 
            if (!String.IsNullOrEmpty(namaPemilik))
            {
                noReg.Where(s => s.nama!.Contains(namaPemilik));
            }
            if (!String.IsNullOrEmpty(namaPemilik))
            {
                noReg = (IOrderedQueryable<KendaraanModel>)_context.KendaraanModel.Where(s => s.nama!.Contains(namaPemilik));
            }

            

            KendaraanModel = await noReg.ToListAsync();
           /* await nmPemilik.ToListAsync();*/


            /*_context.KendaraanModel*/
        }
    }
}
