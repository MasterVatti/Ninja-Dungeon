using UnityEngine;

public class AfterBattleParticles : MonoBehaviour
{
    [SerializeField]
    private GameObject _particles;

    private void Awake()
    {
        _particles.SetActive(false);
        MainManager.BattleManager.IsLevelFinished += StartParticles;
    }

    private void StartParticles()
    {
        _particles.SetActive(true);
    }

    private void OnDestroy()
    {
        MainManager.BattleManager.IsLevelFinished -= StartParticles;
    }
}
