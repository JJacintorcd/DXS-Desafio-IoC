using Recodme.Dxs.DesafioDXS.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.Dxs.DesafioDXS.DataLayer
{
    public class Chamber : NamedEntity, IChamber
    {
        #region properties
        #endregion

        #region relationships
        public virtual IPyramid Pyramid { get; set; }
        private Guid _pyramidId;

        [ForeignKey("Pyramid")]
        public Guid PyramidId
        {
            get => _pyramidId;
            set
            {
                _pyramidId = value;
                RegisterChange();
            }
        }

        public virtual ICollection<ISarcophagus> Sarcophagi { get; set; }
        #endregion

        #region constructors
        public Chamber(string name, Guid pyramidId) : base(name)
        {
            _pyramidId = pyramidId;
        }

        public Chamber(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, Guid pyramidId) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _pyramidId = pyramidId;
        }
        #endregion
    }
}
