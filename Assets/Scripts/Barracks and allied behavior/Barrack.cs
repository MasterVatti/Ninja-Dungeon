using System.Collections.Generic;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за бараки.(пока только сохраняет лист союзников)
    /// </summary>
    
    public class Barrack : MonoBehaviour
    {
        public List<AlliesListSetting> Allies => _allies;
        
        [SerializeField]
        private List<AlliesListSetting> _allies;
    }
}
