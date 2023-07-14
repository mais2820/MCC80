﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Model;
using MVCArchitecture.View;

namespace MVCArchitecture.Controller
{
    public class RegionController
    {
        private Region _regionModel;
        private RegionView _regionView;

        public RegionController(Region regionModel, RegionView regionView)
        {
            _regionModel = regionModel;
            _regionView = regionView;
        }

        public void GetAll()
        {
            var result = _regionModel.GetAll();
            if (result.Count is 0)
            {
                _regionView.DataEmpty();
            }
            else
            {
                _regionView.GetAll(result);
            }
        }

        public void GetById()
        {
            int id = _regionView.GetById();
            Region region = _regionModel.GetById(id);

            if (region != null)
            {
                _regionView.GetById(region);
            }
            else
            {
                _regionView.DataEmpty();
            }
        }

        public void Insert()
        {
            var region = _regionView.InsertMenu();

            var result = _regionModel.Insert(region);
            switch (result)
            {
                case -1:
                    _regionView.Error();
                    break;
                case 0:
                    _regionView.Failure();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }

        public void Update()
        {
            var region = _regionView.UpdateMenu();
            var result = _regionModel.Update(region);

            switch (result)
            {
                case -1:
                    _regionView.Error();
                    break;
                case 0:
                    _regionView.Failure();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var region = _regionView.Delete();
            var result = _regionModel.Delete(region);
            switch (result)
            {
                case 0:
                    _regionView.Failure();
                    break;
                case -1:
                    _regionView.Error();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }
    }
}
