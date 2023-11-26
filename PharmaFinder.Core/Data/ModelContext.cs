using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PharmaFinder.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<Contactu> Contactus { get; set; } = null!;
        public virtual DbSet<Home> Homes { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Pharmacy> Pharmacies { get; set; } = null!;
        public virtual DbSet<Phmed> Phmeds { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Usertestimonial> Usertestimonials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=C##PHARM;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##PHARM")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("ABOUT");

                entity.Property(e => e.Aboutid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUTID");

                entity.Property(e => e.Content1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT1");

                entity.Property(e => e.Content2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT2");

                entity.Property(e => e.Content3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT3");

                entity.Property(e => e.Content4)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT4");

                entity.Property(e => e.Content5)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT5");

                entity.Property(e => e.Heading1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING1");

                entity.Property(e => e.Heading2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING2");

                entity.Property(e => e.Heading3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING3");

                entity.Property(e => e.Heading4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING4");

                entity.Property(e => e.Heading5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING5");

                entity.Property(e => e.Image1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image10)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE10");

                entity.Property(e => e.Image2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE3");

                entity.Property(e => e.Image4)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE4");

                entity.Property(e => e.Image5)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE5");

                entity.Property(e => e.Image6)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE6");

                entity.Property(e => e.Image7)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE7");

                entity.Property(e => e.Image8)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE8");

                entity.Property(e => e.Image9)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE9");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("BANK");

                entity.Property(e => e.Bankid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BANKID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Cardholder)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CARDHOLDER");

                entity.Property(e => e.Cardnumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CVV");

                entity.Property(e => e.Expiredate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIREDATE");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.HasKey(e => e.Contactusid)
                    .HasName("SYS_C008375");

                entity.ToTable("CONTACTUS");

                entity.Property(e => e.Contactusid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTUSID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.ToTable("HOME");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Content1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT1");

                entity.Property(e => e.Content2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT2");

                entity.Property(e => e.Content3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT3");

                entity.Property(e => e.Content4)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT4");

                entity.Property(e => e.Content5)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT5");

                entity.Property(e => e.Heading1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING1");

                entity.Property(e => e.Heading2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING2");

                entity.Property(e => e.Heading3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING3");

                entity.Property(e => e.Heading4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING4");

                entity.Property(e => e.Heading5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEADING5");

                entity.Property(e => e.Image1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image10)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE10");

                entity.Property(e => e.Image2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE3");

                entity.Property(e => e.Image4)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE4");

                entity.Property(e => e.Image5)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE5");

                entity.Property(e => e.Image6)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE6");

                entity.Property(e => e.Image7)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE7");

                entity.Property(e => e.Image8)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE8");

                entity.Property(e => e.Image9)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE9");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("MEDICINE");

                entity.Property(e => e.Medicineid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MEDICINEID");

                entity.Property(e => e.Activesubstance)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVESUBSTANCE");

                entity.Property(e => e.Expiredate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIREDATE");

                entity.Property(e => e.Medicinedescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINEDESCRIPTION");

                entity.Property(e => e.Medicinename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINENAME");

                entity.Property(e => e.Medicineprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MEDICINEPRICE");

                entity.Property(e => e.Medicinetype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINETYPE");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.Orderid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDERID");

                entity.Property(e => e.Approval)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL");

                entity.Property(e => e.Orderdate)
                    .HasPrecision(6)
                    .HasColumnName("ORDERDATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Orderprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDERPRICE");

                entity.Property(e => e.Pharmacyid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PHARMACYID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Pharmacy)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Pharmacyid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008370");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008371");
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.ToTable("PHARMACY");

                entity.Property(e => e.Pharmacyid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PHARMACYID");

                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Lat)
                    .HasColumnType("NUMBER(10,6)")
                    .HasColumnName("LAT");

                entity.Property(e => e.Lng)
                    .HasColumnType("NUMBER(10,6)")
                    .HasColumnName("LNG");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Pharmacyname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHARMACYNAME");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");
            });

            modelBuilder.Entity<Phmed>(entity =>
            {
                entity.ToTable("PHMED");

                entity.Property(e => e.Phmedid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PHMEDID");

                entity.Property(e => e.Medicineid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MEDICINEID");

                entity.Property(e => e.Pharmacyid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PHARMACYID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.Phmeds)
                    .HasForeignKey(d => d.Medicineid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008349");

                entity.HasOne(d => d.Pharmacy)
                    .WithMany(p => p.Phmeds)
                    .HasForeignKey(d => d.Pharmacyid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008348");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Profileimage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PROFILEIMAGE");

                entity.Property(e => e.Registrationdate)
                    .HasPrecision(6)
                    .HasColumnName("REGISTRATIONDATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008357");
            });

            modelBuilder.Entity<Usertestimonial>(entity =>
            {
                entity.HasKey(e => e.Utestimonialid)
                    .HasName("SYS_C008377");

                entity.ToTable("USERTESTIMONIAL");

                entity.Property(e => e.Utestimonialid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UTESTIMONIALID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Testimonialdate)
                    .HasPrecision(6)
                    .HasColumnName("TESTIMONIALDATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Testimonialtext)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIALTEXT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usertestimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008378");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
