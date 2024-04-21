using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinding : MonoBehaviour
{
    public Tile[,] tiles; // 2D array to hold the grid of tiles
    public int gridWidth;
    public int gridHeight;

    public Tile startTile;
    public Tile endTile;

public List<Tile> FindPath(Tile start, Tile end)
{
    if (start == null || end == null)
    {
        Debug.LogError("Start or end tile is null.");
        return null;
    }

    List<Tile> openList = new List<Tile>();
    HashSet<Tile> closedList = new HashSet<Tile>();
    start.gCost = 0;
    start.hCost = CalculateHeuristicCost(start, end);
    start.CalculateFCost();
    openList.Add(start);

    while (openList.Count > 0)
    {
        Tile currentTile = GetLowestFCostTile(openList);
        
        if (currentTile == end)
        {
            return RetracePath(start, currentTile);
        }

        openList.Remove(currentTile);
        closedList.Add(currentTile);

        foreach (Tile neighbor in GetNeighboringTiles(currentTile))
        {
            if (!neighbor.isWalkable || closedList.Contains(neighbor))
            {
                continue;
            }

            int tentativeGCost = currentTile.gCost + neighbor.tCost + CalculateHeuristicCost(currentTile, neighbor);
            if (tentativeGCost < neighbor.gCost || !openList.Contains(neighbor))
            {
                neighbor.gCost = tentativeGCost;
                neighbor.hCost = CalculateHeuristicCost(neighbor, end);
                neighbor.parent = currentTile;
                neighbor.CalculateFCost();

                if (!openList.Contains(neighbor))
                {
                    openList.Add(neighbor);
                }
            }
        }
    }

    Debug.LogError("No path found.");
    return null; // No path found
}

private Tile GetLowestFCostTile(List<Tile> openList)
{
    Tile lowestFCostTile = openList[0];
    foreach (Tile tile in openList)
    {
        if (tile.fCost < lowestFCostTile.fCost)
        {
            lowestFCostTile = tile;
        }
    }
    return lowestFCostTile;
}




    private List<Tile> RetracePath(Tile startTile, Tile endTile)
    {
        List<Tile> path = new List<Tile>();
        Tile currentTile = endTile;
        while (currentTile != startTile)
        {
            path.Add(currentTile);
            currentTile = currentTile.parent;
        }
        path.Reverse();
        return path;
    }


    private List<Tile> GetNeighboringTiles(Tile tile)
    {
        List<Tile> neighbors = tile.neighbors;
        return neighbors;
    }

    private int CalculateHeuristicCost(Tile a, Tile b)
    {
    int xDistance = Mathf.Abs(a.gridPosition.x - b.gridPosition.x);
    int yDistance = Mathf.Abs(a.gridPosition.y - b.gridPosition.y);
    int terrainFactor = a.tCost; // Adjust based on terrain
    return (xDistance + yDistance) * terrainFactor;
    }

    private int CalculateDistanceCost(Tile a, Tile b)
    {
        int xDistance = Mathf.Abs(a.gridPosition.x - b.gridPosition.x);
        int yDistance = Mathf.Abs(a.gridPosition.y - b.gridPosition.y);
        return xDistance + yDistance; // Assuming non-diagonal movement only
    }
}
