using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine.UIElements;
using System.Security.Cryptography;

public class GameBoard : MonoBehaviour
{
    [SerializeField] Tile[] tilePrefab = default;
    [SerializeField] Vector2Int size; // Size of the grid
    
    public GameObject waypref;
    public GameObject straightWay;
    public GameObject cornerWay;
    public GameObject tWay;
    public TilePrefaps[] tilePrefebs;
    private GameObject castle;
    private Tile castleTile;
    private Tile[,] tiles; // 2D array to hold references to all tiles
    public GameObject castlePrefab;
    public GameObject pathPrefab;
    public GameObject startPrefab;
    public GameObject pathPointPrefab;
    public GameObject path1;
    public GameObject builder;
    private float timer = 0f;
    private float pathfindingInterval = 45f;
    public int pathcounter = 0;

    [System.Serializable]
    public class TilePrefaps
    {
        public Tile tileprefap;
        public bool notWalkable;
        public int size;
        public float weighting;
    }

    public void Initialize(Vector2Int psize)
    {
                       
        size = psize;
        
        tiles = new Tile[size.x, size.y];
        Vector3 offset = new Vector3((size.x - 1) * 0.5f, 0, (size.y - 1) * 0.5f);
        for (int y = 0; y < size.y; y++)
        {
 
            for (int x = 0; x < size.x; x++)
            {
                Tile tile;
                int cost = UnityEngine.Random.Range(0, 100);
                float totalWeight = 0;
                foreach (var tileprefap in tilePrefebs)
                {
                    totalWeight += tileprefap.weighting;
                }
                float randomValue = UnityEngine.Random.Range(0, totalWeight);
                float cumulativeWeight = 0;

                foreach (var tileprefap in tilePrefebs)
                {
                    int rotation = Random.Range(0, 4) * 90;
                    cumulativeWeight += tileprefap.weighting;
                    if (randomValue <= cumulativeWeight)
                    {
                        if (tileprefap.tileprefap!=null)
                        {
                            tile = Instantiate(tileprefap.tileprefap, transform.position+offset,Quaternion.Euler(0, rotation, 0),this.transform);
                                            tile.gameBoard = this;
                tile.setTcost(cost);
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = new Vector3(x - offset.x, 0f, y - offset.y);
                tile.SetPosition(x, y);
                tiles[x, y] = tile;
                            if(tileprefap.notWalkable)
                            {
                                tileprefap.notWalkable = false;
                            }
                        }
                        break;
                    }
                }

            }
        }

        PlaceCastle(); 
        SetNeighbors(size); 
        //FindPath(0,pathcounter);
        //pathcounter++;
        timer=40; 
    }


    void Update()
    {
 
            timer += Time.deltaTime;
            if (timer >= pathfindingInterval)
            {
                timer = 0f;
                FindPath(0.2f,pathcounter);
                pathcounter++;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                FindPath(0.2f,pathcounter);
                pathcounter++;
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
        selectedTile.isplacebel = false;
        selectedTile.gameObject.AddComponent<Castle_empty>();
        // Instantiate the castle prefab at the selected tile's position
        GameObject castle1 = Instantiate(castlePrefab, selectedTile.transform.position, Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
        castle1.transform.SetParent(selectedTile.transform);
        castle = castle1;
        //Instantiate(builder, selectedTile.transform.position+new Vector3(2f,0.2f,-2f), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
        //Destroy(selectedTile.GetComponent<MyClickableObject>());
    }
    public void FindPath(float timeinterval,int pathcounter)
    {
        AStarPathfinding pathfinding = GetComponent<AStarPathfinding>();
        if (pathfinding == null)
        {
            Debug.LogError("AStarPathfinding component is not attached to the game object!");
            return;
        }
        Tile startTile = CreateStart();
        List<Tile> path = pathfinding.FindPath(startTile, castleTile);
        int counter = 0;
        while (path == null && counter < 100)
        {
            startTile = CreateStart();
            path = pathfinding.FindPath(startTile, castleTile);
            counter++;
        }
        if (path != null)
        {
            path1 = new GameObject("Path");
            Path pathComponent = path1.AddComponent<Path>();  // Initialize with the exact count
            path1.AddComponent<PathBuilder>();
            PathBuilder pb = path1.GetComponent<PathBuilder>();
            pb.pathList = path;
            pb.straightWay = straightWay;
            pb.cornerWay = cornerWay;
            pb.startTiel = startTile;
            pb.endTile = castleTile;
            pb.startPrefab = startPrefab;
            pb.gameBoard = this;
            pb.timeinterval = timeinterval;
            if (timeinterval == 0)
                //InitializeStart(startTile, path1);
            Debug.Log("Path found! Length: " + path.Count + " tiles.");
            foreach (Tile tile in path)
            {
                tile.isplacebel =false;
                GameObject pathPoint = Instantiate(pathPointPrefab, tile.transform.position+new Vector3(0f,0,0f), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
                if (pathPoint != null)
                {
                    pathPoint.transform.SetParent(path1.transform);
                    pathComponent.AddPoint(pathPoint.transform);
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
        //Debug.Log(edgeTile.gridPosition);
        return edgeTile;
    }

}
