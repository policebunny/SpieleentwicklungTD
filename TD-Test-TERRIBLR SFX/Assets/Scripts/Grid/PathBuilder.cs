using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PathBuilder : MonoBehaviour
{
    public GameBoard gameBoard;
    public GameObject straightWay;
    public GameObject cornerWay;
    public GameObject tWay;
    public Tile startTiel;
    public Tile endTile;
    public GameObject startPrefab;
    public float timer = 0.1f;
    public float timeinterval =0.2f;
    int pathPointer = 0;
    public List<Tile> pathList;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (pathPointer == 0)
            {
                buildPath(startTiel,pathList[pathPointer], pathList[pathPointer + 1]);
                pathPointer++;
                timer = timeinterval;
            }
            else if (pathPointer < pathList.Count-1)
            {
                buildPath(pathList[pathPointer - 1], pathList[pathPointer], pathList[pathPointer + 1]);
                pathPointer++;
                timer = timeinterval;
            }else if (pathPointer == pathList.Count-1)
            {
                Debug.Log("END");
                buildPath(pathList[pathPointer - 1], pathList[pathPointer],endTile);
                InitializeStart(startTiel,gameBoard.path1);
                this.enabled = false;
            }
        }
    }

    private void buildPath(Tile prefTile, Tile thisTile, Tile nextTile)
    {
        Vector3 direction = prefTile.transform.position - nextTile.transform.position;
        Vector3 directionpref = thisTile.transform.position - prefTile.transform.position;
        Vector3 directionnext = thisTile.transform.position - nextTile.transform.position;
        Vector3 scale = new Vector3(5,5,5);
        //Debug.Log(direction);
        // Delete all child objects of thisTile
        foreach (Transform child in thisTile.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        if (direction == new Vector3(0, 0, 2) || direction == new Vector3(0, 0, -2))
        {
            GameObject newWay = GameObject.Instantiate(straightWay, thisTile.transform.position + new Vector3(-0f,0.025f,-1), Quaternion.Euler(0, 0, 0));
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        else if (direction == new Vector3(2, 0, 0) || direction == new Vector3(-2, 0, 0))
        {
            GameObject newWay = GameObject.Instantiate(straightWay, thisTile.transform.position + new Vector3(-1,0.025f,-1f), Quaternion.Euler(0, 90, 0));
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        else if (directionnext == new Vector3(1, 0, 0) && directionpref == new Vector3(0, 0, 1))
        {
            GameObject newWay = GameObject.Instantiate(cornerWay, thisTile.transform.position + new Vector3(-0f,0.025f,-1f), Quaternion.Euler(0, 0, 0));
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        else if (directionnext == new Vector3(1, 0, 0) && directionpref == new Vector3(0, 0, -1))
        {
            GameObject newWay = GameObject.Instantiate(cornerWay, thisTile.transform.position + new Vector3(-1f,0.025f,-1f), Quaternion.Euler(0, 90, 0));//-----------
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        else if (directionnext == new Vector3(-1, 0, 0) && directionpref == new Vector3(0, 0, 1))
        {
            GameObject newWay = GameObject.Instantiate(cornerWay, thisTile.transform.position + new Vector3(-0f,0.025f,0f), Quaternion.Euler(0, 270, 0));
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        else if (directionnext == new Vector3(-1, 0, 0) && directionpref == new Vector3(0, 0, -1))
        {
            GameObject newWay = GameObject.Instantiate(cornerWay, thisTile.transform.position + new Vector3(-1f,0.025f,0f), Quaternion.Euler(0, 180, 0));//----
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        } 
        else if (directionnext == new Vector3(0, 0, 1) && directionpref == new Vector3(1, 0, 0))
        {
            GameObject newWay = GameObject.Instantiate(cornerWay, thisTile.transform.position + new Vector3(-0f,0.025f,-1f), Quaternion.Euler(0, 0, 0));
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        else if (directionnext == new Vector3(0, 0, 1) && directionpref == new Vector3(-1, 0, 0))
        {
            GameObject newWay = GameObject.Instantiate(cornerWay, thisTile.transform.position + new Vector3(-0f,0.025f,-0f), Quaternion.Euler(0, 270, 0));
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        else if (directionnext == new Vector3(0, 0, -1) && directionpref == new Vector3(1, 0, 0))
        {
            GameObject newWay = GameObject.Instantiate(cornerWay, thisTile.transform.position + new Vector3(-1f,0.025f,-1f), Quaternion.Euler(0, 90, 0));//-----
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        else if (directionnext == new Vector3(0, 0, -1) && directionpref == new Vector3(-1, 0, 0))
        {
            GameObject newWay = GameObject.Instantiate(cornerWay, thisTile.transform.position + new Vector3(-1f,0.025f,0f), Quaternion.Euler(0, 180, 0));//-----
            newWay.transform.SetParent(thisTile.transform);
            newWay.transform.localScale = scale;
        }
        thisTile.GetComponent<Renderer>().material.color = Color.blue;
    }


    public void InitializeStart(Tile startTile, GameObject gamePath)
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
        GameObject spawn = Instantiate(startPrefab, startTile.transform.position+new Vector3(-0.5f,0,-0.5f), Quaternion.identity);
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
            Debug.Log("Castle: " + endTile);
                Castle castleComponent = endTile.GetComponent<Castle>();
                if (endTile != null)
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
            Debug.LogError("InitializeStart: EnemyWaveSpawner component not found on spawn GameObject.");
        }

        // Set the parent of the spawn GameObject to be the startTile
        spawn.transform.SetParent(startTile.transform);
    }
}
