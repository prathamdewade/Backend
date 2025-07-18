using Microsoft.EntityFrameworkCore;
using Stylo_Spin.Models;
using Stylo_Spin.Repository.Defination;

namespace Stylo_Spin.Repository.Implementation
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly StylospinContext _db;

        public ContactUsRepository(StylospinContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateAsync(TblContactU contact)
        {
            await _db.TblContactUs.AddAsync(contact);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<TblContactU?> GetByIdAsync(int id)
        {
            return await _db.TblContactUs.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(TblContactU contact)
        {
            _db.TblContactUs.Remove(contact);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
