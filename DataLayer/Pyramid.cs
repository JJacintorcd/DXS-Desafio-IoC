using Recodme.Dxs.DesafioDXS.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Dxs.DesafioDXS.DataLayer
{
    public class Pyramid : NamedEntity, IPyramid
    {
        #region properties
        private string _buildingMaterial;
        public string BuildingMaterial
        {
            get => _buildingMaterial;
            set
            {
                _buildingMaterial = value;
                RegisterChange();
            }
        }

        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                RegisterChange();
            }
        }

        private double _base;
        public double Base
        {
            get => _base;
            set
            {
                _base = value;
                RegisterChange();
            }
        }
        #endregion

        #region relationships
        public virtual ICollection<IChamber> Chambers { get; set; }

        #endregion

        #region constructors
        public Pyramid(string name, string buildingMaterial, double height, double @base) : base(name)
        {
            _buildingMaterial = buildingMaterial;
            _height = height;
            _base = @base;
        }

        public Pyramid(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, string buildingMaterial, double height, double @base) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _buildingMaterial = buildingMaterial;
            _height = height;
            _base = @base;
        }
        #endregion
    }
}
