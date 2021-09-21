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
    public override void findMoves(Tile src)
    {
        if (src.row <= 5) { //knight can move up
            if (src.col > 0) {
                tile = boardGeneration.gameBoard[src.row + 2, src.col - 1].GetComponent<Tile>();
                //check top left
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }

            if (src.col < 7)
            {
                tile = boardGeneration.gameBoard[src.row + 2, src.col + 1].GetComponent<Tile>();//check top right
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }
            
        }

        if (src.row >= 2) { //knight can move down
            if (src.col > 0)
            {
                tile = boardGeneration.gameBoard[src.row - 2, src.col - 1].GetComponent<Tile>();
                //check top left
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }

            if (src.col < 7)
            {
                tile = boardGeneration.gameBoard[src.row - 2, src.col + 1].GetComponent<Tile>();
                //check top left
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }
        }

        if (src.col <= 5) { //knight can move right
            if (src.row < 7)
            {
                tile = boardGeneration.gameBoard[src.row + 1, src.col + 2].GetComponent<Tile>();
                //check right top
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }

            if (src.row > 0)
            {
                tile = boardGeneration.gameBoard[src.row - 1, src.col + 2].GetComponent<Tile>();
                //check right top
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }
        }

        if (src.col >= 2) { //knight can move left
            if (src.row < 7)
            {
                tile = boardGeneration.gameBoard[src.row + 1, src.col - 2].GetComponent<Tile>();
                //check right top
                if (tile.GetCurrentPiece() == null ||
                    tile.GetCurrentPiece().isWhite != this.isWhite)
                {
                    validMoves.Add(tile);
                }
            }

            if (src.row > 0)
            {
                tile = boardGeneration.gameBoard[src.row - 1, src.col - 2].GetComponent<Tile>();
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
