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


    public void Awake()
    {
        
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void SetPosition(int x, int y)
    {
        gridPosition = new Vector2Int(x, y);
    }

    public void setTcost(int cost){
        tCost = cost;
        //spawnDeko(cost);

    }

    public void spawnDeko(int cost){
        switch(cost){
            case 67:
                Instantiate(gameBoard.dekoPrefeb[6].deco ,transform);
                break;
            case 12:
                Instantiate(gameBoard.dekoPrefeb[1].deco ,transform);
                break;
            case 27:
                Instantiate(gameBoard.dekoPrefeb[2].deco,transform);
                break;
            case 31:
                Instantiate(gameBoard.dekoPrefeb[3].deco,transform);
                break;
            case 42:
                Instantiate(gameBoard.dekoPrefeb[4].deco,transform);
                break;
            case 51:
                Instantiate(gameBoard.dekoPrefeb[5].deco,transform);
                break;  
            default:
                break;
        };
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
