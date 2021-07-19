using UnityEngine;

public class UIUtility
{
    public static Vector2 WorldToCanvasPosition(RectTransform parent, Transform attachPoint)
    {
        var worldPoint = attachPoint.transform.position;
        
        var screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPoint);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, screenPoint, null,
            out var localPoint);

        return localPoint;
    }
}