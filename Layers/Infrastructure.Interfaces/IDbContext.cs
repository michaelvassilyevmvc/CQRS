﻿using System.Threading;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; }
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
