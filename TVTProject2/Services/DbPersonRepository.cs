////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Project:        Project2
//  File Name:      TVTProject2.cs
//  Description:    Project Manager
//  Course:         CSCI-3110-001
//  Author:         Taylor Tillman, tillmant@etsu.edu
//  Created:        Saturday, November 6, 2021
//  Copyright:      Taylor Tillman, 2021
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    /// <summary>
    /// Person Database
    /// </summary>
    public class DbPersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// attaching database
        /// </summary>
        public DbPersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Create a person in the database
        /// params - Person holding information to add a person
        /// </summary>
        public Person Create(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
            return person;
        }

        /// <summary>
        /// Deletes a person from the database
        /// params - id for person to delete
        /// </summary>
        public void Delete(int id)
        {
            var personToDelete = Read(id);
            _db.People.Remove(personToDelete);
            _db.SaveChanges();
        }

        /// <summary>
        /// Reads a person
        /// params - id of person you want to read
        /// </summary>
        public Person Read(int id)
        {
            return _db.People.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Reads all people
        /// </summary>
        public ICollection<Person> ReadAll()
        {
            return _db.People
                .ToList();
        }

        /// <summary>
        /// Updates a person in the database
        /// params - oldId of person being changed Person with the information needed to be added to database
        /// </summary>
        public void Update(int oldId, Person person)
        {
            var personToUpdate = Read(oldId);
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.MiddleName = person.MiddleName;
            personToUpdate.Lastname = person.Lastname;
            personToUpdate.Email = person.Email;
            _db.SaveChanges();
        }
    }
}
