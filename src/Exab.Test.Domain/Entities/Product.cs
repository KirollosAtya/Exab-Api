﻿namespace Exab.Test.Domain.Entities;

public class Product : BaseEntity
{


    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}
