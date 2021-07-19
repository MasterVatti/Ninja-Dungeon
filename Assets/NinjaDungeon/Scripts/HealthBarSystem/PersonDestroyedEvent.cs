using Characteristics;
using SimpleEventBus.Events;

namespace NinjaDungeon.Scripts.HealthBarSystem
{
    public class PersonDestroyedEvent : EventBase
    {
        public Person Person { get; private set; }

        public PersonDestroyedEvent(Person person)
        {
            Person = person;
        }
    }
}