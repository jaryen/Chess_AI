using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    private bool inCheck;
    private bool left, right, top, bottom;  //true if the side can be moved to, false if not

    // Start is called before the first frame update
    void Start()
    {
        inCheck = false;
    }

    //finds all possible moves
    public override void findMoves()
    {
        if (row != 7) {  //if the king is not in the top row
            if (gameBoard[this.row + 1, this.col - 1].GetComponent<Tile>().GetCurrentPiece() == null || 
                gameBoard[this.row + 1, this.col - 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the left of the king, or for opposing pieces
                validMoves.Add(gameBoard[this.row + 1, this.col - 1]);
            }

            if (gameBoard[this.row + 1, this.col].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row + 1, this.col].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above the king, or for opposing pieces
                validMoves.Add(gameBoard[this.row + 1, this.col]);
            }

            if (gameBoard[this.row + 1, this.col + 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row + 1, this.col + 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the right of the king, or for opposing pieces
                validMoves.Add(gameBoard[this.row + 1, this.col + 1]);
            }
        }

        if (row != 0) { //if the king is not in the bottom row
            if (gameBoard[this.row - 1, this.col - 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row - 1, this.col - 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the left of the king, or for opposing pieces
                validMoves.Add(gameBoard[this.row + 1, this.col - 1]);
            }

            if (gameBoard[this.row - 1, this.col].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row - 1, this.col].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above the king, or for opposing pieces
                validMoves.Add(gameBoard[this.row + 1, this.col]);
            }

            if (gameBoard[this.row - 1, this.col + 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row - 1, this.col + 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly above and to the right of the king, or for opposing pieces
                validMoves.Add(gameBoard[this.row + 1, this.col + 1]);
            }
        }

        if (col != 0) { //if the king isnt on the leftmost column
            if (gameBoard[this.row, this.col - 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row, this.col - 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly to the left of the king, or for opposing pieces
                validMoves.Add(gameBoard[this.row, this.col - 1]);
            }
        }

        if (col != 7) { //if the king isnt on the rightmost column
            if (gameBoard[this.row, this.col + 1].GetComponent<Tile>().GetCurrentPiece() == null ||
                gameBoard[this.row, this.col + 1].GetComponent<Tile>().GetCurrentPiece().isWhite != this.isWhite) { //check for pieces directly to the right of the king, or for opposing pieces
                validMoves.Add(gameBoard[this.row, this.col + 1]);
            }
        }
    }

    //set check state, true = in check
    public void setCheck(bool state) {
        inCheck = state;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.validMoves.Count == 0 && inCheck) { //no more valid moves
            //TODO: check for ways a piece can block a check
            Application.Quit();
        }
    }
}
