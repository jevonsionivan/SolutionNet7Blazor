using CrudLibrary;

namespace CrudCMS.Services
{
    public interface IMenuMakananService
    {
        Task<List<MenuMakananDTO>> List();
    }
}
