using MVCArchitecture.Model;
using MVCArchitecture.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controller
{
    public class CountriesController
    {
        private Countries _countriesModel;
        private CountriesView _countriesView;

        public CountriesController (Countries countriesModel, CountriesView countriesView)
        {
            _countriesModel = countriesModel;
            _countriesView = countriesView;
        }

        public void GetAll()
        {
            var result = _countriesModel.GetAll();
            if (result.Count is 0)
            {
                _countriesView.DataEmpty();
            }
            else
            {
                _countriesView.GetAll(result);
            }
        }

        public void GetById()
        {
            var id = _countriesView.InputById();
            var result = _countriesModel.GetById(id);

            if (result == null)
                _countriesView.DataEmpty();
            else
                _countriesView.GetById(result);
        }

        public void Insert()
        {
            var countries = _countriesView.InsertMenu();

            var result = _countriesModel.Insert(countries);
            switch (result)
            {
                case -1:
                    _countriesView.Error();
                    break;
                case 0:
                    _countriesView.Failure();
                    break;
                default:
                    _countriesView.Success();
                    break;
            }
        }

        public void Update()
        {
            var countries = _countriesView.UpdateMenu();
            var result = _countriesModel.Update(countries);

            switch (result)
            {
                case -1:
                    _countriesView.Error();
                    break;
                case 0:
                    _countriesView.Failure();
                    break;
                default:
                    _countriesView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var countries = _countriesView.DeleteMenu();
            var result = _countriesModel.Delete(countries);

            switch (result)
            {
                case -1:
                    _countriesView.DataEmpty();
                    break;
                case 0:
                    _countriesView.Failure();
                    break;
                default:
                    _countriesView.Success();
                    break;
            }
        }
    }
}
