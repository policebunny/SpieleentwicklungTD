using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class Tile : MonoBehaviour
{
    public Vector2Int gridPosition;
    public bool isWalkable = true;
    public GameBoard gameBoard;

    public int gCost;
    public int hCost;
    public int fCost;
    public Tile parent;
    public int tCost = 1;

    public List<Tile> neighbors = new List<Tile>(); // List to store references to neighboring tiles

    public List<Tile> Neighbors => neighbors; // Public accessor for neighbors

    private Vector3 offset = new Vector3(-0.5f,0,-0.5f);
    public void Start()
    {
        transform.localPosition += new Vector3(-0.5f, 0, -0.5f);
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void SetPosition(int x, int y)
    {
        gridPosition = new Vector2Int(x, y);
    }

    public void setTcost(int cost)
    {
        tCost = cost;

    }



    // Method to add a neighbor tile
    public void AddNeighbor(Tile neighbor)
    {
        if (!neighbors.Contains(neighbor) && neighbor.isWalkable)
        {
            neighbors.Add(neighbor);
        }
    }
}
