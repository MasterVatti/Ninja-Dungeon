using UnityEngine;

/// <summary>
/// Класс хранит в себе префаб и прогресс его перещения от начальной точки к конечной.
/// </summary>

public class AnimationInformation
{
    public GameObject PrefabResource;
    public Vector3 StartPoint;
    public Vector3 EndPoint;
    public float Progress;
}