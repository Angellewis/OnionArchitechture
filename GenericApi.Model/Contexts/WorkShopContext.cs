using GenericApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Contexts
{
    public class WorkShopContext : BaseDbContext
    {
        public WorkShopContext(DbContextOptions<WorkShopContext> options)
        {
        }
        public DbSet<WorkShop> WorkShops { get; set; }
        public DbSet<WorkShopDay> WorkShopDays { get; set; }
        public DbSet<WorkShopMember> WorkShopMembers { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
