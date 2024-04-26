using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Database_Project
{
    internal class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("FirstName")]
        public String Name { get; set; }

        [BsonElement("LastName")]
        public String Surname { get; set; }

        [BsonElement("phone")]
        public String Phone { get; set; }

        [BsonElement("email")]
        public String Email { get; set; }

        [BsonElement("birth_year")]
        public Int32 Birth_Year { get; set; }

        [BsonElement("major")]
        public String Major { get; set; }

        public Student(string name, string surname, string phone, string email, int birth_Year, string major)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
            Birth_Year = birth_Year;
            Major = major;
        }
    }
}
