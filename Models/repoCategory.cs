using System;
using System.Collections.Generic;
using System.Linq;

using nsCategory;
using nsProduct;

namespace nsRepoCategory{
    public interface ICategory {
        List<Category> getAll(); 
        void add (List<Category> c);
        bool delete(int id);
        Category get(int id);
        Category update(int id, Category c);
    }

    public class CategoryAPI : ICategory {
        private List<Category> categories = new List<Category>();
        private int idCount = 0;
        // Constructor
        public CategoryAPI() {
            // TODO use this to SEED Categorys
        }
        
        // Methods
        public void add (List<Category> c) {
            foreach (Category cToAdd in c)
            {
                cToAdd.Id = idCount++;
                cToAdd.CreatedAt = DateTime.Now;
                categories.Add(cToAdd);
            }
        }
        public List<Category> getAll() {
            return categories;
        }

        public Category get(int id) {
            return categories.First(x => x.Id == id);
        }

        public Category update(int id, Category p) {
            if (categories.Remove(categories.First(x => x.Id == id))) {
                categories.Add(p);
                return categories.Last();
            } else { return null; }
        }
        public bool delete(int id) => (categories.Remove(categories.First(x => x.Id == id))) ? true : false;
    }
}