using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// базовый класс для всех характеристик
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Characteristic<T> : MonoBehaviour
    {
        protected abstract void Increase(T increasable);
        protected abstract void Decrease(T decreasable);
    }
}
