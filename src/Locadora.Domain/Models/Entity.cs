﻿using System;

namespace Locadora.Domain.Models
{
    public abstract class Entity
    {
      
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
