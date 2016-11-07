using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using nsProduct;

namespace StoreModel{
    public class  Store{
        [Required]
        public string Name;
        public int Id;
        public List<Product> Products;
        public DateTime CreatedAt;
    }
}