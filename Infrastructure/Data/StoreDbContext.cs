using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;

namespace Skinet.Infrastructure.Data;

public class StoreDbContext(DbContextOptions<StoreDbContext> opt) : DbContext(opt)
{
    public DbSet<Product> Products => Set<Product>();
}