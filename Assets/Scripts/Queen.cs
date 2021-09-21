using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    private int dRow, dCol, sRow, sCol;
    private Tile tile;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    //finds all possible moves
    public override void findMoves(Tile src)
    {
        //check top left
        dRow = src.row + 1;
        dCol = src.col - 1;
        if (checkOutOfBounds(dRow, dCol))
        {
            tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
            while (dRow <= 7 && dCol >= 0 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                dRow++;
                dCol--;
                if (checkOutOfBounds(dRow, dCol))
                {
                    tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
                }
            }
        }

        //check top right
        dRow = src.row + 1;
        dCol = src.col + 1;
        if (checkOutOfBounds(dRow, dCol))
        {
            tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
            while (dRow <= 7 && dCol <= 7 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                dRow++;
                dCol++;
                if (checkOutOfBounds(dRow, dCol))
                {
                    tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
                }
            }
        }

        //check bottom left
        dRow = src.row - 1;
        dCol = src.col - 1;
        if (checkOutOfBounds(dRow, dCol))
        {
            tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
            while (dRow >= 0 && dCol >= 0 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                dRow--;
                dCol--;
                if (checkOutOfBounds(dRow, dCol))
                {
                    tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
                }
            }
        }

        //check bottom right
        dRow = src.row - 1;
        dCol = src.col + 1;
        if (checkOutOfBounds(dRow, dCol))
        {
            tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
            while (dRow >= 0 && dCol <= 7 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                dRow--;
                dCol++;
                if (checkOutOfBounds(dRow, dCol))
                {
                    tile = boardGeneration.gameBoard[dRow, dCol].GetComponent<Tile>();
                }
            }
        }

        // Forward movement
        sRow = src.row + 1;
        if (checkOutOfBounds(sRow, src.col))
        {
            tile = boardGeneration.gameBoard[sRow, src.col].GetComponent<Tile>();
            while (sRow <= 7 && (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                tile = boardGeneration.gameBoard[sRow, src.col].GetComponent<Tile>();
                // if hit a piece in front
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                sRow++;
                if (sRow <= 7)
                {
                    tile = boardGeneration.gameBoard[sRow, src.col].GetComponent<Tile>();
                }
            }
        }

        // Backwards movement
        sRow = src.row - 1;
        if (checkOutOfBounds(sRow, src.col))
        {
            tile = boardGeneration.gameBoard[sRow, src.col].GetComponent<Tile>();
            while (sRow >= 0 && (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                tile = boardGeneration.gameBoard[sRow, src.col].GetComponent<Tile>();
                // if hit a piece in front
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                sRow--;
                if (sRow >= 0)
                {
                    tile = boardGeneration.gameBoard[sRow, src.col].GetComponent<Tile>();
                }
            }
        }

        // Right movement
        sCol = src.col + 1;
        if (checkOutOfBounds(src.row, sCol))
        {
            tile = boardGeneration.gameBoard[src.row, sCol].GetComponent<Tile>();
            while (sCol <= 7 && (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                sCol++;
                if (sCol <= 7)
                {
                    tile = boardGeneration.gameBoard[src.row, sCol].GetComponent<Tile>();
                }
            }
        }

        // Left movement
        sCol = src.col - 1;
        if (checkOutOfBounds(src.row, sCol))
        {
            tile = boardGeneration.gameBoard[src.row, sCol].GetComponent<Tile>();
            while (sCol >= 0 && (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                sCol--;
                if (sCol >= 0)
                {
                    tile = boardGeneration.gameBoard[src.row, sCol].GetComponent<Tile>();
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
