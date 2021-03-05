using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Класс содержит методы, которые нужно выполнить по окончанию строительства:
    /// разблокирует новые места для строительства
    /// разблокирует построенное здание
    /// </summary>
    public class BuildFinisher : MonoBehaviour
    {
        public static void CreatePlaceHolders ([CanBeNull] IEnumerable<GameObject> placeHolders)
        {
            if(placeHolders != null)
            {
                foreach (var placeHolder in placeHolders)
                {
                    Instantiate(placeHolder, placeHolder.transform.position, Quaternion.identity);
                }
            }
        }

        public static void CreateBuilding (GameObject building)
        {
            Instantiate(building, building.transform.position, Quaternion.identity);
        }
    }
}
