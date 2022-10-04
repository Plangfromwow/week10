using Dapper.Contrib.Extensions;
using Dapper;
using MySql.Data.MySqlClient;

namespace GroceryCrudDemo.Models
{
    // functionality to access the data, these are the data access layers. 



    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=grocerystore;Uid=root;Pwd=abc123;");


        //crud operations for our category table / class 

        // Read All

        public static List<Category> GetAllCategories()
        {
            return DB.GetAll<Category>().ToList();
        }

        // Read One
        public static Category GetOneCategory(string getID)
        {
            return DB.Get<Category>(getID);
        }

        // Create one (Insert)
        public static Category InsertCategory(Category cat)
        {
            DB.Insert<Category>(cat);
            return cat;
        }
        // delete one 
        public static void DeleteCategory(string id)
        {
            // delete all products in this category
            // we don't do this because it's scary 
            //DB.Execute($"delete from product where category = '{id}'");

            DB.Execute("delete from product where category=@catid", new {catid=id});

            Category cat = new Category() { id = id};
            DB.Delete<Category>(cat);
        }
        //update one
        public static void UpdatCategory(Category cat)
        {
            DB.Update<Category>(cat);
        }
        //crud operations for our product table / class

        // Read All
        public static List<Product> GetAllProducts()
        {
            return DB.GetAll<Product>().ToList();
        }
        // Read One
        public static Product GetOneProduct(int getID)
        {
            return DB.Get<Product>(getID);
        }
        // Create one
        public static Product InsertProduct(Product prod)
        {
            DB.Insert<Product>(prod);
            return prod;
        }
        // delete one 
        public static void DeleteProduct(int id)
        {
            Product prod = new Product() { id = id};
            DB.Delete<Product>(prod);
        }
        //update one
        public static void UpdateProduct(Product prod)
        {
            DB.Update<Product>(prod);
        }

       
    }
}
