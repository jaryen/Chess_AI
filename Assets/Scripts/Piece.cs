using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : BoardGeneration
{
    public ArrayList validMoves;   //stores all possible moves for this piece
    public bool taken = false;
    [SerializeField] public bool isWhite;
    [SerializeField] public int row;
    [SerializeField] public int col;

    protected BoardGeneration boardGeneration;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GameObject boardGeneratorGO = GameObject.Find("BoardGenerator");
        boardGeneration = boardGeneratorGO.GetComponent<BoardGeneration>();
    }

    //adds a valid move into the validMoves list
    public void addMove(GameObject square) {
        validMoves.Add(square);
    }

    //clears validMoves list
    public void clearMoves() {
        validMoves.Clear();
    }

    public virtual void findMoves()
    {
        // Find all valid moves for piece
    }

    //moves the piece to the selected square, return true if successful, else return false
    public bool moveToSquare(GameObject dest) 
    {
        Debug.Log("0");
        Debug.Log("# of Valid Moves: " + validMoves.Count.ToString());
        foreach (GameObject i in validMoves) 
        {
            Debug.Log("1");
            // If the current valid tile is equal to 
            // the destination tile
            if (i == dest)
            {
                Debug.Log("2");
                Tile currValidTile = i.GetComponent<Tile>();
                Tile destTile = dest.GetComponent<Tile>();

                // check to see if a piece would be taken with this move
                if (currValidTile.GetCurrentPiece() != null)
                {
                    Debug.Log("3");

                    Destroy(destTile.GetCurrentPiece());
                }
                else // move the piece
                {
                    Debug.Log("4");
                    destTile.SetCurrentPiece(this);
                }
                return true;
            }
        }
        
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
