using Characteristics;
using UnityEngine;

/// <summary>
/// Отвечает за общее представление Unita и за удобное соеденение модулей повидения.
/// </summary>
public class Unit : MonoBehaviour
{
    public ITargetProvider TargetProvider => _targetProvider;
    public MovementBehaviour Movement => _movement;
    public PersonCharacteristics Characteristics => _characteristics;

    [SerializeField]
    private MovementBehaviour _movement;
    [SerializeField]
    public PersonCharacteristics _characteristics;
    
    private ITargetProvider _targetProvider;

    private void Start()
    {
        _targetProvider = GetComponent<ITargetProvider>();
    }
}