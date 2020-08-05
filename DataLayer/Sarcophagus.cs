using Recodme.Dxs.DesafioDXS.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.Dxs.DesafioDXS.DataLayer
{
    public class Sarcophagus : NamedEntity, ISarcophagus
    {
        #region properties
        #endregion

        #region relationships
        public virtual IChamber Chamber { get; set; }
        private Guid _chamberId;

        [ForeignKey("Chamber")]
        public Guid ChamberId
        {
            get => _chamberId;
            set
            {
                _chamberId = value;
                RegisterChange();
            }
        }

        #endregion

        #region constructors
        public Sarcophagus(string name, Guid chamberId) : base(name)
        {
            _chamberId = chamberId;
        }

        public Sarcophagus(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, Guid chamberId) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _chamberId = chamberId;
        }
        #endregion
    }
}
