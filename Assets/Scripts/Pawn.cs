using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    private int movementModifier; //used to determine what row is "forward"

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
    public override void findMoves() 
    {
        //forward movement detection
        //pawns cannot move forward if a piece is blocking it
        Tile forwardTile = boardGeneration.gameBoard[this.row + movementModifier, this.col].GetComponent<Tile>();
        if (forwardTile.GetCurrentPiece() == null ||
            forwardTile.GetCurrentPiece().isWhite != this.isWhite) {
            validMoves.Add(forwardTile);
        }

        //left out of bounds detection
        //pawns can only move diagonally if there is a piece to be taken
        if (this.col - 1 >= 0)
        {
            Tile leftForwardTile = boardGeneration.gameBoard[this.row + movementModifier, this.col - 1].GetComponent<Tile>();
            if (leftForwardTile.GetCurrentPiece() != null &&
                leftForwardTile.GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(leftForwardTile);
            }
        }

        //left out of bounds detection
        //pawns can only move diagonally if there is a piece to be taken
        if (this.col + 1 <= 7) {
            Tile rightForwardTile = boardGeneration.gameBoard[this.row + movementModifier, this.col + 1].GetComponent<Tile>();
            if (rightForwardTile.GetCurrentPiece() != null &&
                rightForwardTile.GetCurrentPiece().isWhite != this.isWhite) {
                validMoves.Add(rightForwardTile);
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
