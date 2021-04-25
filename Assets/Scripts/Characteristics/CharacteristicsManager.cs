using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// управление характеристиками
    /// </summary>
    public class CharacteristicsManager : MonoBehaviour
    {
        [SerializeField] 
        private List<Characteristic<>> _characteristics;
    }
}
