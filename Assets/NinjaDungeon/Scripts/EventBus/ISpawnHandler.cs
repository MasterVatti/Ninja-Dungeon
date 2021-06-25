using Enemies.Spawner;

namespace DefaultNamespace
{
    public interface ISpawnHandler : IGlobalSubscriber
    {
        void SetSpawner(Spawner spawner);
        void EndSpawn();
    }
}