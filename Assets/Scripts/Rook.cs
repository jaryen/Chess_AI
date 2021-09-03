using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    private int checkRow, checkCol;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //finds all possible moves
    public void findMoves()
    {
        // Forward movement
        checkRow = this.row + 1;
        while (checkRow <= 7 && (gameBoard[checkRow, this.col].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[checkRow, this.col].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)) {
            // if hit a piece in front
            validMoves.Add(gameBoard[checkRow, this.col]);
            checkRow++;
        }

        // Backwards movement
        checkRow = this.row - 1;
        while (checkRow >= 0 && (gameBoard[checkRow, this.col].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[checkRow, this.col].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)) {
            // if hit a piece in front
            validMoves.Add(gameBoard[checkRow, this.col]);
            checkRow--;
        }

        // Right movement
        checkCol = this.col + 1;
        while (checkCol <= 7 && (gameBoard[this.row, checkCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[this.row, checkCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)) {
            validMoves.Add(gameBoard[this.row, checkCol]);
            checkCol++;
        }

        // Left movement
        checkCol = this.col - 1;
        while (checkCol >= 0 && (gameBoard[this.row, checkCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[this.row, checkCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)) {
            validMoves.Add(gameBoard[this.row, checkCol]);
            checkCol--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
