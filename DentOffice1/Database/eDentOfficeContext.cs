using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class eDentOfficeContext : DbContext
    {
        public eDentOfficeContext()
        {
        }

        public eDentOfficeContext(DbContextOptions<eDentOfficeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Dijagnoza> Dijagnozas { get; set; }
        public virtual DbSet<Drzava> Drzavas { get; set; }
        public virtual DbSet<Grad> Grads { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<Lijek> Lijeks { get; set; }
        public virtual DbSet<MedicinskiKarton> MedicinskiKartons { get; set; }
        public virtual DbSet<Pacijent> Pacijents { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Pregled> Pregleds { get; set; }
        public virtual DbSet<Racun> Racuns { get; set; }
        public virtual DbSet<Termin> Termins { get; set; }
        public virtual DbSet<Uloga> Ulogas { get; set; }
        public virtual DbSet<Usluga> Uslugas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=eDentOffice;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("CreditCard");

                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.Ime).IsRequired();

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CreditCar__Koris__38996AB5");
            });

            modelBuilder.Entity<Dijagnoza>(entity =>
            {
                entity.ToTable("Dijagnoza");

                entity.Property(e => e.DijagnozaId).HasColumnName("DijagnozaID");

                entity.Property(e => e.Napomena).IsRequired();

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.ToTable("Drzava");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("Grad");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grads)
                    .HasForeignKey(d => d.DrzavaId)
                    .HasConstraintName("FK__Grad__DrzavaID__286302EC");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("Korisnik");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime).IsRequired();

                entity.Property(e => e.Jmbg).HasColumnName("JMBG");

                entity.Property(e => e.LozinkaHash).IsRequired();

                entity.Property(e => e.LozinkaSalt).IsRequired();

                entity.Property(e => e.Prezime).IsRequired();

                entity.Property(e => e.Slika).HasColumnType("image");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK__Korisnik__GradID__34C8D9D1");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.UlogaId)
                    .HasConstraintName("FK__Korisnik__UlogaI__35BCFE0A");
            });

            modelBuilder.Entity<Lijek>(entity =>
            {
                entity.ToTable("Lijek");

                entity.Property(e => e.LijekId).HasColumnName("LijekID");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<MedicinskiKarton>(entity =>
            {
                entity.ToTable("MedicinskiKarton");

                entity.Property(e => e.MedicinskiKartonId).HasColumnName("MedicinskiKartonID");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.PacijentId).HasColumnName("PacijentID");

                entity.Property(e => e.PregledId).HasColumnName("PregledID");

                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.MedicinskiKartons)
                    .HasForeignKey(d => d.PacijentId)
                    .HasConstraintName("FK__Medicinsk__Pacij__5812160E");

                entity.HasOne(d => d.Pregled)
                    .WithMany(p => p.MedicinskiKartons)
                    .HasForeignKey(d => d.PregledId)
                    .HasConstraintName("FK__Medicinsk__Pregl__59063A47");
            });

            modelBuilder.Entity<Pacijent>(entity =>
            {
                entity.ToTable("Pacijent");

                entity.Property(e => e.PacijentId).HasColumnName("PacijentID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Pacijents)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__Pacijent__Korisn__3E52440B");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Metoda).IsRequired();

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CreditCardId)
                    .HasConstraintName("FK__Payment__CreditC__44FF419A");
            });

            modelBuilder.Entity<Pregled>(entity =>
            {
                entity.ToTable("Pregled");

                entity.Property(e => e.PregledId).HasColumnName("PregledID");

                entity.Property(e => e.DijagnozaId).HasColumnName("DijagnozaID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.LijekId).HasColumnName("LijekID");

                entity.Property(e => e.TerminId).HasColumnName("TerminID");

                entity.HasOne(d => d.Dijagnoza)
                    .WithMany(p => p.Pregleds)
                    .HasForeignKey(d => d.DijagnozaId)
                    .HasConstraintName("FK__Pregled__Dijagno__4E88ABD4");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Pregleds)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__Pregled__Korisni__4BAC3F29");

                entity.HasOne(d => d.Lijek)
                    .WithMany(p => p.Pregleds)
                    .HasForeignKey(d => d.LijekId)
                    .HasConstraintName("FK__Pregled__LijekID__4CA06362");

                entity.HasOne(d => d.Termin)
                    .WithMany(p => p.Pregleds)
                    .HasForeignKey(d => d.TerminId)
                    .HasConstraintName("FK__Pregled__TerminI__4D94879B");
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.ToTable("Racun");

                entity.Property(e => e.RacunId).HasColumnName("RacunID");

                entity.Property(e => e.DatumIzdavanjaRacuna).HasColumnType("date");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.PregledId).HasColumnName("PregledID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Racuns)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__Racun__KorisnikI__6FE99F9F");

                entity.HasOne(d => d.Pregled)
                    .WithMany(p => p.Racuns)
                    .HasForeignKey(d => d.PregledId)
                    .HasConstraintName("FK__Racun__PregledID__70DDC3D8");
            });

            modelBuilder.Entity<Termin>(entity =>
            {
                entity.ToTable("Termin");

                entity.Property(e => e.TerminId).HasColumnName("TerminID");

                entity.Property(e => e.DatumVrijeme);

                entity.Property(e => e.PacijentId).HasColumnName("PacijentID");

                entity.Property(e => e.UslugaId).HasColumnName("UslugaID");

                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.Termins)
                    .HasForeignKey(d => d.PacijentId)
                    .HasConstraintName("FK__Termin__Pacijent__47DBAE45");

                entity.HasOne(d => d.Usluga)
                    .WithMany(p => p.Termins)
                    .HasForeignKey(d => d.UslugaId)
                    .HasConstraintName("FK__Termin__UslugaID__48CFD27E");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.ToTable("Uloga");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Usluga>(entity =>
            {
                entity.ToTable("Usluga");

                entity.Property(e => e.UslugaId).HasColumnName("UslugaID");

                entity.Property(e => e.Naziv).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
