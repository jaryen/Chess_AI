using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    private int checkRow, checkCol;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    //finds all possible moves
    public override void findMoves()
    {
        // Forward movement
        checkRow = this.row + 1;
        Tile tile = boardGeneration.gameBoard[checkRow, this.col].GetComponent<Tile>();
        while (checkRow <= 7 && (tile.GetCurrentPiece() == null ||
            tile.GetCurrentPiece().isWhite != this.isWhite)) {
            // if hit a piece in front
            validMoves.Add(tile);
            checkRow++;
        }

        // Backwards movement
        checkRow = this.row - 1;
        tile = boardGeneration.gameBoard[checkRow, this.col].GetComponent<Tile>();
        while (checkRow >= 0 && (tile.GetCurrentPiece() == null ||
            tile.GetCurrentPiece().isWhite != this.isWhite)) {
            // if hit a piece in front
            validMoves.Add(tile);
            checkRow--;
        }

        // Right movement
        checkCol = this.col + 1;
        tile = boardGeneration.gameBoard[this.row, checkCol].GetComponent<Tile>();
        while (checkCol <= 7 && (tile.GetCurrentPiece() == null ||
            tile.GetCurrentPiece().isWhite != this.isWhite)) {
            validMoves.Add(tile);
            checkCol++;
        }

        // Left movement
        checkCol = this.col - 1;
        tile = boardGeneration.gameBoard[this.row, checkCol].GetComponent<Tile>();
        while (checkCol >= 0 && (tile.GetCurrentPiece() == null ||
            tile.GetCurrentPiece().isWhite != this.isWhite)) {
            validMoves.Add(tile);
            checkCol--;
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
