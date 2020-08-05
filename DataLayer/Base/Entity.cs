using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recodme.Dxs.DesafioDXS.DataLayer
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }

        [Display(Name = "Created")]
        public DateTime CreatedAt { get; private set; }

        [Display(Name = "Updated")]
        public DateTime UpdatedAt { get; private set; }

        private bool _isDeleted;

        [Display(Name = "Deleted")]
        public bool IsDeleted
        {
            get => _isDeleted;
            set
            {
                _isDeleted = value;
                RegisterChange();
            }
        }

        protected void RegisterChange()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        protected Entity() : this(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow, false)
        {

        }

        protected Entity(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }
    }
}
