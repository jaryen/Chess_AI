using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    private Tile tile;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    //finds all possible moves
    public override void findMoves()
    {
        if (this.row <= 5) { //knight can move up
            if (this.col > 0) {
                tile = boardGeneration.gameBoard[this.row + 2, this.col - 1].GetComponent<Tile>();
                //check top left
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }

            if (this.col < 7)
            {
                tile = boardGeneration.gameBoard[this.row + 2, this.col + 1].GetComponent<Tile>();//check top right
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }
            
        }

        if (this.row >= 2) { //knight can move down
            if (this.col > 0)
            {
                tile = boardGeneration.gameBoard[this.row - 2, this.col - 1].GetComponent<Tile>();
                //check top left
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }

            if (this.col < 7)
            {
                tile = boardGeneration.gameBoard[this.row - 2, this.col + 1].GetComponent<Tile>();
                //check top left
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }
        }

        if (this.col <= 5) { //knight can move right
            if (this.row < 7)
            {
                tile = boardGeneration.gameBoard[this.row + 1, this.col + 2].GetComponent<Tile>();
                //check right top
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }

            if (this.row > 0)
            {
                tile = boardGeneration.gameBoard[this.row - 1, this.col + 2].GetComponent<Tile>();
                //check right top
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }
        }

        if (this.col >= 2) { //knight can move left
            if (this.row < 7)
            {
                tile = boardGeneration.gameBoard[this.row + 1, this.col - 2].GetComponent<Tile>();
                //check right top
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }

            if (this.row > 0)
            {
                tile = boardGeneration.gameBoard[this.row - 1, this.col - 2].GetComponent<Tile>();
                //check right top
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
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

    // Update is called once per frame
    void Update()
    {

    }
}
