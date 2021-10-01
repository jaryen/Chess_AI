using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : BoardGeneration
{
    [SerializeField] public ArrayList validMoves = new ArrayList();   //stores all possible moves for this piece
    public bool taken = false;
    [SerializeField] public bool isWhite;

    protected BoardGeneration boardGeneration;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GameObject boardGeneratorGO = GameObject.Find("BoardGenerator");
        boardGeneration = boardGeneratorGO.GetComponent<BoardGeneration>();
    }

    //clears validMoves list
    public void clearMoves() {
        validMoves.Clear();
    }

    public bool checkOutOfBounds(int r, int c) {
        if (r < 0 || r > 7 || c < 0 || c > 7) {
            return false;
        }
        return true;
    }

    public void displayValidMoves() {
        Debug.Log("Valid moves: ");
        foreach (Tile tile in validMoves) {
            Debug.Log(tile.tile.GetInstanceID());
        }
    }

    public void HighlightSelectedPiece()
    {
        
    }

    public abstract void findMoves(Tile tile);

    //moves the piece to the selected square, return true if successful, else return false
    //public abstract bool moveToSquare(Tile dest);
    public bool moveToSquare(Tile dest)
    {
        foreach (Tile src in validMoves)
        {
            // If the current valid tile is equal to 
            // the destination tile
            if (src == dest)
            {
                dest.SetCurrentPiece(this);
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