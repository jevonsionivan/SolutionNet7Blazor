using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace CrudLibrary
{
    public class PesananDTO
    {
        public int IdPesanan { get; set; }
        
        [Required]
        public string NoPesanan { get; set; } = null!;

        [Required]
        public DateTime TglPesanan { get; set; }

        [Required]
        public string NamaCustomer { get; set; } = null!;

        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "The {0} field is required")]
        public int? IdMenuMakanan { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The {0} field is required")]
        public decimal Jumlah { get; set; }

        [Required]
        public decimal Harga { get; set; }

        [Required]
        public decimal Total { get; set; }

        public MenuMakananDTO? MenuMakananan { get; set; }
    }
}
