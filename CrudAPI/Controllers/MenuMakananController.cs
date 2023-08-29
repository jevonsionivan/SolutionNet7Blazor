using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CrudAPI.Models;
using CrudLibrary;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuMakananController : ControllerBase
    {
        private readonly DbcrudBlazorContext _dbContext;

        public MenuMakananController(DbcrudBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var responseApi = new ResponseAPI<List<MenuMakananDTO>>();
            var listMenuMakananDTO = new List<MenuMakananDTO>();

            try
            {
                foreach (var item in await _dbContext.TblMenuMakanans.ToListAsync()) 
                {
                    listMenuMakananDTO.Add(new MenuMakananDTO
                    {
                        IdMenuMakanan = item.IdMenuMakanan,
                        Nama = item.Nama,
                        Harga = item.Harga,
                    });
                }

                responseApi.IsSuccess = true;
                responseApi.Value = listMenuMakananDTO;
            }catch(Exception ex) 
            {
                responseApi.IsSuccess=false;
                responseApi.Message = ex.Message;
            }
            return Ok(responseApi);
        }
    }
}
