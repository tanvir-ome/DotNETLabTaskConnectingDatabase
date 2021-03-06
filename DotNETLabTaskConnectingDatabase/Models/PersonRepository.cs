﻿using System;
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
        public int Update(Person p)
        {
            string sql = "UPDATE Persons SET name='" + p.Name + "', email='" + p.Email + "' WHERE id = " + p.ID + ";";
            return data.ExecuteQuery(sql);
        }

        public int InsertData(Person p)
        {
            int id=0;
            string sql = "INSERT INTO Persons (name, email) values ('"+p.Name+"', '"+p.Email+"');";
            data.ExecuteQuery(sql);
            
            sql = "SELECT id FROM Persons WHERE email = '"+p.Email+"';";

            SqlDataReader reader = data.GetData(sql);

            if (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
            }
            return id;
        }

        public int DeleteData(int id)
        {
            string sql = "DELETE FROM Persons WHERE id = "+id+";";
            return data.ExecuteQuery(sql);
        }
    }
}