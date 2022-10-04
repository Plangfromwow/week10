using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Dapper;
using MySqlX.XDevAPI.Relational;

namespace BookClubLab.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=bookclub;Uid=root;Pwd=abc123;");

       // *THIS IS NOW PERSON*

        // read
        public static List<Person> GetAllPeople()
        {
            List<Person> peeps = DB.GetAll<Person>().ToList();
            return peeps;
        }

        public static Person GetPerson(int id)
        {
            return DB.Get<Person>(id);
        }
        // delete
        public static void RemovePerson(int id)
        {
            DB.Execute("delete from presentation where personid=@perid", new { perid = id });

            Person person = DB.Get<Person>(id);
            DB.Delete(person);
        }

        // create
        public static Person CreatePerson(Person per)
        {
            DB.Insert(per);
            return per;
        }

        // edit 
        public static void UpdatePerson(Person per)
        {
            DB.Update(per);
        }

        // *THIS IS NOW PRESENTATION*

        // read
        public static List<Presentation> GetAllPresentations()
        {
            return DB.GetAll<Presentation>().ToList();
        }

        public static Presentation GetOnePresentation(int id)
        {
            return DB.Get<Presentation>(id);
        }
        // delete
        public static void DeletePresentation(int id)
        {
            Presentation pres = new Presentation() { id=id};
            DB.Delete(pres);
        }
        // create 
        public static Presentation CreatePresentation(Presentation pres)
        {
            DB.Insert(pres);
            return pres;
        }
        
        // edit
        public static void UpdatePresentation(Presentation pres)
        {
            DB.Update(pres);
        }


    }
}
