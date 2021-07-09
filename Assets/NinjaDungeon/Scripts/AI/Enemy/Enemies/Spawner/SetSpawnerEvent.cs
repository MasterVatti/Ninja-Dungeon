using SimpleEventBus.Events;

namespace Enemies.Spawner
{
    public class SetSpawnerEvent : EventBase
    {
        public SetSpawnerEvent(Spawner spawner)
        {
            Spawner = spawner;
        }
        
        public Spawner Spawner;
    }
}