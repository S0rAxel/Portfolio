using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Transform seeker;
    [SerializeField] private Transform target;

    private Grid grid;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    private void Update()
    {
        FindPath(seeker.position, target.position);
    }

    void FindPath(Vector3 startingPosition, Vector3 targetPosition)
    {
        Cell startingCell = grid.CellFromWorldPosition(startingPosition);
        Cell targetCell = grid.CellFromWorldPosition(targetPosition);

        AStar.FindPath(grid, startingCell, targetCell);
    }
}
