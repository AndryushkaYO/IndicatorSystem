using IndicatorData.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace IndicatorData
{
    public class IndicatorContext : DbContext
    {
        public IndicatorContext(DbContextOptions<IndicatorContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<LoginInfo> LoginInfos { get; set; }
        public DbSet<IndicatorPerson> IndicatorPersons { get; set; }
        public DbSet<IndicatorType> IndicatorTypes { get; set; }
        public DbSet<IndicatorTable> IndicatorTable { get; set; }
    }
}
