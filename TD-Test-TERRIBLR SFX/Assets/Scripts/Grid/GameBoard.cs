using UnityEngine;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour
{
    [SerializeField] Tile tilePrefab = default;
    [SerializeField] Vector2Int size; // Size of the grid
    private Tile castle;
    private Tile[,] tiles; // 2D array to hold references to all tiles

    public void Initialize(Vector2Int psize)
    {
        size = psize;
        tiles = new Tile[size.x, size.y];
        Vector2 offset = new Vector2((size.x - 1) * 0.5f, (size.y - 1) * 0.5f);
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                Tile tile = Instantiate(tilePrefab);
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = new Vector3(x - offset.x, 0f, y - offset.y);
                tile.SetPosition(x, y);
                tiles[x, y] = tile;
            }
        }

        SetNeighbors(size); // Establish neighbors for each tile
        PlaceCastle(); // Function to place a castle on the board
        FindPath(); // Example of how to use the pathfinding
    }

    private void SetNeighbors(Vector2Int gridSize)
    {
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                //Debug.Log("Setting neighbors for tile at " + x + ", " + y);
                Tile currentTile = tiles[x, y];
                if (x > 0) currentTile.AddNeighbor(tiles[x - 1, y]);
                if (x < gridSize.x - 1) currentTile.AddNeighbor(tiles[x + 1, y]);
                if (y > 0) currentTile.AddNeighbor(tiles[x, y - 1]);
                if (y < gridSize.y - 1) currentTile.AddNeighbor(tiles[x, y + 1]);
            }
        }
    }
    private void PlaceCastle()
    {
        int randomX = Random.Range(size.x / 3, 2 * size.x / 3); // Select a random X within the middle third
        int randomY = Random.Range(size.y / 3, 2 * size.y / 3); // Select a random Y within the middle third
        Tile selectedTile = transform.GetChild(randomX + randomY * size.x).GetComponent<Tile>(); // Get the tile at the random position
        castle = selectedTile;
        selectedTile.gameObject.AddComponent<Castle_empty>();
        selectedTile.GetComponent<Renderer>().material.color = Color.magenta;
        Destroy(selectedTile.GetComponent<MyClickableObject>());
    }
 public void FindPath()
    {
        // Ensure the AStarPathfinding component is attached and properly set up
        AStarPathfinding pathfinding = GetComponent<AStarPathfinding>();
        if (pathfinding == null)
        {
            Debug.LogError("AStarPathfinding component is not attached to the game object!");
            return;
        }

        var path = pathfinding.FindPath(CreateStart(), castle);
        if (path != null)
        {
            foreach (var tile in path)
            {
                // Do something with the path, e.g., highlight the tiles
                tile.GetComponent<Renderer>().material.color = Color.green;
            }
        }
        else
        {
            Debug.Log("No path found.");
        }
    }
        private Tile CreateStart()
    {
        // Create a Path_temp from the center to the edge
        // Select a random edge tile
        Tile edgeTile = null;
        while (edgeTile == null)
        {
            int edge = Random.Range(0, 4); // Select a random edge (0 = left, 1 = right, 2 = bottom, 3 = top)
            switch (edge)
            {
                case 0: // Left edge
                    edgeTile = transform.GetChild(Random.Range(0, size.y) * size.x).GetComponent<Tile>();
                    break;
                case 1: // Right edge
                    edgeTile = transform.GetChild((Random.Range(0, size.y) + 1) * size.x - 1).GetComponent<Tile>();
                    break;
                case 2: // Bottom edge
                    edgeTile = transform.GetChild(Random.Range(0, size.x)).GetComponent<Tile>();
                    break;
                case 3: // Top edge
                    edgeTile = transform.GetChild((size.y - 1) * size.x + Random.Range(0, size.x)).GetComponent<Tile>();
                    break;
            }
        }
        Debug.Log(edgeTile.gridPosition);
        edgeTile.GetComponent<Renderer>().material.color = Color.gray; // Color the edge tile gray
        edgeTile.gameObject.AddComponent<Path_temp>(); // Add Path_temp to the edge tile
        return edgeTile;
    }
}
