using Characteristics;
using UnityEngine;

namespace NinjaDungeon.Scripts.BattleManager.LevelLogic
{
    public class DoorOpener : MonoBehaviour
    {
        [SerializeField]
        private int _requiredLevel;
        [SerializeField]
        private BoxCollider _boxCollider;
        
        private void Start()
        {
            var playerCharacteristics = (PlayerCharacteristics) MainManager.Player.PersonCharacteristics;
            if (playerCharacteristics.LevelUpperWorld < _requiredLevel)
            {
                _boxCollider.isTrigger = false;
            }
        }
    }
}
