using System.Collections;

namespace SaveSystem
{
    public interface IDataSaver<out T> where T : IEnumerable
    {
        T SaveData { get; }
        void Save();
    }
}
