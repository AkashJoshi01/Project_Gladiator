using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project_Gladiator.ViewModel;

#nullable disable

namespace Project_Gladiator.models
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CardDetail> CardDetails { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<balamt> balamts { get; set; }
        public virtual DbSet<PurchaseHistory>PurchaseHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;database=Project;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CardDetail>(entity =>
            {
                entity.HasKey(e => e.CardNo)
                    .HasName("PK__Card_Det__45AA6CB04354267B");

                entity.ToTable("Card_Details");

                entity.Property(e => e.CardNo).HasColumnName("Card_No");

                entity.Property(e => e.CardStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Card_Status");

                entity.Property(e => e.CustId).HasColumnName("Cust_ID");

                //entity.Property(e => e.Emi).HasColumnName("EMI");

                entity.Property(e => e.RemainingCredit).HasColumnName("Remaining_Credit");

                entity.Property(e => e.TotalCredit).HasColumnName("Total_Credit");

                entity.Property(e => e.ValidTill)
                    .HasColumnType("date")
                    .HasColumnName("Valid_till");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.CardDetails)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Card_Deta__Cust___412EB0B6");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Product___9834FB9A330289F2");

                entity.ToTable("Product_Details");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.Availability)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Registra__7B895137517FAC57");

                entity.ToTable("Registration");

                entity.HasIndex(e => e.UserName, "UQ__Registra__681E8A60B68948BD")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Registra__A9D1053439821ACE")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNo, "UQ__Registra__F8A74A4E2C8E3FA0")
                    .IsUnique();

                entity.Property(e => e.CustId).HasColumnName("Cust_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Bank_Acc_No");

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Card_Type");

                entity.Property(e => e.ConfirmedPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Confirmed_Password");

                entity.Property(e => e.CustDob)
                    .HasColumnType("date")
                    .HasColumnName("Cust_DOB");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Name");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ifsc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IFSC");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");
                entity.Property(e => e.Rstatus)
                   .IsRequired()
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .HasColumnName("Rstatus");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");

                entity.Property(e => e.BalanceAmt).HasColumnName("Balance_Amt");

                entity.Property(e => e.CustId).HasColumnName("Cust_ID");

                entity.Property(e => e.Emi).HasColumnName("EMI");

                entity.Property(e => e.PaidAmt).HasColumnName("Paid_Amt");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");
                entity.Property(e => e.Tenure).HasColumnName("Tenure");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Cust___3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
