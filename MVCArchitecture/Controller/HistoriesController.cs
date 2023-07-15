using MVCArchitecture.View;
using MVCArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controller
{
    public class HistoriesController
    {
        private Histories _historiesModel;
        private HistoriesView _historiesView;

        public HistoriesController(Histories historiesModel, HistoriesView historiesView)
        {
            _historiesModel = historiesModel;
            _historiesView = historiesView;
        }

        public void GetAll()
        {
            var result = _historiesModel.GetAll();
            if (result.Count is 0)
            {
                _historiesView.DataEmpty();
            }
            else
            {
                _historiesView.GetAll(result);
            }
        }

        public void GetById()
        {
            var id = _historiesView.InputById();
            var result = _historiesModel.GetById(id);

            if (result == null)
               _historiesView.DataEmpty();
            else
                _historiesView.GetById(result);
        }

        public void Insert()
        {
            var histories = _historiesView.InsertMenu();

            var result = _historiesModel.Insert(histories);
            switch (result)
            {
                case -1:
                    _historiesView.Error();
                    break;
                case 0:
                    _historiesView.Failure();
                    break;
                default:
                    _historiesView.Success();
                    break;
            }
        }

        public void Update()
        {
            var histories = _historiesView.UpdateMenu();
            var result = _historiesModel.Update(histories);

            switch (result)
            {
                case -1:
                    _historiesView.Error();
                    break;
                case 0:
                    _historiesView.Failure();
                    break;
                default:
                    _historiesView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var histories = _historiesView.DeleteMenu();
            var result = _historiesModel.Delete(histories);

            switch (result)
            {
                case -1:
                    _historiesView.DataEmpty();
                    break;
                case 0:
                    _historiesView.Failure();
                    break;
                default:
                    _historiesView.Success();
                    break;
            }
        }
    }
}
