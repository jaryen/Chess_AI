using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    private int dRow, dCol, sRow, sCol = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //finds all possible moves
    public void findMoves()
    {
        //check top left
        dRow = this.row + 1;
        dCol = this.col - 1;
        while (dRow <= 7 && (gameBoard[dRow, dCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[dRow, dCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[dRow, dCol]);
            dRow++;
            dCol--;
        }

        //check top right
        dRow = this.row + 1;
        dCol = this.col + 1;
        while (dRow >= 0 && (gameBoard[dRow, dCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[dRow, dCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[dRow, dCol]);
            dRow++;
            dCol++;
        }

        //check bottom left
        dRow = this.row - 1;
        dCol = this.col - 1;
        while (dCol <= 7 && (gameBoard[dRow, dCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[dRow, dCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[dRow, dCol]);
            dRow--;
            dCol--;
        }

        //check bottom right
        dRow = this.row - 1;
        dCol = this.col + 1;
        while (dCol >= 0 && (gameBoard[dRow, dCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[dRow, dCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[dRow, dCol]);
            dRow--;
            dCol++;
        }

        // Forward movement
        sRow = this.row + 1;
        while (sRow <= 7 && (gameBoard[sRow, this.col].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[sRow, this.col].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            // if hit a piece in front
            validMoves.Add(gameBoard[sRow, this.col]);
            sRow++;
        }

        // Backwards movement
        sRow = this.row - 1;
        while (sRow >= 0 && (gameBoard[sRow, this.col].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[sRow, this.col].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            // if hit a piece in front
            validMoves.Add(gameBoard[sRow, this.col]);
            sRow--;
        }

        // Right movement
        sCol = this.col + 1;
        while (sCol <= 7 && (gameBoard[this.row, sCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[this.row, sCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[this.row, sCol]);
            sCol++;
        }

        // Left movement
        sCol = this.col - 1;
        while (sCol >= 0 && (gameBoard[this.row, sCol].GetComponent<Tile>().GetCurrentPiece() == null || gameBoard[this.row, sCol].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite))
        {
            validMoves.Add(gameBoard[this.row, sCol]);
            sCol--;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
