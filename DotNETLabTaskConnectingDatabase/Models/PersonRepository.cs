using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DotNETLabTaskConnectingDatabase.Models
{
    public class PersonRepository
    {
        DataAccess data;

        public PersonRepository()
        {
            data = new DataAccess();
        }

        public List<Person> GetAll()
        {
            string sql = "SELECT * FROM Persons";
            SqlDataReader reader = data.GetData(sql);
            List<Person> personList = new List<Person>();

            while (reader.Read())
            {
                Person p = new Person();
                p.ID = Convert.ToInt32(reader["id"]);
                p.Name = reader["name"].ToString();
                p.Email = reader["email"].ToString();
                personList.Add(p);
            }

            return personList;
        }

        public Person GetDetails(int id)
        {
            string sql = "SELECT * FROM Persons WHERE id = " + id + ";";
            SqlDataReader reader = data.GetData(sql);

            Person p = new Person();
            //List<Person> personList = new List<Person>();

            /*while (reader.Read())
            {
                Person p = new Person();
                p.ID = Convert.ToInt32(reader["id"]);
                p.Name = reader["name"].ToString();
                p.Email = reader["email"].ToString();
                personList.Add(p);
            }*/

            if (reader.Read())
            {
                p.ID = Convert.ToInt32(reader["id"]);
                p.Name = reader["name"].ToString();
                p.Email = reader["email"].ToString();
                //personList.Add(p);
            }

            //return personList;
            return p;
        }
        public int Update(Person per)
        {
            string sql = "UPDATE Persons SET name='" + per.Name + "', email='" + per.Email + "' WHERE id = " + per.ID + ";";
            return data.ExecuteQuery(sql);
        }
    }
}