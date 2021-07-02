using UnityEngine;

public class AfterBattleParticles : MonoBehaviour
{
    [SerializeField]
    private GameObject _particles;

    private void Awake()
    {
        _particles.SetActive(false);
        DungeonManager.BattleManager.IsLevelFinished += StartParticles;
    }

    private void StartParticles()
    {
        _particles.SetActive(true);
    }

    private void OnDestroy()
    {
        DungeonManager.BattleManager.IsLevelFinished -= StartParticles;
    }
}
