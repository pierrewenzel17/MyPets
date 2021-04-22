using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class MyPetsContext : DbContext
    {
        public MyPetsContext()
        {
        }

        public MyPetsContext(DbContextOptions<MyPetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Investigation> Investigations { get; set; }
        public virtual DbSet<InvestigationDocument> InvestigationDocuments { get; set; }
        public virtual DbSet<InvestigationPerson> InvestigationPeople { get; set; }
        public virtual DbSet<InvestigationToInvestigationDocument> InvestigationToInvestigationDocuments { get; set; }
        public virtual DbSet<InvestigationToRound> InvestigationToRounds { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<RoundToInvestigationDocument> RoundToInvestigationDocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=api;password=mdp;database=MyPets");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investigation>(entity =>
            {
                entity.ToTable("INVESTIGATION");

                entity.HasIndex(e => e.HolderInvestigatorId, "holder_investigator_id");

                entity.HasIndex(e => e.InvestigationOffenderId, "investigation_offender_id");

                entity.HasIndex(e => e.InvestigationPlaintiffId, "investigation_plaintiff_id");

                entity.Property(e => e.InvestigationId).HasColumnName("investigation_id");

                entity.Property(e => e.Breed)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("breed");

                entity.Property(e => e.HolderInvestigatorId).HasColumnName("holder_investigator_id");

                entity.Property(e => e.InvestigationOffenderId).HasColumnName("investigation_offender_id");

                entity.Property(e => e.InvestigationPlaintiffId).HasColumnName("investigation_plaintiff_id");

                entity.Property(e => e.IsFinish).HasColumnName("is_finish");

                entity.Property(e => e.NumberOfPets).HasColumnName("number_of_pets");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("reason");

                entity.HasOne(d => d.HolderInvestigator)
                    .WithMany(p => p.Investigations)
                    .HasForeignKey(d => d.HolderInvestigatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVESTIGATION_ibfk_1");

                entity.HasOne(d => d.InvestigationOffender)
                    .WithMany(p => p.InvestigationInvestigationOffenders)
                    .HasForeignKey(d => d.InvestigationOffenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVESTIGATION_ibfk_2");

                entity.HasOne(d => d.InvestigationPlaintiff)
                    .WithMany(p => p.InvestigationInvestigationPlaintiffs)
                    .HasForeignKey(d => d.InvestigationPlaintiffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVESTIGATION_ibfk_3");
            });

            modelBuilder.Entity<InvestigationDocument>(entity =>
            {
                entity.ToTable("INVESTIGATION_DOCUMENT");

                entity.Property(e => e.InvestigationDocumentId).HasColumnName("investigation_document_id");

                entity.Property(e => e.File)
                    .HasColumnType("longblob")
                    .HasColumnName("file");
            });

            modelBuilder.Entity<InvestigationPerson>(entity =>
            {
                entity.ToTable("INVESTIGATION_PERSON");

                entity.Property(e => e.InvestigationPersonId).HasColumnName("investigation_person_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("zip_code");
            });

            modelBuilder.Entity<InvestigationToInvestigationDocument>(entity =>
            {
                entity.ToTable("INVESTIGATION_TO_INVESTIGATION_DOCUMENT");

                entity.HasIndex(e => e.InvestigationDocumentId, "investigation_document_id");

                entity.HasIndex(e => e.InvestigationId, "investigation_id");

                entity.Property(e => e.InvestigationToInvestigationDocumentId).HasColumnName("investigation_to_investigation_document_id");

                entity.Property(e => e.InvestigationDocumentId).HasColumnName("investigation_document_id");

                entity.Property(e => e.InvestigationId).HasColumnName("investigation_id");

                entity.HasOne(d => d.InvestigationDocument)
                    .WithMany(p => p.InvestigationToInvestigationDocuments)
                    .HasForeignKey(d => d.InvestigationDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVESTIGATION_TO_INVESTIGATION_DOCUMENT_ibfk_2");

                entity.HasOne(d => d.Investigation)
                    .WithMany(p => p.InvestigationToInvestigationDocuments)
                    .HasForeignKey(d => d.InvestigationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVESTIGATION_TO_INVESTIGATION_DOCUMENT_ibfk_1");
            });

            modelBuilder.Entity<InvestigationToRound>(entity =>
            {
                entity.ToTable("INVESTIGATION_TO_ROUND");

                entity.HasIndex(e => e.InvestigationId, "investigation_id");

                entity.HasIndex(e => e.RoundId, "round_id");

                entity.Property(e => e.InvestigationToRoundId).HasColumnName("investigation_to_round_id");

                entity.Property(e => e.InvestigationId).HasColumnName("investigation_id");

                entity.Property(e => e.RoundId).HasColumnName("round_id");

                entity.HasOne(d => d.Investigation)
                    .WithMany(p => p.InvestigationToRounds)
                    .HasForeignKey(d => d.InvestigationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVESTIGATION_TO_ROUND_ibfk_2");

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.InvestigationToRounds)
                    .HasForeignKey(d => d.RoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVESTIGATION_TO_ROUND_ibfk_1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("PERSON");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.Hierarchy).HasColumnName("hierarchy");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("zip_code");

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("zone");
            });

            modelBuilder.Entity<Round>(entity =>
            {
                entity.ToTable("ROUND");

                entity.HasIndex(e => e.InvestigatorId, "investigator_id");

                entity.Property(e => e.RoundId).HasColumnName("round_id");

                entity.Property(e => e.CommentRound)
                    .HasMaxLength(500)
                    .HasColumnName("comment_round");

                entity.Property(e => e.DateRound)
                    .HasColumnType("date")
                    .HasColumnName("date_round");

                entity.Property(e => e.InvestigatorId).HasColumnName("investigator_id");

                entity.HasOne(d => d.Investigator)
                    .WithMany(p => p.Rounds)
                    .HasForeignKey(d => d.InvestigatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ROUND_ibfk_1");
            });

            modelBuilder.Entity<RoundToInvestigationDocument>(entity =>
            {
                entity.ToTable("ROUND_TO_INVESTIGATION_DOCUMENT");

                entity.HasIndex(e => e.InvestigationDocumentId, "investigation_document_id");

                entity.HasIndex(e => e.RoundId, "round_id");

                entity.Property(e => e.RoundToInvestigationDocumentId).HasColumnName("round_to_investigation_document_id");

                entity.Property(e => e.InvestigationDocumentId).HasColumnName("investigation_document_id");

                entity.Property(e => e.RoundId).HasColumnName("round_id");

                entity.HasOne(d => d.InvestigationDocument)
                    .WithMany(p => p.RoundToInvestigationDocuments)
                    .HasForeignKey(d => d.InvestigationDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ROUND_TO_INVESTIGATION_DOCUMENT_ibfk_2");

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.RoundToInvestigationDocuments)
                    .HasForeignKey(d => d.RoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ROUND_TO_INVESTIGATION_DOCUMENT_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
