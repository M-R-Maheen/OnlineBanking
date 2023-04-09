using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace JwtAuthAPI.Models.BankModel
{

    public class Account
    {
        public Account()
        {
            this.Deposits = new HashSet<Deposit>();
            this.Balances = new HashSet<Balance>();
            this.TransferMoneys = new HashSet<TransferMoney>();

        }

        public int AccountID { get; set; }


       // [Required, StringLength(40)]
        public string AccountHolderName { get; set; }


       // [Required, StringLength(40)]
        public string AccountNumber { get; set; }

       // [Required, StringLength(40)]
        public string AccountType { get; set; }

        //[Required, StringLength(40)]
        public string Gender { get; set; }

       // [Required,StringLength(500)]
        public string Address { get; set; }

       // [Required, StringLength(250)]
        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }


        //[Required, StringLength(250)]
        public string Email { get; set; }

        //[Required, StringLength(200)]
        public string Password { get; set; }

        //nev
        public virtual ICollection<Deposit> Deposits { get; set; }
        //nev
        public virtual ICollection<TransferMoney> TransferMoneys { get; set; }

        public virtual ICollection<Balance> Balances { get; set; }

    }

    public class Deposit
    {
        public int DepositID { get; set; }

        public string AccountNumber { get; set; }

        public string AccountHolderName { get; set; }

        public decimal Amount { get; set; }

        public DateTime DepositDate { get; set; }

        //References
        [ForeignKey("Account")]
        public int AccountID { get; set; }

        // Nev
        public virtual Account Account { get; set; }

    }

    public class TransferMoney
    {
        public int TransferMoneyID { get; set; }

        public string SenderAccountNo { get; set; }

        public string RecipientAccountNo { get; set; }

        public decimal Amount { get; set; }

        public DateTime DepositDate { get; set; }

        //References
        [ForeignKey("Account")]
        public int AccountID { get; set; }

        // Nev
        public virtual Account Account { get; set; }
    }


    public class Balance
    {
        public int BalanceID { get; set; }

        public decimal TotalBalance { get; set; }

        //References
        [ForeignKey("Account")]
        public int AccountID { get; set; }

        // Nev
        public virtual Account Account { get; set; }
    }

    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<TransferMoney> TransferMoneys { get; set; }
        public DbSet<Balance> Balances { get; set; }
    }



    //public class AddMoney
    //{
    //    public AddMoney()
    //    {
    //        this.TransferMoneys = new HashSet<TransferMoney>();
    //    }

    //    public int AddMoneyID { get; set; }

    //    public string AccountHolderName { get; set; }

    //    public string AccountNumber { get; set; }

    //    public int Amount { get; set; }

    //    public string Gender { get; set; }

    //    public string Address { get; set; }

    //    public string Picture { get; set; }

    //    public string Email { get; set; }

    //    public DateTime DepositDate { get; set; }

    //    //nev
    //    public virtual ICollection<TransferMoney> TransferMoneys { get; set; }
    //}


    //public class TransferMoney
    //{
    //    public int TransferMoneyID { get; set; }

    //    public string SenderAccount { get; set; }

    //    public string AccountHolderName { get; set; }

    //    public int Amount { get; set; }

    //    public DateTime DepositDate { get; set; }

    //    //References
    //    [ForeignKey("AddMoney")]
    //    public int AddMoneyID { get; set; }

    //    // Nev
    //    public virtual AddMoney AddMoney { get; set; }
    //}



    //public class BankDbContext : DbContext
    //{
    //    public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

    //    public DbSet<AddMoney> AddMoneys { get; set; }
    //    public DbSet<TransferMoney> TransferMoneys { get; set; }
    //}

}
