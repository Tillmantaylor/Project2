using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public class DbPersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;
        public DbPersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Person Create(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            var personToDelete = Read(id);
            _db.People.Remove(personToDelete);
            _db.SaveChanges();
        }

        public Person Read(int id)
        {
            return _db.People.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Person> ReadAll()
        {
            return _db.People
                .ToList();
        }

        public ICollection<Person> ReadAllProjId(int projectId)
        {
            return _db.People.AsEnumerable().Where(person => person.ProjectRoles.Where(project => project.ProjectId != projectId) != null)
                .ToList();
        }

        public void Update(int oldId, Person person)
        {
            var personToUpdate = Read(oldId);
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.MiddleName = person.MiddleName;
            personToUpdate.Lastname = person.Lastname;
            personToUpdate.Email = person.Email;
            _db.SaveChanges();
        }

        public void AddProjectRoles(ProjectRole projectRole, int id)
        {
            var personToUpdate = Read(id);
            _db.ProjectRoles.Add(projectRole);
            personToUpdate.ProjectRoles.Add(projectRole);
            _db.SaveChanges();
        }
    }
}
