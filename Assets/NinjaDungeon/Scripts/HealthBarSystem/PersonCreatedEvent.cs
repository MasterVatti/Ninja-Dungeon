using Characteristics;
using SimpleEventBus.Events;

namespace NinjaDungeon.Scripts.HealthBarSystem
{ 
    public class PersonCreatedEvent : EventBase
    {
        public Person Person { get; private set; }

        public PersonCreatedEvent(Person person)
        {
            Person = person;
        }
    }
}