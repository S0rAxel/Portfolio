using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace UnityEngine.UI
{
    public class ToggleSwitch : Selectable
    {
        [Space(10)]
        [SerializeField] private bool isOn = false;

        [Space(10)]
        [SerializeField] private RectTransform toggleIndicator = null;
        [SerializeField] private Image background = null;
        [SerializeField] private Color onColor = Color.white;
        [SerializeField] private Color offColor = Color.white;
        [Space(5)]
        [SerializeField] private Image onImage = null;
        [SerializeField] private Image offImage = null;

        [Header("Audio")]
        [SerializeField] private AudioSource audioSource = null;

        [Header("Delay")]
        [Range(0.0f, 10.0f)]
        [SerializeField] private float tweenTime = 0.25f;

        [Space(20)]
        [SerializeField] private UnityEvent<bool> onValueChanged;
        [SerializeField] private UnityEvent<bool> onValueChangedNegative;

        private float offX;
        private float onX;

        public bool IsOn { get => isOn; }

        protected override void Start()
        {
            offX = toggleIndicator.anchoredPosition.x;
            onX = background.rectTransform.rect.width - toggleIndicator.rect.width - toggleIndicator.anchoredPosition.x;
        }

        protected override void OnEnable()
        {
            Toggle(IsOn);
        }

        private void Toggle(bool value)
        {
            if (value != isOn)
            {
                isOn = value;

                if (value)
                {
                    background.DOColor(onColor, tweenTime);
                    toggleIndicator.DOAnchorPosX(onX, tweenTime);
                }
                else
                {
                    background.DOColor(offColor, tweenTime);
                    toggleIndicator.DOAnchorPosX(offX, tweenTime);
                }

                if (audioSource != null)
                {
                    audioSource.Play();
                }

                onValueChanged?.Invoke(isOn);
                onValueChangedNegative?.Invoke(!isOn);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            Toggle(!isOn);
        }
    }
}