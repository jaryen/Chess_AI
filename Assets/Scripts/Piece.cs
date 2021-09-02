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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //adds a valid move into the validMoves list
    public void addMove(GameObject square) {
        validMoves.Add(square);
    }

    //clears validMoves list
    public void clearMoves() {
        validMoves.Clear();
    }

    //moves the piece to the selected square, return true if successful, else return false
    public bool moveToSquare(GameObject dest) {
        Debug.Log("Called moveToSquare");
        foreach (GameObject i in validMoves) {
            if (i == dest) {
                if (i.GetComponent<Tile>().GetCurrentPiece() != null){  //check to see if a piece would be taken with this move
                    Destroy(dest.GetComponent<Tile>().GetCurrentPiece());
                }
                else{   //move the piece
                    dest.GetComponent<Tile>().SetCurrentPiece(this.GetComponent<Tile>().GetCurrentPiece());
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
