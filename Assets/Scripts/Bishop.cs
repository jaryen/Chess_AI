using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    private int checkRow, checkCol = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    //finds all possible moves
    public override void findMoves()
    {
        //check top left
        checkRow = this.row + 1;
        checkCol = this.col - 1;
        while (checkRow <= 7 && (gameBoard[checkRow, checkCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[checkRow, checkCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[checkRow, checkCol]);
            checkRow++;
            checkCol--;
        }

        //check top right
        checkRow = this.row + 1;
        checkCol = this.col + 1;
        while (checkRow >= 0 && (gameBoard[checkRow, checkCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[checkRow, checkCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[checkRow, checkCol]);
            checkRow++;
            checkCol++;
        }

        //check bottom left
        checkRow = this.row - 1;
        checkCol = this.col - 1;
        while (checkCol <= 7 && (gameBoard[checkRow, checkCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[checkRow, checkCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[checkRow, checkCol]);
            checkRow--;
            checkCol--;
        }

        //check bottom right
        checkRow = this.row - 1;
        checkCol = this.col + 1;
        while (checkCol >= 0 && (gameBoard[checkRow, checkCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[checkRow, checkCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[checkRow, checkCol]);
            checkRow--;
            checkCol++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
