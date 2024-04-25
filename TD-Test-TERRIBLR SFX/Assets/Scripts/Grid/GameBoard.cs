using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine.UIElements;

public class GameBoard : MonoBehaviour
{
    [SerializeField] Tile tilePrefab = default;
    [SerializeField] Vector2Int size; // Size of the grid
    private GameObject castle;
    private Tile castleTile;
    private Tile[,] tiles; // 2D array to hold references to all tiles
    public GameObject castlePrefab;
    public GameObject pathPrefab;
    public GameObject startPrefab;
    public GameObject pathPointPrefab;
    public GameObject path1;
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

        PlaceCastle(); // Function to place a castle on the board
        SetNeighbors(size); // Establish neighbors for each tile
        FindPath(); // Example of how to use the pathfinding
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FindPath();
        }
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
        castleTile = selectedTile;
        selectedTile.gameObject.AddComponent<Castle_empty>();
        selectedTile.GetComponent<Renderer>().material.color = Color.magenta;
        // Instantiate the castle prefab at the selected tile's position
        GameObject castle1 = Instantiate(castlePrefab, selectedTile.transform.position, Quaternion.identity);
        castle1.transform.SetParent(selectedTile.transform);
        castle = castle1;
        //Destroy(selectedTile.GetComponent<MyClickableObject>());
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
        Tile startTile = CreateStart();
        var path = pathfinding.FindPath(startTile, castleTile);
        int counter = 0;
        while (path == null && counter < 100)
        {
            startTile.GetComponent<Renderer>().material.color = Color.white;
            startTile = CreateStart();
            path = pathfinding.FindPath(CreateStart(), castleTile);
            counter++;
        }
        if (path != null)
        {
            path1 = new GameObject("Path");
            path1.AddComponent<Path>();
            path1.GetComponent<Path>().points = new Transform[path.Count];
            InitializeStart(startTile, path1);
            foreach (var tile in path)
            {
                // Do something with the path, e.g., highlight the tiles
                tile.GetComponent<Renderer>().material.color = Color.green;
                GameObject pathPoint = Instantiate(pathPointPrefab, tile.transform.position+new Vector3(0,1,0), Quaternion.identity);
            if (pathPoint != null)
                {
                    path1.GetComponent<Path>().AddPoint(pathPoint.transform);
                    pathPoint.transform.SetParent(path1.transform);
                }
                else
                {
                    Debug.LogError("Path point is null");
                }
            }
        }
        else
        {
            Debug.Log("No path found.");
        }
    }


    private void InitializeStart(Tile startTile, GameObject gamePath)
    {
        if (startTile == null)
        {
            Debug.LogError("InitializeStart: startTile is null.");
            return;
        }

        // Change the color of the starting tile
        Renderer tileRenderer = startTile.GetComponent<Renderer>();
        if (tileRenderer != null)
        {
            tileRenderer.material.color = Color.gray;
        }
        else
        {
            Debug.LogError("InitializeStart: Renderer component not found on startTile.");
        }

        // Instantiate the starting prefab at the position of the start tile
        GameObject spawn = Instantiate(startPrefab, startTile.transform.position, Quaternion.identity);
        if (spawn == null)
        {
            Debug.LogError("InitializeStart: Failed to instantiate startPrefab.");
            return;
        }

        // Get the EnemyWaveSpawner component
        EnemyWaveSpawner spawner = spawn.GetComponent<EnemyWaveSpawner>();
        if (spawner != null)
        {
            // Ensure the gamePath GameObject has a Path component
            Path pathComponent = gamePath.GetComponent<Path>();
            if (pathComponent != null)
            {
                spawner.thePath = pathComponent;
            }
            else
            {
                Debug.LogError("InitializeStart: Path component not found on gamePath GameObject.");
            }

            // Assign the castle component
            Debug.Log("Castle: " + castle);
            if (castle != null)
            {
                Castle castleComponent = castle.GetComponent<Castle>();
                if (castle != null)
                {
                    spawner.theCastle = castleComponent;
                    Debug.Log("Spawner Position: " + spawn.transform.position);
                    Debug.Log("Start Tile Position: " + startTile.transform.position);
                }
                else
                {
                    Debug.LogError("InitializeStart: Castle component not found on castle GameObject.");
                }
            }
            else
            {
                Debug.LogError("InitializeStart: castle GameObject is null.");
            }
        }
        else
        {
            Debug.LogError("InitializeStart: EnemyWaveSpawner component not found on spawn GameObject.");
        }

        // Set the parent of the spawn GameObject to be the startTile
        spawn.transform.SetParent(startTile.transform);
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
        return edgeTile;
    }
}
