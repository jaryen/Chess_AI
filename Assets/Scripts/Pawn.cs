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
        if (forwardTile.GetCurrentPiece() == null || forwardTile.GetCurrentPiece().isWhite != this.isWhite) {
            validMoves.Add(forwardTile);
        }

        //intial pawn double move for white
        if (isWhite && this.row == 1) { 
            Tile doubleForwardTile = boardGeneration.gameBoard[this.row + 2, this.col].GetComponent<Tile>();
            if (doubleForwardTile.GetCurrentPiece() == null || doubleForwardTile.GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(doubleForwardTile);
            }
        }

        //intial pawn double move for black
        if (!isWhite && this.row == 6)
        {
            Tile doubleForwardTile = boardGeneration.gameBoard[this.row - 2, this.col].GetComponent<Tile>();
            if (doubleForwardTile.GetCurrentPiece() == null || doubleForwardTile.GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(doubleForwardTile);
            }
        }

        //left out of bounds detection
        //pawns can only move diagonally if there is a piece to be taken
        if (this.col - 1 >= 0) {
            Tile leftForwardTile = boardGeneration.gameBoard[this.row + movementModifier, this.col - 1].GetComponent<Tile>();
            if (leftForwardTile.GetCurrentPiece() != null && leftForwardTile.GetCurrentPiece().isWhite != this.isWhite) {
                validMoves.Add(leftForwardTile);
            }
        }

        //left out of bounds detection
        //pawns can only move diagonally if there is a piece to be taken
        if (this.col + 1 <= 7) {
            Tile rightForwardTile = boardGeneration.gameBoard[this.row + movementModifier, this.col + 1].GetComponent<Tile>();
            if (rightForwardTile.GetCurrentPiece() != null && rightForwardTile.GetCurrentPiece().isWhite != this.isWhite) {
                validMoves.Add(rightForwardTile);
            }
        }
    }

    //promote a piece, return the piece to be promoted to (Queen, Rook, Knight, Bishop)
    private void promote() { 
        //TODO
    }

    public override bool moveToSquare(Tile dest)
    {
        foreach (Tile src in validMoves)
        {
            // If the current valid tile is equal to 
            // the destination tile
            if (src == dest)
            {
                // check to see if a piece would be taken with this move
                if (src.GetCurrentPiece() != null)
                {
                    Destroy(dest.GetCurrentPiece());
                }
                else // move the piece
                {
                    dest.SetCurrentPiece(this);
                }
                return true;
            }
        }
        return false;
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
