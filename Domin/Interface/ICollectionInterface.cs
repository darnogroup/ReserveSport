using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface ICollectionInterface
    {
        Task<int> GetCollectionId(int id);
        Task<IEnumerable<CollectionModel>> GetRequests();
        Task<IEnumerable<CollectionModel>> GetCollections();
        Task<CollectionModel> GetById(int id);
        Task<IEnumerable<CollectionModel>> GetTrashCollections();
        Task<CollectionModel> GetTrashById(int id);
        Task<CollectionModel> GetProfile(int id);
        void Create(CollectionModel model);
        void Update(CollectionModel model);
        void Delete(CollectionModel model);
        void AddSport(SportCollectionModel model);
        Task<List<SportCollectionModel>> GetByCollectionId(int id);
        Task<bool> CheckCollection(string name, int state, int city);
        void RemoveSport(SportCollectionModel model);
        Task<SportCollectionModel> GetSportCollectionById(int id);
        Task<bool> AdminCollection(int id);
        void CreateFinancial(FinancialModel model);
        void EditFinancial(FinancialModel model);
        void DeleteFinancial(FinancialModel model);
        Task<FinancialModel> GetFinancial(int id);
        Task<IEnumerable<BannerModel>> GetBanner(int id);
        void CreateBanner(BannerModel model);
        Task<BannerModel> GetBannerById(int id);
        void RemoveBanner(BannerModel model);
        Task<IEnumerable<CollectionModel>> GetByQuick(int state, int city);
        Task<List<SportCollectionModel>> GetSportCollections(int collectionId);
        Task<bool> GetCollection(int userId);
        Task<bool> IsExistCollectionByUserId(int userId);
        Task<bool> IsExistCollectionByCityId(int cityId);
        Task<bool> IsExistCollectionByStateId(int stateId);
    }
}