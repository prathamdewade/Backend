using Microsoft.EntityFrameworkCore;
using Stylo_Spin.Models;
using Stylo_Spin.Repository.Defination;

namespace Stylo_Spin.Repository.Implementation
{
    public class SliderRepository : ISliderRepository
    {
        private readonly StylospinContext _db;

        public SliderRepository(StylospinContext db)
        {
            _db = db;
        }

        public async Task<List<TblSlider>> GetAllAsync()
        {
            return await _db.TblSliders.ToListAsync();
        }

        public async Task<TblSlider?> GetByIdAsync(int id)
        {
            return await _db.TblSliders.FindAsync(id);
        }

        public async Task<bool> AddAsync(TblSlider slider)
        {
            await _db.TblSliders.AddAsync(slider);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(TblSlider slider)
        {
            _db.TblSliders.Remove(slider);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
