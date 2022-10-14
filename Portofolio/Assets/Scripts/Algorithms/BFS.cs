using System.Diagnostics;
using System.Collections.Generic;

public class BFS
{
    private static Grid grid;
    public static long ms = 0;

    public static int FindPath(Grid grid, Cell startingCell)
    {
        BFS.grid = grid;

        // DEBUG PURPOSES
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        HashSet<Cell> visitedSet = new HashSet<Cell>();
        Queue<Cell> openSet = new Queue<Cell>();

        visitedSet.Add(startingCell);
        openSet.Enqueue(startingCell);

        while (openSet.Count > 0)
        {
            Cell currentCell = openSet.Dequeue();
            if (currentCell.dEdges.Contains(edgeType))
            {
                stopwatch.Stop();
                ms = stopwatch.ElapsedMilliseconds;
                //UnityEngine.Debug.Log("Path Found: " + stopwatch.ElapsedMilliseconds + "ms");
                RetracePath(startingCell, currentCell);

                return CountPath(startingCell, currentCell);
            }

            foreach (Cell neighbour in grid.GetNeighbours(currentCell))
            {
                if (!neighbour.walkable)
                {
                    continue;
                }

                if (!visitedSet.Contains(neighbour))
                {
                    neighbour.parent = currentCell;

                    visitedSet.Add(neighbour);
                    openSet.Enqueue(neighbour);
                }
            }
        }

        stopwatch.Stop();
        UnityEngine.Debug.LogError("Path not Found: " + stopwatch.ElapsedMilliseconds + "ms");

        return 0;
    }

    public static int FindPath(Grid grid, Cell startingCell, Cell endingCell)
    {
        // DEBUG PURPOSES
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        HashSet<Cell> visitedSet = new HashSet<Cell>();
        Queue<Cell> openSet = new Queue<Cell>();

        visitedSet.Add(startingCell);
        openSet.Enqueue(startingCell);

        while (openSet.Count > 0)
        {
            Cell currentCell = openSet.Dequeue();
            if (currentCell == endingCell)
            {
                stopwatch.Stop();
                ms = stopwatch.ElapsedMilliseconds;
                //UnityEngine.Debug.Log("Path Found: " + stopwatch.ElapsedMilliseconds + "ms");
                RetracePath(startingCell, currentCell);
                return CountPath(startingCell, currentCell);
            }

            foreach (Cell neighbour in grid.GetNeighbours(currentCell))
            {
                if (!neighbour.walkable)
                {
                    continue;
                }

                if (!visitedSet.Contains(neighbour))
                {
                    neighbour.parent = currentCell;

                    visitedSet.Add(neighbour);
                    openSet.Enqueue(neighbour);
                }
            }
        }

        stopwatch.Stop();
        UnityEngine.Debug.LogError("Path not Found: " + stopwatch.ElapsedMilliseconds + "ms");

        return 0;
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
    }
}
