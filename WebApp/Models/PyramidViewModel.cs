using Recodme.Dxs.DesafioDXS.DataLayer;
using Recodme.Dxs.DesafioDXS.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class PyramidViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BuildingMaterial { get; set; }
        public double Height { get; set; }
        public double Base { get; set; }

        public PyramidViewModel() { }

        public Pyramid ToModel()
        {
            return new Pyramid(Name, BuildingMaterial, Height, Base);
        }

        public Pyramid ToModel(Pyramid model)
        {
            model.Name = Name;
            model.BuildingMaterial = BuildingMaterial;
            model.Height = Height;
            model.Base = Base;

            return model;
        }

        public static PyramidViewModel Parse(Pyramid model)
        {
            return new PyramidViewModel() { Name = model.Name, BuildingMaterial = model.BuildingMaterial, Height = model.Height, Base = model.Base};
        }

        public bool CompareToModel(Pyramid model)
        {
            return Name == model.Name;
        }
    }
}
