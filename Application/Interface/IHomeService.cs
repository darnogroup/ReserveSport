using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Home;

namespace Application.Interface
{
    public interface IHomeService
    {
        Task<List<ItemCollectionViewModel>> GetCollections();
        Task<List<ItemArticleViewModel>> GetArticles();
        Tuple<ShowCollectionViewModel,List<SportsCollectionViewModel>> GetCollection(int id);
        Task<List<ItemReserveViewModel>> GetReserveById(int id);
        Task<List<SelectCollectionViewModel>> GetCollectionSelection(int state,int city);
        Task<List<SelectSportViewModel>> GetSports(int id);
        List<ItemTimeViewModel> GetTime();
        Task<List<SelectReserveViewModel>> GetReserveItem(string time,string collection);
    }
}
