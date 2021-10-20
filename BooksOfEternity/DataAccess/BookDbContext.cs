using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BooksOfEternity.DataAccess.Entities;

#nullable disable

namespace BooksOfEternity.DataAccess
{
    public partial class BookDbContext : DbContext
    {
        public BookDbContext()
        {
        }

        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookRecord> BookRecords { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersInfo> UsersInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books", "book");

                entity.HasComment("Книги");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('books_id_seq'::regclass)");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("books_fk");
            });

            modelBuilder.Entity<BookRecord>(entity =>
            {
                entity.ToTable("book_records", "book");

                entity.HasComment("Записи книг (слова, строки и т.д)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('book_records_id_seq'::regclass)");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Sort)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("sort")
                    .HasComment("Положение записи в тексте");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookRecords)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_records_fk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookRecords)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_records_fk");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.ToTable("likes", "book");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('likes_id_seq'::regclass)");

                entity.Property(e => e.BookRecordId).HasColumnName("book_record_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.BookRecord)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.BookRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("likes_fk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("likes_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "book");

                entity.HasComment("Пользователи");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('users_id_seq'::regclass)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("password");
            });

            modelBuilder.Entity<UsersInfo>(entity =>
            {
                entity.ToTable("users_info", "book");

                entity.HasComment("Информация о пользователях");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('users_info_id_seq'::regclass)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("last_name");

                entity.Property(e => e.Patronymic)
                    .HasColumnType("character varying")
                    .HasColumnName("patronymic");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersInfos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_info_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
