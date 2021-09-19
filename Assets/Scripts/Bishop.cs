using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    private int checkRow, checkCol = 0;
    private Tile tile;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    //finds all possible moves
    public override void findMoves()
    {
        //check top left
        checkRow = this.row + 1;
        checkCol = this.col - 1;
        if (checkOutOfBounds(checkRow, checkCol)) {
            tile = boardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            while (checkRow >= 7 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                checkRow++;
                checkCol--;
                tile = boardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            }
        }

        //check top right
        checkRow = this.row + 1;
        checkCol = this.col + 1;
        if (checkOutOfBounds(checkRow, checkCol))
        {
            tile = boardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            while (checkOutOfBounds(checkRow, checkCol) && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile); // Out of memory exception
                checkRow++;
                checkCol++;
                tile = boardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            }
        }

        //check bottom left
        checkRow = this.row - 1;
        checkCol = this.col - 1;
        if (checkOutOfBounds(checkRow, checkCol))
        {
            tile = boardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            while (checkOutOfBounds(checkRow, checkCol) && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                checkRow--;
                checkCol--;
                tile = boardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            }
        }

        //check bottom right
        checkRow = this.row - 1;
        checkCol = this.col + 1;
        if (checkOutOfBounds(checkRow, checkCol))
        {
            tile = boardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            while (checkOutOfBounds(checkRow, checkCol) && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                checkRow--;
                checkCol++;
                tile = boardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
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
