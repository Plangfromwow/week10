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

        // Read One

        // Create one

        // delete one 

        //update one

    }
}
