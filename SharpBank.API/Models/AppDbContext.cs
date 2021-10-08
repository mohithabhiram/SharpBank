using Microsoft.EntityFrameworkCore;
using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Bank DB
            modelBuilder.Entity<Bank>().HasData(new Bank{BankName="Yaxis",IFSC= "001"});
            modelBuilder.Entity<Bank>().HasData(new Bank{BankName="YesBI",IFSC= "002"});
            modelBuilder.Entity<Bank>().HasData(new Bank{BankName="FDHC", IFSC= "003"});
            modelBuilder.Entity<Bank>().HasData(new Bank { BankName = "YCYCY", IFSC = "004" });

            //Bank DB
            modelBuilder.Entity<Account>().HasData(new Account {  AccountNumber = "001",UserName= "Shriram"});
            modelBuilder.Entity<Account>().HasData(new Account {  AccountNumber = "201",UserName= "Vijith" });
            modelBuilder.Entity<Account>().HasData(new Account {  AccountNumber = "301",UserName= "Sagar"  });
            modelBuilder.Entity<Account>().HasData(new Account {  AccountNumber = "401",UserName= "Balaji" });

            //Transaction DB
            modelBuilder.Entity<Transaction>().HasData(new Transaction { TransactionID = "001", SenderIFSC = "001",RecepientIFSC = "001", SenderAccount = "001",RecepientAccount = "001", Amount = 100.0m });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { TransactionID = "002", SenderIFSC = "002",RecepientIFSC = "002", SenderAccount = "002",RecepientAccount = "002", Amount = 100.0m });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { TransactionID = "003", SenderIFSC = "003",RecepientIFSC = "001", SenderAccount = "001",RecepientAccount = "003", Amount = 100.0m });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { TransactionID = "004", SenderIFSC = "004",RecepientIFSC = "004", SenderAccount = "004",RecepientAccount = "004", Amount = 100.0m });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { TransactionID = "005", SenderIFSC = "001", RecepientIFSC = "001", SenderAccount = "001", RecepientAccount = "001", Amount = 100.0m });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { TransactionID = "006", SenderIFSC = "002", RecepientIFSC = "003", SenderAccount = "001", RecepientAccount = "002", Amount = 100.0m });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { TransactionID = "007", SenderIFSC = "003", RecepientIFSC = "002", SenderAccount = "003", RecepientAccount = "003", Amount = 100.0m });
            modelBuilder.Entity<Transaction>().HasData(new Transaction { TransactionID = "008", SenderIFSC = "004", RecepientIFSC = "004", SenderAccount = "004", RecepientAccount = "004", Amount = 100.0m });

        }

    }
}
