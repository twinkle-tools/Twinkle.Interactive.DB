using DBService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DBService.Repositories.DBContext
{
    public class DbServiceContext:DbContext
    {
        public DbSet<Control> Controls { get; set; }
        public DbSet<MethodParam> MethodsParams { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TableColumn> TablesColumns { get; set; }
        public DbSet<TreatmentOption> TreatmentsOptions { get; set; }
        public DbSet<TypeControl> TypesControls { get; set; }
        public DbSet<ViewDefinitionCriteria> ViewDefinitionCriteria { get; set; }
        public DbSet<ViewDefinitionCriteriaParam> ViewDefinitionCriteriaParams { get; set; }
        public DbSet<View> Views { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=views.db");
        
        public DbServiceContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypesControlsToMethods>()
                .HasKey(t => new { t.TypeControlId, t.MethodId });
            modelBuilder.Entity<TypesControlsToMethods>()
                .HasOne(sc => sc.TypeControl)
                .WithMany(s => s.ControlMethods)
                .HasForeignKey(sc => sc.TypeControlId);
            modelBuilder.Entity<TypesControlsToMethods>()
                .HasOne(sc => sc.Method)
                .WithMany(c => c.TypeControlMethods)
                .HasForeignKey(sc => sc.MethodId);



            modelBuilder.Entity<ControlsToMethods>()
                .HasKey(t => new { t.ControlId, t.MethodId });
            modelBuilder.Entity<ControlsToMethods>()
                .HasOne(sc => sc.Control)
                .WithMany(s => s.ControlsMethods)
                .HasForeignKey(sc => sc.ControlId);
            modelBuilder.Entity<ControlsToMethods>()
                .HasOne(sc => sc.Method)
                .WithMany(c => c.ControlMethods)
                .HasForeignKey(sc => sc.MethodId);



            modelBuilder.Entity<MethodToTreatmentOptions>()
                .HasKey(t => new { t.MethodId, t.TreatmentOptionId });
            modelBuilder.Entity<MethodToTreatmentOptions>()
                .HasOne(sc => sc.Method)
                .WithMany(s => s.MethodTreatmentOptions)
                .HasForeignKey(sc => sc.MethodId);
            modelBuilder.Entity<MethodToTreatmentOptions>()
                .HasOne(sc => sc.TreatmentOption)
                .WithMany(c => c.MethodTreatmentOptions)
                .HasForeignKey(sc => sc.TreatmentOptionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}