using System;
using Core.Contracts;

namespace Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        protected EntityBase(int id)
        {
            Id = id;
            CreatedAt =  DateTime.Now;
        }
    }
}