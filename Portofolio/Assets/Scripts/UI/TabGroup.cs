namespace UnityEngine.UI
{
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] private System.Collections.Generic.List<Tab> tabsList;

        private Tab currentTab;

        private int currentIndex;

        public Tab CurrentTab { get => currentTab; }

        private void Start()
        {

        }

        public void TabToggle(Tab tab)
        {
            Input.ResetInputAxes();
            if (tab != currentTab)
            {
                for (int i = 0; i < tabsList.Count; i++)
                {
                    if (tabsList[i].TabObject != null)
                    {
                        tabsList[i].TabObject.SetActive(tab.Index == i); 
                    }
                }

                currentIndex = tab.Index;
                currentTab = tab;
            }
        }

        public void TabToggle(int position)
        {
            Input.ResetInputAxes();
            if (position != currentIndex)
            {
                for (int i = 0; i < tabsList.Count; i++)
                {
                    tabsList[i].TabObject.SetActive(position == i);
                }

                currentIndex = position;
                currentTab = tabsList[currentIndex];
            }
        }

    }
}