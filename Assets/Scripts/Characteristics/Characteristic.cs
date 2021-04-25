using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// базовый класс для всех характеристик
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Characteristic : MonoBehaviour
    {
        protected abstract void Increase<T>(T increasable);

        protected abstract void Decrease<T>(T decreasable);
    }
}
