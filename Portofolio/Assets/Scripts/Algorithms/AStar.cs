using UnityEngine;
using DataStructures;
using System.Diagnostics;
using System.Collections.Generic;

public class AStar
{
    private static Grid grid;
    public static long ms = 0;

    public static int FindPath(Grid grid, Cell startingCell, Cell targetCell)
    {
        AStar.grid = grid;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Heap<Cell> openSet = new Heap<Cell>(grid.MaxSize);
        HashSet<Cell> closedSet = new HashSet<Cell>();

        openSet.Clear();
        closedSet.Clear();

        openSet.Add(startingCell);
        while (openSet.Count > 0)
        {
            Cell currentCell = openSet.RemoveFirst();
            closedSet.Add(currentCell);

            if (currentCell == targetCell)
            {
                stopwatch.Stop();
                UnityEngine.Debug.Log("Path Found: " + stopwatch.ElapsedMilliseconds + "ms");
                ms = stopwatch.ElapsedMilliseconds;
                RetracePath(startingCell, targetCell);

                return CountPath(startingCell, targetCell);
            }

            foreach (Cell neighbour in grid.GetNeighbours(currentCell))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int costToNeighbour = currentCell.gCost + GetDistances(currentCell, neighbour);
                if (costToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = costToNeighbour;
                    neighbour.hCost = GetDistances(neighbour, targetCell);
                    neighbour.parent = currentCell;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log("Path not Found: " + stopwatch.ElapsedMilliseconds + "ms");

        return 0;
    }

    private static void RetracePath(Cell startingCell, Cell endingCell)
    {
        List<Cell> path = new List<Cell>();
        Cell currentCell = endingCell;

        while (currentCell != startingCell)
        {
            path.Add(currentCell);
            currentCell = currentCell.parent;
        }
        path.Reverse();

        grid.path = path;
        //grid.TracePath(path);
    }

    private static int CountPath(Cell startingCell, Cell endingCell)
    {
        int pathCount = 0;
        Cell currentCell = endingCell;

        while (currentCell != startingCell)
        {
            pathCount++;
            currentCell = currentCell.parent;
        }

        return pathCount;
    }

    private static int GetDistances(Cell cellA, Cell cellB)
    {
        int distanceX = Mathf.Abs(cellA.x - cellB.x);
        int distanceY = Mathf.Abs(cellA.y - cellB.y);

        if (grid.Diagonality)
        {
            if (distanceX > distanceY)
            {
                return 14 * distanceY + 10 * (distanceX - distanceY);
            }
            else
            {
                return 14 * distanceX + 10 * (distanceY - distanceX);
            }
        }

        return 10 * Mathf.Abs(distanceX - distanceY);
    }
}
