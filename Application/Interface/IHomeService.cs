using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Article;
using Application.ViewModel.Home;

namespace Application.Interface
{
    public interface IHomeService
    {
        Task<ShowArticleViewModel> GetById(int id);
        Task<List<ItemCollectionViewModel>> GetCollections(); 
        Tuple<List<ItemCollectionViewModel>,int,int> GetAllCollection(int state = 0, int city = 0, string search = "", int id = 6,int page=1);
        Task<List<ItemArticleViewModel>> GetArticles();
        Tuple<ShowCollectionViewModel,List<SportsCollectionViewModel>> GetCollection(int id);
        Task<List<ItemReserveViewModel>> GetReserveById(int id);
        Task<List<SelectCollectionViewModel>> GetCollectionSelection(int state,int city);
        Task<List<SelectSportViewModel>> GetSports(int id);
        List<ItemTimeViewModel> GetTime();
        Task<List<SelectReserveViewModel>> GetReserveItem(string time,string collection);
    }
}
