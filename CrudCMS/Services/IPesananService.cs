using CrudLibrary;
namespace CrudCMS.Services
{
    public interface IPesananService
    {
        Task<List<PesananDTO>> List();
        Task<PesananDTO> Search(int id);
        Task<int> Save(PesananDTO pesanan);
        Task<int> Edit(PesananDTO pesanan);
        Task<bool> Delete(int id);
    }
}
