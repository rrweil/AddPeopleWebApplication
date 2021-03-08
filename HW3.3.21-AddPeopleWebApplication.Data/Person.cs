using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HW3._3._21_AddPeopleWebApplication.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public int Age { get; set;  }
    }

    public class PersonDb
    {
        private readonly string _connectionString;
        public PersonDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM People";
            var people = new List<Person>();
            connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["id"],
                    FirstName = (string)reader["Firstname"],
                    LastName = (string)reader["Lastname"],
                    Age = (int)reader["age"]
                });
            }
            return people;
        }

        public void AddPerson(Person person)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO People VALUES (@fname, @lname, @age)";
            cmd.Parameters.AddWithValue("@fname", person.FirstName);
            cmd.Parameters.AddWithValue("@lname", person.LastName);
            cmd.Parameters.AddWithValue("@age", person.Age);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
