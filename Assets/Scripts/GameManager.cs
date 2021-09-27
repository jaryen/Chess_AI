using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BoardGeneration
{
    public enum turn { 
        white,
        black
    }

    public turn currentTurn;

    private ArrayList wPieces = new ArrayList();
    private ArrayList bPieces = new ArrayList();

    private BoardGeneration bGen;

    // Start is called before the first frame update
    void Start()
    {
        GameObject boardGeneratorObj = GameObject.Find("BoardGenerator");
        bGen = boardGeneratorObj.GetComponent<BoardGeneration>();
        currentTurn = turn.white;
        findAllPieces();
        //udpateMoves();
    }

    //scan all 64 squares at the beginning of the game to fill whitePieces and blackPieces
    private void findAllPieces() {
        for (int r = 0; r <= 1; r++) { //scan white pieces
            for (int c = 0; c < 8; c++) {
                wPieces.Add(bGen.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece());
            }
        }

        for (int r = 6; r <= 7; r++) { //scan black pieces
            for (int c = 0; c < 8; c++) {
                bPieces.Add(bGen.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece());
            }
        }
    }

    //called when a piece is taken, used to update wPieces and bPieces as pieces are taken during the game
    public void takePiece(Piece piece) {
        if (piece.isWhite)
        {
            wPieces.Remove(piece);
        }
        else {
            bPieces.Remove(piece);
        }
    }

    //updates all valid moves for all pieces on the board
    public void udpateMoves() {
        for (int r = 0; r < 8; r++) { //scan board
            for (int c = 0; c < 8; c++) {
                if (bGen.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece() != null) {   //there is a piece on this tile
                    bGen.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece().findMoves(bGen.gameBoard[r, c].GetComponent<Tile>());
                }
            }
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
        //udpateMoves();
    }

    // Update is called once per frame
    void Update()
    {
        //manage player interfacing, and turn swapping + any turn based updates needed here
    }
}
