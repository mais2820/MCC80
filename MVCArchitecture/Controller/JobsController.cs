using MVCArchitecture.Model;
using MVCArchitecture.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controller
{
    public class JobsController
    {
        private Jobs _jobModel;
        private JobsView _jobView;

        public JobsController(Jobs jobModel, JobsView jobView)
        {
            _jobModel = jobModel;
            _jobView = jobView;
        }

        public void GetAll()
        {
            var result = _jobModel.GetAll();
            if (result.Count is 0)
            {
                _jobView.DataEmpty();
            }
            else
            {
                _jobView.GetAll(result);
            }
        }

        public void GetById()
        {
            var id = _jobView.InputById();
            var result = _jobModel.GetById(id);

            if (result == null)
                _jobView.DataEmpty();
            else
                _jobView.GetById(result);
        }

        public void Insert()
        {
            var jobs = _jobView.InsertMenu();

            var result = _jobModel.Insert(jobs);
            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void Update()
        {
            var jobs = _jobView.UpdateMenu();
            var result = _jobModel.Update(jobs);

            switch (result)
            {
                case -1:
                   _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }
        public void Delete() 
        {
            var jobs = _jobView.DeleteMenu();
            var result = _jobModel.Delete(jobs);

            switch (result)
            {
                case -1:
                    _jobView.DataEmpty();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

    }
}
