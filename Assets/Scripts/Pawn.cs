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
    public override void findMoves(Tile src) 
    {
        //forward movement detection
        //pawns cannot move forward if a piece is blocking it
        Tile forwardTile = BoardGeneration.gameBoard[src.row + movementModifier, src.col].GetComponent<Tile>();
        if (forwardTile.GetCurrentPiece() == null) {
            validMoves.Add(forwardTile);
        }

        
        //intial pawn double move for white
        if (isWhite && src.row == 1) {
            Tile forward1 = BoardGeneration.gameBoard[src.row + 1, src.col].GetComponent<Tile>();
            Tile forward2 = BoardGeneration.gameBoard[src.row + 2, src.col].GetComponent<Tile>();
            if (forward1.GetCurrentPiece() == null && forward2.GetCurrentPiece() == null) {
                Tile doubleForwardTile = BoardGeneration.gameBoard[src.row + 2, src.col].GetComponent<Tile>();
                if (doubleForwardTile.GetCurrentPiece() == null || doubleForwardTile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(doubleForwardTile);
                }
            }            
        }

                //intial pawn double move for black
        if (!isWhite && src.row == 6) {
            Tile forward1 = BoardGeneration.gameBoard[src.row - 1, src.col].GetComponent<Tile>();
            Tile forward2 = BoardGeneration.gameBoard[src.row - 2, src.col].GetComponent<Tile>();
            if (forward1.GetCurrentPiece() == null && forward2.GetCurrentPiece() == null) {
                Tile doubleForwardTile = BoardGeneration.gameBoard[src.row - 2, src.col].GetComponent<Tile>();
                if (doubleForwardTile.GetCurrentPiece() == null || doubleForwardTile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(doubleForwardTile);
                }
            }            
        }

        //left out of bounds detection
        //pawns can only move diagonally if there is a piece to be taken
        if (src.col - 1 >= 0) {
            Tile leftForwardTile = BoardGeneration.gameBoard[src.row + movementModifier, src.col - 1].GetComponent<Tile>();
            if (leftForwardTile.GetCurrentPiece() != null && leftForwardTile.GetCurrentPiece().isWhite != this.isWhite) {
                validMoves.Add(leftForwardTile);
            }
        }

        //left out of bounds detection
        //pawns can only move diagonally if there is a piece to be taken
        if (src.col + 1 <= 7) {
            Tile rightForwardTile = BoardGeneration.gameBoard[src.row + movementModifier, src.col + 1].GetComponent<Tile>();
            if (rightForwardTile.GetCurrentPiece() != null && rightForwardTile.GetCurrentPiece().isWhite != this.isWhite) {
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
        /*if ((isWhite && row == 7) || (!isWhite && row == 0))
        {
            promote();
        }*/
    }
}
