using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.Location;
using Project.Domain.Entities.Session;
using Project.Domain.Entities.User;

namespace Project.Api.Models;

public partial class MinisterulFinantelorContext : DbContext
{
     public MinisterulFinantelorContext()
     {
     }

     public MinisterulFinantelorContext(DbContextOptions<MinisterulFinantelorContext> options)
         : base(options)
     {
     }

     public virtual DbSet<UDbTable> Users { get; set; }
     public virtual DbSet<SessionsDbTable> Sessions { get; set; }
     public virtual DbSet<DistrictsDbTable> Districts { get; set; }
     public virtual DbSet<RegionsDbTable> Regions { get; set; }
     public virtual DbSet<IBanDbTable> IBans { get; set; }


     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=5URPR153\\SQLEXPRESS;Database=MinisterulFinantelor;Trusted_Connection=true;TrustServerCertificate=true;");

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          OnModelCreatingPartial(modelBuilder);
     }

     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
