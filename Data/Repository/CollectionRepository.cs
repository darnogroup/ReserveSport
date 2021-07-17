using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domin.Entity;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CollectionRepository:ICollectionInterface
    {
        private readonly DataBaseContext _context;

        public CollectionRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CollectionModel>> GetCollections()
        {
            return await _context.Collection.Include(i=>i.City)
                .Include(i=>i.State).ToListAsync();
        }

        public async Task<CollectionModel> GetById(int id)
        {
            return await _context.Collection
                .Include(i=>i.City)
                .Include(i=>i.State)
                .Include(i=>i.User).SingleOrDefaultAsync(s => s.CollectionId == id);
        }

        public async Task<IEnumerable<CollectionModel>> GetTrashCollections()
        {
            return await _context.Collection.Where(w=>w.IsDelete==true).Include(i => i.City)
                .Include(i => i.State).IgnoreQueryFilters()
                .ToListAsync();
        }

        public async Task<CollectionModel> GetTrashById(int id)
        {
            return await _context.Collection.Where(w => w.IsDelete == true).IgnoreQueryFilters()
                .SingleOrDefaultAsync(s => s.CollectionId == id);
        }

        public async Task<CollectionModel> GetProfile(int id)
        {
            return await _context.Collection.Include(i => i.User)
                .Include(t => t.City)
                .Include(r => r.State)
                .SingleOrDefaultAsync(s => s.UserId == id);
        }

        public void Create(CollectionModel model)
        {
            _context.Collection.Add(model);
            Save();
        }

        public void Update(CollectionModel model)
        {
            _context.Update(model);Save();
        }

        public void Delete(CollectionModel model)
        {
            _context.Collection.Remove(model);
            Save();
        }

        public void AddSport(SportCollectionModel model)
        {
            _context.SportCollection.Add(model);
            Save();
        }

        public async Task<List<SportCollectionModel>> GetByCollectionId(int id)
        {
            return await _context.SportCollection.Where(w => w.CollectionId == id).AsNoTracking().ToListAsync();
        }

        public async Task<bool> CheckCollection(string name, int state, int city)
        {
            return await _context.Collection
                .Where(w => w.CollectionName == name && w.CityId == city && w.StateId == state)
                .AnyAsync();
        }

        public void RemoveSport(SportCollectionModel model)
        {
            _context.SportCollection.Remove(model);Save();
        }

        public async Task<SportCollectionModel> GetSportCollectionById(int id)
        {
            return await _context.SportCollection.SingleOrDefaultAsync(s => s.SportId == id);
        }

        public async Task<bool> AdminCollection(int id)
        {
            return await _context.Collection.Where(w => w.UserId == id).AnyAsync();
        }

        public void CreateFinancial(FinancialModel model)
        {
            _context.Financial.Add(model);Save();
        }

        public void EditFinancial(FinancialModel model)
        {
            _context.Update(model);Save();
        }

        public void DeleteFinancial(FinancialModel model)
        {
            _context.Financial.Remove(model);
            Save();
        }

        public async Task<FinancialModel> GetFinancial(int id)
        {
            return await _context.Financial.SingleOrDefaultAsync(s=>s.CollectionId==id);
        }

        public async Task<IEnumerable<BannerModel>> GetBanner(int id)
        {
            return await _context.Banner.Where(w => w.CollectionId == id).ToListAsync();
        }

        public void CreateBanner(BannerModel model)
        {
            _context.Banner.Add(model);Save();
        }

        public async Task<BannerModel> GetBannerById(int id)
        {
            return await _context.Banner.FindAsync(id);
        }

        public void RemoveBanner(BannerModel model)
        {
            _context.Banner.Remove(model);Save();
        }

        public async Task<IEnumerable<CollectionModel>> GetByQuick(int state, int city)
        {
            return await _context.Collection.Where(w => w.StateId == state && w.CityId == city).ToListAsync();
        }
        public async Task<List<SportCollectionModel>> GetSportCollections(int collectionId)
        {
            return await _context.SportCollection.Include(n=> n.Sport).Where(n => n.CollectionId == collectionId).ToListAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}