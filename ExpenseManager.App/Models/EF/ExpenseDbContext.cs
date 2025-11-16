using System;
using System.Collections.Generic;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.App.Models.EF;

public partial class ExpenseDbContext : DbContext
{
    public ExpenseDbContext()
    {
    }

    public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<GoalDeposit> GoalDeposits { get; set; }

    public virtual DbSet<Icon> Icons { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Budgets_CategoryID");

            entity.HasIndex(e => e.UserId, "IX_Budgets_UserID");

            entity.Property(e => e.BudgetId).HasColumnName("BudgetID");
            entity.Property(e => e.BudgetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Category).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Budgets).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.ColorId, "IX_Categories_ColorID");

            entity.HasIndex(e => e.IconId, "IX_Categories_IconID");

            entity.HasIndex(e => e.UserId, "IX_Categories_UserID");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IconId).HasColumnName("IconID");
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Color).WithMany(p => p.Categories)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Icon).WithMany(p => p.Categories)
                .HasForeignKey(d => d.IconId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Categories).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Goals_UserID");

            entity.HasIndex(e => e.WalletId, "IX_Goals_WalletID");

            entity.Property(e => e.GoalId).HasColumnName("GoalID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CurrentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GoalName).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Đang thực hiện");
            entity.Property(e => e.TargetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WalletId).HasColumnName("WalletID");

            entity.HasOne(d => d.User).WithMany(p => p.Goals).HasForeignKey(d => d.UserId);

            entity.HasOne(d => d.Wallet).WithMany(p => p.Goals).HasForeignKey(d => d.WalletId);
        });

        modelBuilder.Entity<GoalDeposit>(entity =>
        {
            entity.HasKey(e => e.DepositId);

            entity.HasIndex(e => e.GoalId, "IX_GoalDeposits_GoalID");

            entity.HasIndex(e => e.UserId, "IX_GoalDeposits_UserID");

            entity.HasIndex(e => e.WalletId, "IX_GoalDeposits_WalletID");

            entity.Property(e => e.DepositId).HasColumnName("DepositID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepositDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GoalId).HasColumnName("GoalID");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WalletId).HasColumnName("WalletID");

            entity.HasOne(d => d.Goal).WithMany(p => p.GoalDeposits)
                .HasForeignKey(d => d.GoalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.GoalDeposits).HasForeignKey(d => d.UserId);

            entity.HasOne(d => d.Wallet).WithMany(p => p.GoalDeposits)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Icon>(entity =>
        {
            entity.Property(e => e.IconId).HasColumnName("IconID");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Tickets_UserID");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.QuestionType).HasMaxLength(50);
            entity.Property(e => e.RespondType).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Open");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Transactions_CategoryID");

            entity.HasIndex(e => e.UserId, "IX_Transactions_UserID");

            entity.HasIndex(e => e.WalletId, "IX_Transactions_WalletID");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WalletId).HasColumnName("WalletID");

            entity.HasOne(d => d.Category).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Transactions).HasForeignKey(d => d.UserId);

            entity.HasOne(d => d.Wallet).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.AvatarUrl).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("User");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Wallets_UserID");

            entity.Property(e => e.WalletId).HasColumnName("WalletID");
            entity.Property(e => e.Balance).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Icon).HasMaxLength(100);
            entity.Property(e => e.InitialBalance).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WalletName).HasMaxLength(100);
            entity.Property(e => e.WalletType).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Wallets).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Chỉ cấu hình nếu chưa có Provider nào được thiết lập từ bên ngoài
        if (!optionsBuilder.IsConfigured)
        {
            // THAY THẾ CHUỖI KẾT NỐI VÀO DB CỦA BẠN ĐÃ TEST THÀNH CÔNG
            string connectionString = "Server=localhost,1434;Database=ExpenseDB;User Id=sa;Password=Sa@123456@VeryStrong;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
