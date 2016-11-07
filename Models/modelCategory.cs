using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using nsProduct;

namespace nsCategory
{
    public class Category{
        public int Id;
        [Required]
        public string Name;
        public DateTime CreatedAt;
        public List<Product> ProductId;
    }
}
        