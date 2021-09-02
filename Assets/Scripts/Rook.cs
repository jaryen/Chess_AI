using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //finds all possible moves
    public void findMoves()
    {
        // Forward movement
        int checkRow = row+1;
        while (row <= 7 && gameBoard[checkRow, col].GetComponent<Tile>().GetCurrentPiece() == null) {
            // if hit a piece in front
            validMoves.Add(gameBoard[checkRow, col]);
            checkRow++;
        }

        // Backwards movement
        checkRow = row-1;
        while (row >= 0 && gameBoard[checkRow, col].GetComponent<Tile>().GetCurrentPiece() == null)
        {
            // if hit a piece in front
            validMoves.Add(gameBoard[checkRow, col]);
            checkRow--;
        }

        // Right movement
        int checkCol = col+1;
        while (col <= 7 && gameBoard[checkRow, col].GetComponent<Tile>().GetCurrentPiece() == null)
        {
            validMoves.Add(gameBoard[row, checkCol]);
            checkCol++;
        }

        // Left movement
        checkCol = col-1;
        while (col >= 0 && gameBoard[checkRow, col].GetComponent<Tile>().GetCurrentPiece() == null)
        {
            validMoves.Add(gameBoard[row, checkCol]);
            checkCol--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
