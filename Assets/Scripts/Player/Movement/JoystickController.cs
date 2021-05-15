using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// Этот класс отвечает за определение направления движения
/// с помощью виртуального джойстика
/// </summary>
public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private Image _joystickBorder;
    [SerializeField]
    private Image _joystickCircle;
    [SerializeField]
    private float _offset;

    private Vector2 _startPosition;
    public static Vector2 InputDirection { get; private set; }

    private void Start ()
    {
        _startPosition = _joystickBorder.transform.position;
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        MoveJoystickToTapPosition();
        OnDrag(eventData);
    }

    private void MoveJoystickToTapPosition ()
    {
        var position = Input.mousePosition;
        _joystickBorder.transform.position = position;
    }

    public void OnDrag (PointerEventData eventData)
    {
        var sizeDelta = _joystickBorder.rectTransform.rect.size;
        var backgroundImageSizeX = sizeDelta.x;
        var backgroundImageSizeY = sizeDelta.y;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBorder.rectTransform,
            eventData.position, eventData.pressEventCamera, out var position))
        {
            position.x /= backgroundImageSizeX;
            position.y /= backgroundImageSizeY;

            InputDirection = new Vector2(position.x, position.y).normalized;

            _joystickCircle.rectTransform.anchoredPosition = new
                Vector2(position.x * (backgroundImageSizeX / _offset),
                    position.y * (backgroundImageSizeY / _offset));
        }
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        ReturnJoystickToStartPosition();
    }

    private void ReturnJoystickToStartPosition ()
    {
        _joystickBorder.transform.position = _startPosition;
        _joystickCircle.rectTransform.anchoredPosition = Vector2.zero;
        InputDirection = Vector2.zero;
    }
}
