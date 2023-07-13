using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Model
{
    public class Jobs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set;}

        public List<Jobs> GetAll()
        {

        }

        public int Insert(Jobs jobs)
        {

        }

        public int Update(Jobs jobs)
        {

        }

        public int Delete(Jobs jobs)
        {

        }

        public Jobs GetById(int id)
        {

        }
    }
}
