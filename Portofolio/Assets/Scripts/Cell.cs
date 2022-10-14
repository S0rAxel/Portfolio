using UnityEngine;
using DataStructures;

public class Cell : IHeapItem<Cell>
{
    public int x;
    public int y;

    public bool walkable;
    public Vector3 worldPosition;

    public Cell parent;

    private int heapIndex;

    public int gCost;
    public int hCost;

    public int fCost { get { return gCost + hCost; } }

    public int HeapIndex { get => heapIndex; set => heapIndex = value; }

    public Cell(int x, int y, bool walkable, Vector3 worldPosition)
    {
        this.x = x;
        this.y = y;
        this.walkable = walkable;
        this.worldPosition = worldPosition;
    }

    public int CompareTo(Cell cellToCompare)
    {
        int compare = fCost.CompareTo(cellToCompare.fCost);

        if (compare == 0)
        {
            compare = hCost.CompareTo(cellToCompare.hCost);
        }
        return -compare;
    }
}
