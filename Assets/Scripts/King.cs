using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    private bool inCheck;
    private bool left, right, top, bottom;  //true if the side can be moved to, false if not

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        inCheck = false;
    }

    //finds all possible moves
    public override void findMoves(Tile src)
    {
        top = (src.row == 7) ? false : true;

        bottom = (src.row == 0) ? false : true;

        left = (src.col == 0) ? false : true;

        right = (src.col == 7) ? false : true;

        if (top) {  //king can move up
            Tile tile = BoardGeneration.gameBoard[src.row + 1, src.col].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null || tile.GetCurrentPiece().isWhite != this.isWhite){ //check for pieces directly above the king
                validMoves.Add(tile);
            }

            if (left) {  //check top left
                tile = BoardGeneration.gameBoard[src.row + 1, src.col - 1].GetComponent<Tile>();
                if (tile.GetCurrentPiece() == null || tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the left of the king
                    validMoves.Add(tile);
                }
            }

            if (right) {  //check top right
                tile = BoardGeneration.gameBoard[src.row + 1, src.col + 1].GetComponent<Tile>();
                if (tile.GetCurrentPiece() == null || tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the right of the king
                    validMoves.Add(tile);
                }
            }
        }
        

        if (bottom) { //king can move down
            Tile tile = BoardGeneration.gameBoard[src.row - 1, src.col].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null || tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly below the king
                validMoves.Add(tile);
            }

            if (left) { //check bottom left
                tile = BoardGeneration.gameBoard[src.row - 1, src.col - 1].GetComponent<Tile>();
                if (tile.GetCurrentPiece() == null || tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly below and to the left of the king
                    validMoves.Add(tile);
                }
            }

            if (right) {
                tile = BoardGeneration.gameBoard[src.row - 1, src.col + 1].GetComponent<Tile>();
                if (tile.GetCurrentPiece() == null || tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly below and to the right of the king
                    validMoves.Add(tile);
                }
            }            
        }

        if (left) { //king can move left
            Tile tile = BoardGeneration.gameBoard[src.row, src.col - 1].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null || tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly to the left of the king
                validMoves.Add(tile);
            }
        }

        if (right) { //king can move right
            Tile tile = BoardGeneration.gameBoard[src.row, src.col + 1].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null || tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly to the right of the king
                validMoves.Add(tile);
            }
        }
    }

    //set check state, true = in check
    public void setCheck(bool state) {
        inCheck = state;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
