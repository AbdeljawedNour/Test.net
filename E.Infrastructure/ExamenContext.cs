using E.ApplicationCore.Domain;
using E.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace E.Infrastructure
{
    public class ExamenContext:DbContext
    { public DbSet<Agent> Agents { get; set; }
        public DbSet<Locataire> Locataires { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Personne> Personnes { get; set; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-K593NFLE\SQLEXPRESS;
                       Initial Catalog=NourAbdeljawedLocataire;
                       Integrated Security=true;MultipleActiveResultSets=true;
                       User ID=noura;Password=Azerty862;TrustServerCertificate=True") ;

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.ApplyConfiguration(new ReservationConfigurations());

            //TPH
            modelBuilder.Entity<Locataire>().HasDiscriminator<int>("LocataireType")
              .HasValue<Locataire>(1) 
              .HasValue<Entreprise>(2)
              .HasValue<Personne>(3);


            //  declarer les forein key et les relations 
             modelBuilder.Entity<Locataire>().HasMany(t => t.Reservations  )
                .WithOne(T => T.Locataire).HasForeignKey(x => x.LocataireFK);
             modelBuilder.Entity<Vehicule>().HasMany(p=>p.Reservations
             ).WithOne(r=>r.vehicule).HasForeignKey(x => x.VehiculeKey);


            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
