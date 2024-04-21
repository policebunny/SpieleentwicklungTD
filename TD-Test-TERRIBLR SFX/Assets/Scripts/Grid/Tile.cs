using UnityEngine;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    public Vector2Int gridPosition;
    public bool isWalkable = true;
    public int gCost; 
    public int hCost; 
    public int fCost; 
    public Tile parent;
    public int tCost = 1;

    public List<Tile> neighbors = new List<Tile>(); // List to store references to neighboring tiles

    public List<Tile> Neighbors => neighbors; // Public accessor for neighbors


    public void Start()
    {
       //gCost = UnityEngine.Random.Range(0, 50);
       tCost = UnityEngine.Random.Range(0, 50);
       if(tCost>30){
           isWalkable = false;
       }
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void SetPosition(int x, int y)
    {
        gridPosition = new Vector2Int(x, y);
    }

    // Method to add a neighbor tile
    public void AddNeighbor(Tile neighbor)
    {
        if (!neighbors.Contains(neighbor))
        {
            //Debug.Log("Adding neighbor " + neighbor.gridPosition + " to " + gridPosition);
            neighbors.Add(neighbor);
        }
    }
}
