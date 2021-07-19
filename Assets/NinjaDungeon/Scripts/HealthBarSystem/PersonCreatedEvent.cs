using System.Collections.Generic;
using Characteristics;
using SimpleEventBus.Events;

namespace NinjaDungeon.Scripts.HealthBarSystem
{
    public class GetAllPersonsEvent : EventBase
    {
        public List<Person> Persons = new List<Person>();
    }
    
    public class PersonCreatedEvent : EventBase
    {
        public Person Person { get; private set; }

        public PersonCreatedEvent(Person person)
        {
            Person = person;
        }
    }
}