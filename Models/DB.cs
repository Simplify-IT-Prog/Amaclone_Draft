using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using nsProduct;
using nsCategory;
using StoreModel;

public class DB : DbContext {

    public DB(): base(){}
    // public DB(IDbContextFactory<DB> factory): base(){}

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        // options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        // Sqlite can also take other connection strings; 
        // Exeternal data sources can also be used:
        // i.e. 
        // @"Data Source=d:\otherdrive.db"
        // @"Data Source=http://...."
        //
        // use sqlite
        //
        // options.UseSqlite("Filename=./app.db");
        //
        // or use in-memory db
        options.UseInMemoryDatabase();
        // 
        // or postgres
        // options.usePostgresSql();
    }

    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Store>().ToTable("Store");
            builder.Entity<Category>().ToTable("Category");
        }

    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}