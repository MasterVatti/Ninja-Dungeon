using TMPro;
using UnityEngine;

/// <summary>
/// Класс для базовых виджетов
/// </summary>
public class BuildingInfoView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameBuilding;

    private Transform _attachPoint;
    private RectTransform _parent;
    private RectTransform _currentTransform;
    private bool _isInitialized;

    private void Awake()
    {
        _currentTransform = transform as RectTransform;
        _parent = transform.parent as RectTransform;
    }

    private void ShowNameBuilding(string nameBuilding)
    {
        _nameBuilding.text = nameBuilding;
    }
    
    public virtual void Initialize(GameObject building, Transform uiAttachPoint, string nameBuilding)
    {
        _attachPoint = uiAttachPoint;
        ShowNameBuilding(nameBuilding);
        _isInitialized = true;
        UpdateViewPosition(_attachPoint);
    }

    protected virtual void Update()
    {
        if (_attachPoint != null)
        {
            UpdateViewPosition(_attachPoint);
        }
        else if (_isInitialized)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateViewPosition(Transform attachPoint)
    {
        var worldPoint = attachPoint.transform.position;
        
        var screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPoint);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parent, screenPoint, null,
            out var localPoint);
        _currentTransform.anchoredPosition = localPoint;
    }
}
