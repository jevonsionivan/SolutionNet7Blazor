using System;
using System.Collections.Generic;

namespace CrudAPI.Models;

public partial class TblMenuMakanan
{
    public int IdMenuMakanan { get; set; }

    public string Nama { get; set; } = null!;

    public decimal Harga { get; set; }

    public virtual ICollection<TblPesanan> TblPesanans { get; set; } = new List<TblPesanan>();
}
