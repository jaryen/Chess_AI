using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    private int movementModifier; //used to determine what row is "forward"

    // Start is called before the first frame update
    void Start()
    {
        //set movement modifiers
        if (isWhite)
        {
            movementModifier = 1;   //up is forward
        }
        else
        {
            movementModifier = -1;  //down is forward
        }
    }

    //finds all possible moves
    public void findMoves() 
    {        
        //forward movement detection
        //pawns cannot move forward if a piece is blocking it
        if (gameBoard[this.row + movementModifier, this.col].GetComponent<Tile>().GetCurrentPiece() == null)
        {
            validMoves.Add(gameBoard[this.row + movementModifier, this.col]);
        }

        //left out of bounds detection
        //pawns can only move diagonally if there is a piece to be taken
        if (this.col - 1 >= 0)
        {
            if (gameBoard[this.row + movementModifier, this.col - 1].GetComponent<Tile>().GetCurrentPiece() != null)
            {
                validMoves.Add(gameBoard[this.row + movementModifier, this.col - 1]);
            }
        }

        //left out of bounds detection
        //pawns can only move diagonally if there is a piece to be taken
        if (this.col + 1 <= 7)
        {
            if (gameBoard[this.row + movementModifier, this.col + 1].GetComponent<Tile>().GetCurrentPiece() != null)
            {
                validMoves.Add(gameBoard[this.row + movementModifier, this.col + 1]);
            }
        }
    }

    //promote a piece, return the piece to be promoted to (Queen, Rook, Knight, Bishop)
    private void promote() { 
        //TODO
    }

    // Update is called once per frame
    void Update()
    {
        if ((isWhite && row == 7) || (!isWhite && row == 0))
        {
            promote();
        }
    }
}
