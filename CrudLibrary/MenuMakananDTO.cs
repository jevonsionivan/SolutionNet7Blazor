using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudLibrary
{
    public class MenuMakananDTO
    {
        public int IdMenuMakanan { get; set; }

        public string Nama { get; set; } = null!;

        public decimal Harga { get; set; }
    }
}
