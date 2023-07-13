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
    }
}
