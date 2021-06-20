using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.City;
using Application.ViewModel.Sport;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class SportService : ISportService
    {
        private readonly ISportInterface _sport;

        public SportService(ISportInterface sport)
        {
            _sport = sport;
        }
        public Tuple<List<SportViewModel>, int, int> GetSports(string search = "", int page = 1)
        {
            var result = _sport.GetSports().Result;
            List<SportViewModel> models = new List<SportViewModel>();
            var cities = result.Where(w => w.SportName.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(cities.Count, 10);
            int skip = (page - 1) * 10;
            var sportList = cities.Skip(skip).Take(10).ToList();
            foreach (var item in sportList)
            {
                models.Add(new SportViewModel()
                {
                    SportName = item.SportName,
                    SportId = item.SportId
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public Tuple<List<SportViewModel>, int, int> GetTrashSports(string search = "", int page = 1)
        {
            var result = _sport.GetTrashSports().Result;
            List<SportViewModel> models = new List<SportViewModel>();
            var cities = result.Where(w => w.SportName.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(cities.Count, 10);
            int skip = (page - 1) * 10;
            var sportList = cities.Skip(skip).Take(10).ToList();
            foreach (var item in sportList)
            {
                models.Add(new SportViewModel()
                {
                    SportName = item.SportName,
                    SportId = item.SportId
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<EditSportViewModel> GetSportById(int id)
        {
            var result = await _sport.GetSportById(id);
            EditSportViewModel edit = new EditSportViewModel();
            edit.SportId = result.SportId;
            edit.SportName = result.SportName;
            edit.SportDescription = edit.SportDescription;
            return edit;
        }

        public void Add(CreateSportViewModel model)
        {
            SportModel sport = new SportModel();
            sport.SportName = model.SportName;
            sport.SportDescription = model.SportDescription;
            _sport.Create(sport);
        }

        public void Edit(EditSportViewModel model)
        {
            var sport = _sport.GetSportById(model.SportId).Result;
            sport.SportName = model.SportName;
            sport.SportDescription = model.SportDescription;
            _sport.Update(sport);
        }

        public void Remove(int id)
        {
            var sport = _sport.GetSportById(id).Result;
            sport.IsDelete = true;
            _sport.Update(sport);
        }

        public void Back(int id)
        {
            var sport = _sport.GetDeletedSportById(id).Result;
            sport.IsDelete = false;
            _sport.Update(sport);
        }

        public void Delete(int id)
        {
            var sport = _sport.GetDeletedSportById(id).Result;
            _sport.Delete(sport);
        }
    }
}
