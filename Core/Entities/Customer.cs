using System;
using Core.Contracts;

namespace Core.Entities
{
    public class Customer : EntityBase
    {
        public string Document { get; set; }

        public Customer(int id, string document) : base(id)
        {
            Document = document;
        }
    }
}