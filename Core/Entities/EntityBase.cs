using System;
using Core.Contracts;

namespace Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}