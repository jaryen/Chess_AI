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

    //private BoardGeneration bGen;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject boardGeneratorObj = GameObject.Find("BoardGenerator");
        //bGen = boardGeneratorObj.GetComponent<BoardGeneration>();
        currentTurn = turn.white;
        findAllPieces();
        udpateMoves();
    }

    //scan all 64 squares at the beginning of the game to fill whitePieces and blackPieces
    private void findAllPieces() {
        for (int r = 0; r <= 1; r++) { //scan white pieces
            for (int c = 0; c < 8; c++) {
                wPieces.Add(BoardGeneration.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece());
            }
        }

        for (int r = 6; r <= 7; r++) { //scan black pieces
            for (int c = 0; c < 8; c++) {
                bPieces.Add(BoardGeneration.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece());
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
                if (BoardGeneration.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece() != null) {   //there is a piece on this tile
                    BoardGeneration.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece().findMoves(BoardGeneration.gameBoard[r, c].GetComponent<Tile>());
                }
            }
        }
    }

    //change current turn from black to white, or from white to black
    public void swapTurns() {
        if (currentTurn == turn.white)
        {
            currentTurn = turn.black;
        }
        else 
        {
            currentTurn = turn.white;
        }
        udpateMoves();
        searchForChecks();
    }

    public bool searchCheckBlocks(char side, Tile attackingPiece, Tile king) {
        if (side == 'w') { 
            //search for a block
        }
        else { 
            //search for a block
        }
    }

    //check for the opposite king's pieces in check
    public void searchForChecks() { 
        for (int r = 0; r < 8; r++) { //scan board
            for (int c = 0; c < 8; c++) {

                if (BoardGeneration.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece() != null) {   //there is a piece on this tile
                    foreach (Tile tile in BoardGeneration.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece().validMoves) { //check to see if any piece is attacking the opposing king
                        //check black king
                        if (tile.GetCurrentPiece() != null &&
                            BoardGeneration.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece().isWhite && 
                            tile.GetCurrentPiece().name == "BlackKing(Clone)") 
                        {
                            Debug.Log("black king in check");
                            if (!searchCheckBlocks('b', BoardGeneration.gameBoard[r, c].GetComponent<Tile>(), tile) && tile.GetCurrentPiece().validMoves.Count == 0) {
                                //there are no ways to block the check and the king cant move out of check, this is a checkmate
                                Debug.Log("Black checkamtes white");
                            }
                            break;
                        }

                        //check white king
                        if (tile.GetCurrentPiece() != null && 
                            !BoardGeneration.gameBoard[r, c].GetComponent<Tile>().GetCurrentPiece().isWhite && 
                            tile.GetCurrentPiece().name == "WhiteKing(Clone)") 
                        {
                            Debug.Log("white king in check");
                            if (!searchCheckBlocks('w', BoardGeneration.gameBoard[r, c].GetComponent<Tile>(), tile) && tile.GetCurrentPiece().validMoves.Count == 0) {
                                //there are no ways to block the check and the king cant move out of check, this is a checkmate
                                Debug.Log("Black checkamtes white");
                            }
                            break;
                        }
                    }
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //manage checks, checmates, promotions here
    }
}
