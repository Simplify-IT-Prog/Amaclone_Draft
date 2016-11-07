using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using StoreModel;
using nsRepoProduct;
using nsProduct;

namespace StoreRepo{
    public interface IStore {
        List<Store> create(List<Store> s);
        Store get(int id);
        List<Store> getAll();
        Store update(int id, Store s);
        List<Store> delete(int id);
    }

    public class StoreRepo : IStore {
        public List<Store> stores { get; set; }
        public int StoreCount = 0;
        
        // Constructor
        public StoreRepo () {
            // TODO add store seeds
        }

        // Methods
        public List<Store> create(List<Store> s){
            foreach (Store sToAdd in s)
            {
                sToAdd.Id = StoreCount++;
                sToAdd.CreatedAt = DateTime.Now;

                //sToAdd.Products.add(sToAdd.Products);
                stores.Add(sToAdd); 
            }
            return stores;
        }

        public List<Store> getAll() => stores;

        public Store get(int id) {
            return stores.First(x => x.Id == id);
        } 

        public Store update(int id, Store s){
            Store toUpdate = stores.First(x => x.Id == id);
            if(toUpdate != null){
                stores.Remove(toUpdate);
                stores.Add(s);
                return stores.Last(); 
            }
            return null;
        }

        public List<Store> delete(int id){
            Store s = stores.First(x => x.Id == id);
            if(s != null){
                stores.Remove(s);
                return stores;
            } else {return null;}
        }
    }
}

// // colocate DbSet declarations with classes
// public partial class DB : DbContext {
//     public DbSet<Store> Stores { get; set; }
//     public DbSet<Product> Products { get; set; }
//     public DbSet<Category> Categories { get; set; }
// }

public partial class Handler {
    public void RegisterRepos(IServiceCollection services){
        ICategory.Register(services, "Categories");
        IProduct.Register(services, "Products",
            d => d.Include(l => l.Categories));
        IStore.Register(services, "Stores",
            d => d.Include(b => b.Products).ThenInclude(l => l.Categories));
    }
}