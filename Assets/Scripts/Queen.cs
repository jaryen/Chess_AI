using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    private int dRow, dCol, sRow, sCol;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    //finds all possible moves
    public override void findMoves()
    {
        //check top left
        dRow = this.row + 1;
        dCol = this.col - 1;
        Tile tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
        while (dRow <= 7 && (tile.GetCurrentPiece() == null ||
               tile.GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[dRow, dCol]);
            dRow++;
            dCol--;
        }

        //check top right
        dRow = this.row + 1;
        dCol = this.col + 1;
        tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
        while (dRow >= 0 && (tile.GetCurrentPiece() == null ||
               tile.GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[dRow, dCol]);
            dRow++;
            dCol++;
        }

        //check bottom left
        dRow = this.row - 1;
        dCol = this.col - 1;
        tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
        while (dCol <= 7 && (tile.GetCurrentPiece() == null ||
               tile.GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[dRow, dCol]);
            dRow--;
            dCol--;
        }

        //check bottom right
        dRow = this.row - 1;
        dCol = this.col + 1;
        tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
        while (dCol >= 0 && (tile.GetCurrentPiece() == null ||
               tile.GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[dRow, dCol]);
            dRow--;
            dCol++;
        }

        // Forward movement
        sRow = this.row + 1;
        tile = boardGeneration.gameBoard[sRow, this.col].GetComponent<Tile>();
        while (sRow <= 7 && (tile.GetCurrentPiece() == null ||
            tile.GetCurrentPiece().isWhite != this.isWhite))
        {
            // if hit a piece in front
            validMoves.Add(tile);
            sRow++;
        }

        // Backwards movement
        sRow = this.row - 1;
        tile = boardGeneration.gameBoard[sRow, this.col].GetComponent<Tile>();
        while (sRow >= 0 && (tile.GetCurrentPiece() == null ||
            tile.GetCurrentPiece().isWhite != this.isWhite))
        {
            // if hit a piece in front
            validMoves.Add(tile);
            sRow--;
        }

        // Right movement
        sCol = this.col + 1;
        tile = boardGeneration.gameBoard[this.row, sCol].GetComponent<Tile>();
        while (sCol <= 7 && (tile.GetCurrentPiece() == null ||
            tile.GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(tile);
            sCol++;
        }

        // Left movement
        sCol = this.col - 1;
        tile = boardGeneration.gameBoard[this.row, sCol].GetComponent<Tile>();
        while (sCol >= 0 && (tile.GetCurrentPiece() == null ||
            tile.GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(tile);
            sCol--;
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
