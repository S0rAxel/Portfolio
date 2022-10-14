using UnityEngine;
using TMPro;

public class PathFindingUI : MonoBehaviour
{
    [SerializeField] private Grid grid;

    [SerializeField] private TMP_Text pathCount;
    [SerializeField] private TMP_Text ms;

    public void Diagonality(bool value)
    {
        grid.Diagonality = value;
    }

    public void DisplayPathOnly(bool value)
    {
        grid.OnlyDisplayPath = value;
    }

    public void Update()
    {
        pathCount.text = grid.path.Count.ToString();
        ms.text = AStar.ms.ToString() + "ms";
    }
}
