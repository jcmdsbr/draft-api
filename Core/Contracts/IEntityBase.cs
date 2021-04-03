using System;

namespace Core.Contracts
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}