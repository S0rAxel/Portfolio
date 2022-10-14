namespace UnityEngine.UI
{
    public class Tab : Toggle
    {
        [SerializeField] private int index;
        [SerializeField] private GameObject tab;

        public GameObject TabObject { get => tab; }
        public int Index { get => index; }
    }

}