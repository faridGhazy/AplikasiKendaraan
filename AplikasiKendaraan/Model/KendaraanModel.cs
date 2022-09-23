using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplikasiKendaraan.Model
{
    public class KendaraanModel
    {
        [Key]
        [Required(ErrorMessage = "Masukkan No Register")]
        public string no_register { get; set; }
        [Required(ErrorMessage = "Masukkan Nama Pemilik")]
        public string nama { get; set; }        
        public string alamat { get; set; }
        public string merk { get; set; }
        public int tahun { get; set; }
        public int silinder { get; set; }
        public string warna { get; set; }
        public string bahanBakar { get; set; }
    }
}
