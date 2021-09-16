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
    public override void findMoves()
    {
        if (row != 7) {  //if the king is not in the top row
            Tile tile = boardGeneration.gameBoard[this.row + 1, this.col - 1].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the left of the king, or for opposing pieces
                validMoves.Add(tile);
            }

            tile = boardGeneration.gameBoard[this.row + 1, this.col].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above the king, or for opposing pieces
                validMoves.Add(tile);
            }

            tile = boardGeneration.gameBoard[this.row + 1, this.col + 1].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the right of the king, or for opposing pieces
                validMoves.Add(tile);
            }
        }

        if (row != 0) { //if the king is not in the bottom row
            Tile tile = boardGeneration.gameBoard[this.row - 1, this.col - 1].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the left of the king, or for opposing pieces
                validMoves.Add(tile);
            }

            tile = boardGeneration.gameBoard[this.row - 1, this.col].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above the king, or for opposing pieces
                validMoves.Add(tile);
            }

            tile = boardGeneration.gameBoard[this.row - 1, this.col + 1].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the right of the king, or for opposing pieces
                validMoves.Add(tile);
            }
        }

        if (col != 0) { //if the king isnt on the leftmost column
            Tile tile = boardGeneration.gameBoard[this.row, this.col - 1].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly to the left of the king, or for opposing pieces
                validMoves.Add(tile);
            }
        }

        if (col != 7) { //if the king isnt on the rightmost column
            Tile tile = boardGeneration.gameBoard[this.row, this.col + 1].GetComponent<Tile>();
            if (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly to the right of the king, or for opposing pieces
                validMoves.Add(tile);
            }
        }
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

    //set check state, true = in check
    public void setCheck(bool state) {
        inCheck = state;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.validMoves.Count == 0 && inCheck) { //no more valid moves
            //TODO: check for ways a piece can block a check
            Application.Quit();
        }
    }
}
