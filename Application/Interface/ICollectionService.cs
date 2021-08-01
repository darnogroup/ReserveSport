using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Collection;
using Application.ViewModel.General;
using Application.ViewModel.Request;

namespace Application.Interface
{
    public interface ICollectionService
    {
        Tuple<List<CollectionViewModel>, int, int> GetCollections(string search = "", int page = 1);
        Tuple<List<CollectionViewModel>, int, int> GetTrashCollections(string search = "", int page = 1);
        void Create(CreateCollectionViewModel model);
        Task<List<ItemStateViewModel>> GetStateItems();
        Task<List<ItemCityViewModel>> GetCityItems(int id);
        Task<List<ItemUserViewModel>> GetUserItems();
        Task<List<ItemSportViewModel>> GetSportItem();
        Task<AreaCollectionViewModel> GetCollection(int userId);
        Task<bool> CheckCollection(string name, int state, int city);
        Task<EditCollectionViewModel> GetCollectionById(int id);
        Task<List<int>> SelectedSport(int id);
        void Edit(EditCollectionViewModel model);
        Task<bool> AdminCollection(int id);
        void Remove(int id);
        void Back(int id);
        void Delete(int id);
        void EditFinancial(FinancialViewModel model);
        Task<FinancialViewModel> GetFinancial(int id);
        Task<List<ImageViewModel>> GetImages(int id);
        void AddImage(AddImageViewModel model);
        void RemoveImage(int id);
        Tuple<List<RequestViewModel>, int, int> GetRequestList(string search = "", int page = 1);
        Task<InfoRequestViewModel> GetInfoRequest(int id);
        void Active(int id);
    }
}
