using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BoardGeneration
{
    private enum turn { 
        white,
        black
    }

    private turn currentTurn;

    private ArrayList wPieces;
    private ArrayList bPieces;

    // Start is called before the first frame update
    void Start()
    {
        currentTurn = turn.white;
        findAllPieces();
    }

    //scan all 64 squares at the beginning of the game to fill whitePieces and blackPieces
    private void findAllPieces() {
        for (int r = 0; r <= 1; r++) { //scan white pieces
            for (int c = 0; c < 8; c++) {
                wPieces.Add(gameBoard[r, c].GetComponent<Piece>());
            }
        }

        for (int r = 6; r <= 7; r++) { //scan black pieces
            for (int c = 0; c < 8; c++) {
                bPieces.Add(gameBoard[r, c].GetComponent<Piece>());
            }
        }
    }

    //called when a piece is taken, used to update wPieces and bPieces as pieces are taken during the game
    private void takePiece(Piece piece) {
        if (piece.isWhite)
        {
            wPieces.Remove(piece);
        }
        else {
            bPieces.Remove(piece);
        }
    }

    //change current turn from black to white, or from white to black
    public void swapTurns() {
        if (currentTurn == turn.white)
        {
            currentTurn = turn.black;
            //update black moves
        }
        else 
        {
            currentTurn = turn.white;
            //update white moves
        }
    }

    // Update is called once per frame
    void Update()
    {
        //manage player interfacing, and turn swapping + any turn based updates needed here
    }
}
