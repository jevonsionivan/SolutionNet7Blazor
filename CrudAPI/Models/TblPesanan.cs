using System;
using System.Collections.Generic;

namespace CrudAPI.Models;

public partial class TblPesanan
{
    public int IdPesanan { get; set; }

    public string NoPesanan { get; set; } = null!;

    public DateTime TglPesanan { get; set; }

    public string NamaCustomer { get; set; } = null!;

    public int? IdMenuMakanan { get; set; }

    public decimal Jumlah { get; set; }

    public decimal Harga { get; set; }

    public decimal Total { get; set; }

    public virtual TblMenuMakanan? IdMenuMakananNavigation { get; set; }
}
