﻿using DemoAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Data;

public class OrderDbContext : DbContext
{
    /// <summary>    
    /// Gets or sets the orders.    
    /// </summary>    
    /// <value>The orders.</value>  
    public DbSet<Order> Orders { get; set; }

    /// <summary>    
    /// Initializes a new instance of the <see cref="OrderDbContext"/> class.    
    /// </summary>    
    /// <param name="options">The options.</param>    
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) {}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Order>().HasData(
    //        new Order { OrderId = 1, Name = "MSDN Order" },
    //        new Order { OrderId = 2, Name = "Docker Order" },
    //        new Order { OrderId = 3, Name = "EFCore Order" }
    //    );
    //}
}
