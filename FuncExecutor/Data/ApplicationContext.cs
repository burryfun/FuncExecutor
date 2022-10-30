using FuncExecutor.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncExecutor.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndicatorModel>().HasData(
                new IndicatorModel()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Code = "A",
                    Description = "Value A",
                    TypeDescr = "Manual",
                    Func = null,
                },
                new IndicatorModel()
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    Code = "B",
                    Description = "Value B",
                    TypeDescr = "Manual",
                    Func = null,
                },
                new IndicatorModel()
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    Code = "C",
                    Description = "Value C",
                    TypeDescr = "Manual",
                    Func = null,
                },
                new IndicatorModel()
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                    Code = "D",
                    Description = "Discriminant",
                    TypeDescr = "Func",
                    Func = "Pow(B,2) - 4 * A * C",
                },
                new IndicatorModel()
                {
                    Id = 5,
                    CreatedAt = DateTime.Now,
                    Code = "X1",
                    Description = "First solution",
                    TypeDescr = "Func",
                    Func = "(-B + Sqrt(D)) / (2 * A)",
                },
                new IndicatorModel()
                {
                    Id = 6,
                    CreatedAt = DateTime.Now,
                    Code = "X2",
                    Description = "Second solution",
                    TypeDescr = "Func",
                    Func = "(-B - Sqrt(D)) / (2 * A)",
                },
                new IndicatorModel()
                {
                    Id = 7,
                    CreatedAt = DateTime.Now,
                    Code = "Sin(A)",
                    Description = "Sin()",
                    TypeDescr = "Func",
                    Func = "Sin(A)",
                },
                new IndicatorModel()
                {
                    Id = 8,
                    CreatedAt = DateTime.Now,
                    Code = "Cos(A)",
                    Description = "Cos()",
                    TypeDescr = "Func",
                    Func = "Cos(A)",
                },
                new IndicatorModel()
                {
                    Id = 9,
                    CreatedAt = DateTime.Now,
                    Code = "Exp(A)",
                    Description = "Exp^x",
                    TypeDescr = "Func",
                    Func = "Exp(A)",
                },
                new IndicatorModel()
                {
                    Id = 10,
                    CreatedAt = DateTime.Now,
                    Code = "Log(A)",
                    Description = "Ln(x)",
                    TypeDescr = "Func",
                    Func = "Log(A)",
                },
                new IndicatorModel()
                {
                    Id = 11,
                    CreatedAt = DateTime.Now,
                    Code = "Random()",
                    Description = "Random (0 .. 1)",
                    TypeDescr = "Func",
                    Func = "Random()",
                }
            );
            modelBuilder.Entity<ValueModel>().HasData(
                new ValueModel()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 1,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 2,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 3,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 4,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 5,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 5,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 6,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 6,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 7,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 7,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 8,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 8,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 9,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 9,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 10,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 10,
                    Value = null,
                },
                new ValueModel()
                {
                    Id = 11,
                    CreatedAt = DateTime.Now,
                    FormName = "Form 1",
                    IndicatorId = 11,
                    Value = null,
                }
            );
        }

        public DbSet<IndicatorModel> Indicators { get; set; } = null!;
        public DbSet<ValueModel> Values { get; set; } = null!;
    }
}