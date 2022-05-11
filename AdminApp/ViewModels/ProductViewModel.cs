using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class ProductViewModel : ViewModel<Product>
    {
        private readonly Product product;

        public int Id { get { return product.Id; } set { product.Id = value; } }

        public string Name { get { return product.Name; } set { product.Name = value; } }

        public double Price { get { return product.Price; } set { product.Price = value; } }
        public List<Ingredient> ingredients { get { return product.Ingredients; } set {product.Ingredients  = value; } }
        public int ProductType
        {
            get { return (int)product.ProductType; }
            set { product.ProductType = (ProductType)value; }
        }

        public byte[] Image
        {
            get
            {
                return model.Image;
            }
            set
            {
                model.Image = value;
            }
        }

        public ProductViewModel (Product model) : base (model)
        {
            this.product = model;
        }
    }
}
