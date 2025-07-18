using Stylo_Spin.Dtos;
using Stylo_Spin.Models;

namespace Stylo_Spin.Services.Defination
{
    public interface IContactUsService
    {
        Task<TblContactU> CreateAsync(ContactUsDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
