using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.State;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class StateService : IStateService
    {
        private readonly IStateInterface _state;

        public StateService(IStateInterface state)
        {
            _state = state;
        }
        public Tuple<List<StateViewModel>, int, int> GetStateList(string search = "", int page = 1)
        {
            var result = _state.GetStates().Result;
            List<StateViewModel> models = new List<StateViewModel>();
            var states = result.Where(w => w.StateName.Contains(search)).OrderByDescending(o => o.StateId).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(states.Count, 10);
            int skip = (page - 1) * 10;
            var StateList = states.Skip(skip).Take(10).ToList();
            foreach (var item in StateList)
            {
                models.Add(new StateViewModel()
                {
                    StateName = item.StateName,
                    StateId = item.StateId
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public Tuple<List<StateViewModel>, int, int> GetStateTrashList(string search = "", int page = 1)
        {
            var result = _state.GetTrashStates().Result;
            List<StateViewModel> models = new List<StateViewModel>();
            var states = result.Where(w => w.StateName.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(states.Count, 10);
            int skip = (page - 1) * 10;
            var StateList = states.Skip(skip).Take(10).ToList();
            foreach (var item in StateList)
            {
                models.Add(new StateViewModel()
                {
                    StateName = item.StateName,
                    StateId = item.StateId
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }

        public async Task<EditStateViewModel> GetStateById(int id)
        {
            var model = await _state.GetStateById(id);
            EditStateViewModel edit = new EditStateViewModel()
            {
                StateId = model.StateId,
                StateName = model.StateName
            };
            return edit;
        }

       

        public void Create(CreateStateViewModel model)
        {
            StateModel state = new StateModel();
            state.StateName = model.StateName;
            _state.Create(state);
        }

        public void Update(EditStateViewModel model)
        {
            var result = _state.GetStateById(model.StateId).Result;
            result.StateName = model.StateName;
            _state.Update(result);
        }

        public void Delete(int id)
        {
            var model = _state.GetStateById(id).Result;
            model.IsDelete = true;
            _state.Update(model);
        }

        public void Back(int id)
        {
            var model = _state.GetDeletedStateById(id).Result;
            model.IsDelete = false;
            _state.Update(model);
        }

        public void Remove(int id)
        {
            var model = _state.GetDeletedStateById(id).Result;
            _state.Delete(model);
        }
    }
}
