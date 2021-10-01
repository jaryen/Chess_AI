using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    private int checkRow, checkCol;
    private Tile tile;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    //finds all possible moves
    public override void findMoves(Tile src)
    {
        // Forward movement
        checkRow = src.row + 1;
        if (checkOutOfBounds(checkRow, src.col))
        {
            tile = BoardGeneration.gameBoard[checkRow, src.col].GetComponent<Tile>();
            while (checkRow <= 7 && (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                tile = BoardGeneration.gameBoard[checkRow, src.col].GetComponent<Tile>();
                // if hit a piece in front
                validMoves.Add(tile);
                if(tile.GetCurrentPiece() != null){
                    break;
                }
                checkRow++;
                if (checkRow <= 7)
                {
                    tile = BoardGeneration.gameBoard[checkRow, src.col].GetComponent<Tile>();
                }
            }
        }
        
        // Backwards movement
        checkRow = src.row - 1;
        if (checkOutOfBounds(checkRow, src.col))
        {
            tile = BoardGeneration.gameBoard[checkRow, src.col].GetComponent<Tile>();
            while (checkRow >= 0 && (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                tile = BoardGeneration.gameBoard[checkRow, src.col].GetComponent<Tile>();
                // if hit a piece in front
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                checkRow--;
                if (checkRow >= 0)
                {
                    tile = BoardGeneration.gameBoard[checkRow, src.col].GetComponent<Tile>();
                }
            }
        }
        
        // Right movement
        checkCol = src.col + 1;
        if (checkOutOfBounds(src.row, checkCol))
        {
            tile = BoardGeneration.gameBoard[src.row, checkCol].GetComponent<Tile>();
            while (checkCol <= 7 && (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                checkCol++;
                if (checkCol <= 7) {
                    tile = BoardGeneration.gameBoard[src.row, checkCol].GetComponent<Tile>();
                }
            }
        }
        
        // Left movement
        checkCol = src.col - 1;
        if (checkOutOfBounds(src.row, checkCol))
        {
            tile = BoardGeneration.gameBoard[src.row, checkCol].GetComponent<Tile>();
            while (checkCol >= 0 && (tile.GetCurrentPiece() == null ||
                tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if(tile.GetCurrentPiece() != null){
                    break;
                }
                checkCol--;
                if (checkCol >= 0)
                {
                    tile = BoardGeneration.gameBoard[src.row, checkCol].GetComponent<Tile>();
                }
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
