﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AppCore.Models;

namespace AppCore
{
    public class UserContext : DbContext
    {
        public UserContext(string nameOrConnectionString) :
            base(Settings.Settings.constr)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Status> OrderStatuses { get; set; }
        public DbSet<ContrAgent> Contragents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CurrencyCode> CurrencyCodes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BalanceOnDay> BalanceOnDays { get; set; }
        public DbSet<PaymentColor> PaymentColors { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<FuturePayment> FuturePayments { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<CalculationItem> CalculationItems { get; set; }
        public DbSet<CalculationConstant> CalculationConstants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CalculationType> CalculationTypes { get; set; }
        public DbSet<CalculatedProduct> CalculatedProducts { get; set; }
        public DbSet<CalculatedItem> CalculatedItems { get; set; }
        public DbSet<CalculationInstance> CalculationInsctInstances { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<DynamicConstant> DynamicConstants { get; set; }
        public DbSet<CalculationOrder> CalculationOrders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserContext>(null);

            base.OnModelCreating(modelBuilder);
        }

    }
}