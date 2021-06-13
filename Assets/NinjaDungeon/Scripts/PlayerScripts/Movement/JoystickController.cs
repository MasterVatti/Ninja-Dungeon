using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PlayerScripts.Movement
{
    /// <summary>
    /// Этот класс отвечает за определение направления движения
    /// с помощью виртуального джойстика
    /// </summary>
    public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action OnJoystickDown;

        public Vector2 InputDirection { get; private set; }

        [SerializeField]
        private Image _joystickBorder;

        [SerializeField]
        private Image _joystickCircle;

        [SerializeField]
        private float _offset;

        private Vector2 _startPosition;

        private void Start()
        {
            _startPosition = _joystickBorder.transform.position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnJoystickDown?.Invoke();
            MoveJoystickToTapPosition();
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBorder.rectTransform,
                eventData.position, eventData.pressEventCamera, out var position);

            var size = _joystickBorder.rectTransform.rect.size;
            var backgroundImageSizeX = size.x;
            var backgroundImageSizeY = size.y;

            position.x /= backgroundImageSizeX;
            position.y /= backgroundImageSizeY;

            InputDirection = new Vector2(position.x, position.y).normalized;

            _joystickCircle.rectTransform.anchoredPosition = new
                Vector2(position.x * (backgroundImageSizeX / _offset),
                    position.y * (backgroundImageSizeY / _offset));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ReturnJoystickToStartPosition();
            InputDirection = Vector2.zero;
        }
        
        private void MoveJoystickToTapPosition()
        {
            var position = Input.mousePosition;
            _joystickBorder.transform.position = position;
        }

        private void ReturnJoystickToStartPosition()
        {
            _joystickBorder.transform.position = _startPosition;
            _joystickCircle.rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}