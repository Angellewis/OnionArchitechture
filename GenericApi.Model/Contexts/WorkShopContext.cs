using GenericApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Contexts
{
    public class WorkShopContext : BaseDbContext
    {
        public WorkShopContext(DbContextOptions<WorkShopContext> options) : base(options)
        {
        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<WorkShop> WorkShops { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<WorkShopMember> WorkShopMembers { get; set; }
        public DbSet<WorkShopDay> WorkShopDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
