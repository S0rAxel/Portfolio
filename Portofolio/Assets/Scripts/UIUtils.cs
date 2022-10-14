using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class UIUtils
{
    /// <summary>
    /// Cast a ray to test if Input.mousePosition is over any UI object in EventSystem.current.
    /// <returns>true if Input.mousePosition is over any UI object in EventSystem.current, false otherwise.</returns>
    /// </summary>
    public static bool IsPointerOverUIObject(EventSystem eventSystem = null, string tagName = null)
    {
        if (eventSystem == null) eventSystem = EventSystem.current;

        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        eventSystem.RaycastAll(pointerEventData, raycastResults);

        if (string.IsNullOrEmpty(tagName))
        {
            return raycastResults.Count > 0;
        }
        else
        {
            foreach (RaycastResult result in raycastResults)
            {
                if (result.gameObject.tag.Equals(tagName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
