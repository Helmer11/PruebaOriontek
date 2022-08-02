using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test_OrionTek_Api.Persistencia
{
    public partial class TestOriontekContext : DbContext
    {
        public TestOriontekContext()
        {
        }

        public TestOriontekContext(DbContextOptions<TestOriontekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteDireccionesTran> ClienteDireccionesTrans { get; set; }
        public virtual DbSet<ClientesTran> ClientesTrans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-97L1R409\\SQLEXPRESS;Database=TestOriontek;user=helmer;password=123456789;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ClienteDireccionesTran>(entity =>
            {
                entity.HasKey(e => e.ClienteDireccionId);

                entity.ToTable("Cliente_Direcciones_Trans");

                entity.Property(e => e.ClienteDireccionId).HasColumnName("Cliente_Direccion_id");

                entity.Property(e => e.ClienteDireccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Direccion");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ClienteDireccionesTrans)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente_D__Clien__628FA481");
            });

            modelBuilder.Entity<ClientesTran>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK__Clientes__EB6B387C21F79E92");

                entity.ToTable("Clientes_Trans");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_id");

                entity.Property(e => e.ClienteApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Apellido");

                entity.Property(e => e.ClienteCelular)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Celular");

                entity.Property(e => e.ClienteEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Email");

                entity.Property(e => e.ClienteNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Nombre");

                entity.Property(e => e.ClienteTelefono)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
