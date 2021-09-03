using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //finds all possible moves
    public void findMoves()
    {
        if (this.row <= 5) { //knight can move up
            //check top left
            if (gameBoard[this.row + 2, this.col - 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row + 2, this.col - 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(gameBoard[this.row + 2, this.col - 1]);
            }

            //check top right
            if (gameBoard[this.row + 2, this.col + 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row + 2, this.col + 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(gameBoard[this.row + 2, this.col + 1]);
            }
        }

        if (this.row >= 2) { //knight can move down
            //check bottom left
            if (gameBoard[this.row - 2, this.col - 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row - 2, this.col - 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(gameBoard[this.row - 2, this.col - 1]);
            }

            //check bottom right
            if (gameBoard[this.row - 2, this.col + 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row - 2, this.col + 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(gameBoard[this.row - 2, this.col + 1]);
            }
        }

        if (this.col <= 5) { //knight can move right
            //check right top
            if (gameBoard[this.row + 1, this.col + 2].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row + 1, this.col + 2].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(gameBoard[this.row + 1, this.col + 2]);
            }

            //check right bottom
            if (gameBoard[this.row - 1, this.col + 2].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row - 1, this.col + 2].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(gameBoard[this.row - 1, this.col + 2]);
            }
        }

        if (this.col >= 2) { //knight can move left
            //check left top
            if (gameBoard[this.row + 1, this.col - 2].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row + 1, this.col - 2].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(gameBoard[this.row + 1, this.col - 2]);
            }

            //check left bottom
            if (gameBoard[this.row - 1, this.col - 2].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row - 1, this.col - 2].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite)
            {
                validMoves.Add(gameBoard[this.row - 1, this.col - 2]);
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
