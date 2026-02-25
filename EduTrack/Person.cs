using System;

namespace EduTrack
{
    public abstract class Person
    {
     
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }

        protected Person(int id, string name, string email)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email format.");

            Id = id;
            Name = name;
            Email = email;
        }

        protected bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return email.Contains("@") && email.Contains(".");
        }

        
        public virtual string GetBasicInfo()
        {
            return $"ID: {Id}, Name: {Name}, Email: {Email}";
        }
    }
}