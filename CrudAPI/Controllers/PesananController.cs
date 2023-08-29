using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CrudAPI.Models;
using CrudLibrary;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesananController : ControllerBase
    {

        private readonly DbcrudBlazorContext _dbContext;

        public PesananController(DbcrudBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var responseApi = new ResponseAPI<List<PesananDTO>>();
            var listPesananDTO = new List<PesananDTO>();

            try
            {
                foreach (var item in await _dbContext.TblPesanans.Include(d => d.IdMenuMakananNavigation).ToListAsync())
                {
                    listPesananDTO.Add(new PesananDTO
                    {
                        IdPesanan = item.IdPesanan,
                        NoPesanan = item.NoPesanan,
                        TglPesanan = item.TglPesanan,
                        NamaCustomer = item.NamaCustomer,
                        IdMenuMakanan = item.IdMenuMakanan,
                        Jumlah = item.Jumlah,
                        Harga = item.Harga,
                        Total = item.Total,
                        MenuMakananan = new MenuMakananDTO 
                        { 
                         IdMenuMakanan = item.IdMenuMakananNavigation.IdMenuMakanan,
                         Nama = item.IdMenuMakananNavigation.Nama,
                         Harga = item.IdMenuMakananNavigation.Harga
                        }
                    });
                }

                responseApi.IsSuccess = true;
                responseApi.Value = listPesananDTO;
            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Search{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var responseApi = new ResponseAPI<PesananDTO>();
            var PesananDTO = new PesananDTO();

            try
            {

                var dbPesanan = await _dbContext.TblPesanans.FirstOrDefaultAsync(e => e.IdPesanan == id);
                if (dbPesanan == null) 
                {
                    PesananDTO.IdPesanan = dbPesanan.IdPesanan;
                    PesananDTO.NoPesanan = dbPesanan.NoPesanan;
                    PesananDTO.TglPesanan = dbPesanan.TglPesanan;
                    PesananDTO.NamaCustomer = dbPesanan.NamaCustomer;
                    PesananDTO.IdMenuMakanan = dbPesanan.IdMenuMakanan;
                    PesananDTO.Jumlah = dbPesanan.Jumlah;
                    PesananDTO.Harga = dbPesanan.Harga;
                    PesananDTO.Total = dbPesanan.Total;

                    responseApi.IsSuccess = true;
                    responseApi.Value = PesananDTO;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "Not Found";
                }

            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }
            return Ok(responseApi);
        }


        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(PesananDTO pesanan)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbPesanan = new TblPesanan
                {
                    NoPesanan = pesanan.NoPesanan,
                    TglPesanan = pesanan.TglPesanan,
                    NamaCustomer = pesanan.NamaCustomer,
                    IdMenuMakanan = pesanan.IdMenuMakanan,
                    Jumlah = pesanan.Jumlah,
                    Harga = pesanan.Harga,
                    Total = pesanan.Total,
                };

                _dbContext.TblPesanans.Add(dbPesanan);
                await _dbContext.SaveChangesAsync();

                if(dbPesanan.IdPesanan != 0)
                {
                    responseApi.IsSuccess = true;
                    responseApi.Value = dbPesanan.IdPesanan;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "Not Saved";
                }

            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Edit{id}")]
        public async Task<IActionResult> Edit(PesananDTO pesanan, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbPesanan = await _dbContext.TblPesanans.FirstOrDefaultAsync(e => e.IdPesanan == id);

                if (dbPesanan != null)
                {
                    dbPesanan.NoPesanan = pesanan.NoPesanan;
                    dbPesanan.TglPesanan = pesanan.TglPesanan;
                    dbPesanan.NamaCustomer = pesanan.NamaCustomer;
                    dbPesanan.IdMenuMakanan = pesanan.IdMenuMakanan;
                    dbPesanan.Jumlah = pesanan.Jumlah;
                    dbPesanan.Harga = pesanan.Harga;
                    dbPesanan.Total = pesanan.Total;

                    responseApi.IsSuccess = true;
                    responseApi.Value = dbPesanan.IdPesanan;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "Pesanan Not Found";
                }

            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbPesanan = await _dbContext.TblPesanans.FirstOrDefaultAsync(e => e.IdPesanan == id);

                if (dbPesanan != null)
                {
                    _dbContext.TblPesanans.Remove(dbPesanan);
                    await _dbContext.SaveChangesAsync();

                    responseApi.IsSuccess = true;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "Pesanan Not Found";
                }

            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }
            return Ok(responseApi);
        }

    }
}
