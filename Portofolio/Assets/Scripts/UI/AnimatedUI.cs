using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnimatedUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private UnityEvent<GameObject> onClick;

    [Header("UI Behaviour")]
    [SerializeField] private Vector3 defaultScale = Vector3.one;
    [SerializeField] private float duration = 0.2f;

    [Header("On Pointer Enter")]
    [SerializeField] private float hoverScale = 1.1f;

    [Header("On Pointer Down")]
    [SerializeField] private Vector3 punchScale;

    [Header("On Pointer Exit")]


    [SerializeField] private Color normalColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color pressedColor;
    [SerializeField] private Color selectedColor;

    public void Start()
    {
        transform.localScale = defaultScale;
        GetComponent<Image>().color = normalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //transform.localScale = defaultScale;
        GetComponent<Image>().color = normalColor;

        transform.DOPunchScale(punchScale, duration);
        GetComponent<Image>().DOColor(pressedColor, duration / 2).SetLoops(2, LoopType.Yoyo);

        //GetComponent<Image>().color = selectedColor;

        onClick?.Invoke(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(hoverScale, duration);
        GetComponent<Image>().DOColor(hoverColor, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(defaultScale, duration);
        GetComponent<Image>().DOColor(normalColor, duration);

        //if (emojiBar.CurrentEmoji != gameObject)
        //{

        //    if (emojiBar.CurrentEmoji != null)
        //    {
        //    }
        //}
    }
}
