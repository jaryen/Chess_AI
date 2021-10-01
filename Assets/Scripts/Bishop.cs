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
    public override void findMoves(Tile src)
    {
        //check top left
        checkRow = src.row + 1;
        checkCol = src.col - 1;
        if (checkOutOfBounds(checkRow, checkCol)) {
            tile = BoardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            while (checkRow <= 7 && checkCol >= 0 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                checkRow++;
                checkCol--;
                if (checkOutOfBounds(checkRow, checkCol)) {
                    tile = BoardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
                }
            }
        }

        //check top right
        checkRow = src.row + 1;
        checkCol = src.col + 1;
        if (checkOutOfBounds(checkRow, checkCol)) {
            tile = BoardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            while (checkRow <= 7 && checkCol <= 7 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                checkRow++;
                checkCol++;
                if (checkOutOfBounds(checkRow, checkCol))
                {
                    tile = BoardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
                }
            }
        }        

        //check bottom left
        checkRow = src.row - 1;
        checkCol = src.col - 1;
        if (checkOutOfBounds(checkRow, checkCol)) {
            tile = BoardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            while (checkRow >= 0 && checkCol >= 0 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                checkRow--;
                checkCol--;
                if (checkOutOfBounds(checkRow, checkCol))
                {
                    tile = BoardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
                }
            }
        }        

        //check bottom right
        checkRow = src.row - 1;
        checkCol = src.col + 1;
        if (checkOutOfBounds(checkRow, checkCol)) {
            tile = BoardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
            while (checkRow >= 0 && checkCol <= 7 && (tile.GetCurrentPiece() == null ||
                   tile.GetCurrentPiece().isWhite != this.isWhite))
            {
                validMoves.Add(tile);
                if (tile.GetCurrentPiece() != null)
                {
                    break;
                }
                checkRow--;
                checkCol++;
                if (checkOutOfBounds(checkRow, checkCol))
                {
                    tile = BoardGeneration.gameBoard[checkRow, checkCol].GetComponent<Tile>();
                }
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {

    }
}
