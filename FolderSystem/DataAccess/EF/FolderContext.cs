using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EF
{
    public class FoldersContext : DbContext
    {
        public DbSet<Folder> Folders { get; set; }

        public FoldersContext()
        { 
        }

        public FoldersContext(DbContextOptions<FoldersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>()
                .HasOne(f => f.ParentFolder)
                .WithMany(f => f.Subfolders)
                .HasForeignKey(f => f.ParentFolderId);

            modelBuilder.Entity<Folder>().HasData(
                new Folder { Id = 1, Name = "Creating Digital Images", ParentFolderId = null },
                new Folder { Id = 2, Name = "Resourses", ParentFolderId = 1 },
                new Folder { Id = 3, Name = "Evidence", ParentFolderId = 1 },
                new Folder { Id = 4, Name = "Graphic Products", ParentFolderId = 1 },
                new Folder { Id = 5, Name = "Primary Sourses", ParentFolderId = 2 },
                new Folder { Id = 6, Name = "Secondary Sourses", ParentFolderId = 2 },
                new Folder { Id = 7, Name = "Process", ParentFolderId = 4 },
                new Folder { Id = 8, Name = "Final Product", ParentFolderId = 4 }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               @"Server=(localdb)\mssqllocaldb;Database=FoldersDB;Trusted_Connection=True;");
        }

    }
}
