using UnityEngine;

public static class TransformExtensions
{
    public static bool HasComponent<T>(this Transform transform) where T : MonoBehaviour
    {
        return transform.GetComponent<T>() != null;
    }

    public static void DestroyChildren(this Transform transform)
    {
        foreach (Transform child in transform)
            GameObject.Destroy(child.gameObject);
    }

    public static void DestroyChildren(this Transform transform, string childToAvoid = "")
    {
        foreach (Transform child in transform)
        {
            if (child.name == childToAvoid) continue;
            GameObject.Destroy(child.gameObject);
        }
    }

    public static void DestroyChildrenOfType<T>(this Transform transform) where T : MonoBehaviour
    {
        foreach (Transform child in transform)
            if (child.HasComponent<T>())
                GameObject.Destroy(child.gameObject);
    }

    public static void DestroyChildrenExcept<T>(this Transform transform) where T : MonoBehaviour
    {
        foreach (Transform child in transform)
        {
            if (child.HasComponent<T>()) continue;
            GameObject.Destroy(child.gameObject);
        }
    }

    public static void DestroyChildrenWithTag(this Transform transform, string tag)
    {
        foreach (Transform child in transform)
            if (child.CompareTag(tag))
                GameObject.Destroy(child.gameObject);
    }

    public static void ResetTransform(this Transform transform)
    {
        transform.position = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}
