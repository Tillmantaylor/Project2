using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public interface IPersonRepository
    {
        ICollection<Person> ReadAll();
        Person Create(Person person);
        Person Read(int id);
        void Update(int oldId, Person person);
        void Delete(int id);
    }
}
