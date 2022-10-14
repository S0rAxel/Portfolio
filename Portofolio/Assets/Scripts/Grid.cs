using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    [SerializeField] private Transform seeker;

    [SerializeField] private LayerMask unwakableMask;
    [SerializeField] private Vector2 gridWorldSize;
    [SerializeField] private float cellRadius;

    [SerializeField] private bool diagonality = false;

    [SerializeField] private bool onlyDisplayPath = false;

    private Cell[,] grid;

    private float cellDiameter;

    private int gridSizeX;
    private int gridSizeY;

    public bool Diagonality { get => diagonality; set => diagonality = value; }
    public bool OnlyDisplayPath { get => onlyDisplayPath; set => onlyDisplayPath = value; }

    public int MaxSize { get { return gridSizeX * gridSizeY; } }

    private void Start()
    {
        cellDiameter = cellRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / cellDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / cellDiameter);

        CreateGrid();
    }

    private void CreateGrid()
    {
        if (cellRadius <= 0) return;

        grid = new Cell[gridSizeX, gridSizeY];

        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 cellCenter = worldBottomLeft + Vector3.right * (x * cellDiameter + cellRadius) + Vector3.forward * (y * cellDiameter + cellRadius);
                bool walkable = !(Physics.CheckSphere(cellCenter, cellRadius, unwakableMask));

                grid[x, y] = new Cell(x, y, walkable, cellCenter);
            }
        }
    }

    public List<Cell> GetNeighbours(Cell cell)
    {
        List<Cell> neighbours = new List<Cell>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (diagonality)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }
                }
                else
                {
                    if (x == 0 && y == 0 || x == -1 && y == -1 || x == 1 && y == 1 || x == 1 && y == -1 || x == -1 && y == 1)
                    {
                        continue;
                    }
                }

                int checkX = cell.x + x;
                int checkY = cell.y + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY && grid[checkX, checkY] != null)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    public Cell CellFromWorldPosition(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }

    public List<Cell> path;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1.0f, gridWorldSize.y));

        if (onlyDisplayPath)
        {
            if (path != null)
            {
                foreach (Cell cell in path)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawCube(cell.worldPosition, Vector3.one * (cellDiameter - 0.1f));
                }
            }

        }
        else
        {
            if (grid != null)
            {
                Cell startingCellObject = CellFromWorldPosition(seeker.position);
                foreach (Cell cell in grid)
                {
                    Gizmos.color = (cell.walkable) ? Color.white : Color.red;
                    if (path != null)
                        if (path.Contains(cell))
                            Gizmos.color = Color.blue;
                    if (cell == startingCellObject) Gizmos.color = Color.green;
                    Gizmos.DrawCube(cell.worldPosition, Vector3.one * (cellDiameter - 0.1f));
                }
            }
        }
    }
}
