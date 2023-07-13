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

        }

        public void GetById()
        {

        }

        public void Insert()
        {

        }

        public void Update() 
        { 
        
        }
        public void Delete() 
        { 
        
        }

    }
}
