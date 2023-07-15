using MVCArchitecture.View;
using MVCArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controller
{
    public class EmployeesController
    {
        private Employees _employeesModel;
        private EmployeesView _employeesView;

        public EmployeesController(Employees employeesModel, EmployeesView employeesView)
        {
            _employeesModel = employeesModel;
            _employeesView = employeesView;
        }

        public void GetAll()
        {
            var result = _employeesModel.GetAll();
            if (result.Count is 0)
            {
                _employeesView.DataEmpty();
            }
            else
            {
                _employeesView.GetAll(result);
            }
        }

        public void GetById()
        {
            var id = _employeesView.InputById();
            var result = _employeesModel.GetById(id);

            if (result == null)
                _employeesView.DataEmpty();
            else
                _employeesView.GetById(result);
        }

        public void Insert()
        {
            var employees = _employeesView.InsertMenu();

            var result = _employeesModel.Insert(employees);
            switch (result)
            {
                case -1:
                    _employeesView.Error();
                    break;
                case 0:
                    _employeesView.Failure();
                    break;
                default:
                    _employeesView.Success();
                    break;
            }
        }

        public void Update()
        {
            var employees = _employeesView.UpdateMenu();
            var result = _employeesModel.Update(employees);

            switch (result)
            {
                case -1:
                    _employeesView.Error();
                    break;
                case 0:
                    _employeesView.Failure();
                    break;
                default:
                    _employeesView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var employees = _employeesView.DeleteMenu();
            var result = _employeesModel.Delete(employees);

            switch (result)
            {
                case -1:
                    _employeesView.DataEmpty();
                    break;
                case 0:
                    _employeesView.Failure();
                    break;
                default:
                    _employeesView.Success();
                    break;
            }
        }
    }
}
