using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGeneration : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int boardWidth = 8;
    [SerializeField] private int boardHeight = 8;
    public GameObject[] whitePieces;
    public GameObject[] blackPieces;

    private Color lightSquareCol = new Color(0.933f, 0.933f, 0.824f, 1);
    private Color darkSquareCol = new Color(0.463f, 0.588f, 0.337f, 1);

    public GameObject [,] gameBoard;    //2d array to store all tiles

    public GameObject newTile;

    // Start is called before the first frame update
    void Start()
    {
        gameBoard = new GameObject[boardHeight, boardWidth];
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for (int r = 0; r < boardHeight; r++) {
            for (int c = 0; c < boardWidth; c++) {
                GameObject tile = Instantiate(newTile, new Vector2(r - 3.5f, c - 3.5f), Quaternion.identity);
                Tile tileScript = tile.GetComponent<Tile>();
                if ((r + c) % 2 == 0){  //set color of each tile
                    tileScript.SetColor(darkSquareCol);
                }
                else { // Odd tile
                    tileScript.SetColor(lightSquareCol);
                }
                gameBoard[r, c] = tile;
            }
        }
    }

    private void SetPiecePosition(int r, int c, Tile tileScript)
    {
        GameObject piece;
        // Set pawns
        if (r == 1 || r == 6)
        {
            if (r == 1)
            {
                piece = Instantiate(whitePieces[0]);
            }
            else
            {
                piece = Instantiate(blackPieces[0]);
            }
        }
        else if (r == 0 || r == 7)
        {
            // White pieces
            if (r == 0)
            {
                if (c == 0 || c == 7)
                {
                    // Set rooks
                    piece = Instantiate(whitePieces[1]);
                }
                else if (c == 1 || c == 6)
                {
                    // Set knights
                    piece = Instantiate(whitePieces[2]);
                }
                else if (c == 2 || c == 5)
                {
                    // Set bishops
                    piece = Instantiate(whitePieces[3]);
                }
                else if (c == 3)
                {
                    // Set queen
                    piece = Instantiate(whitePieces[4]);
                }
                else
                {
                    // Set king
                    piece = Instantiate(whitePieces[5]);
                }
                piece.transform.position = gameBoard[r, c].transform.position;
            }
            else // Black pieces
            {
                if (c == 0 || c == 7)
                {
                    // Set rooks
                    piece = Instantiate(blackPieces[1]);
                }
                else if (c == 1 || c == 6)
                {
                    // Set knights
                    piece = Instantiate(blackPieces[2]);

                }
                else if (c == 2 || c == 5)
                {
                    // Set bishops
                    piece = Instantiate(blackPieces[3]);

                }
                else if (c == 3)
                {
                    // Set queen
                    piece = Instantiate(blackPieces[4]);
                }
                else
                {
                    // Set king
                    piece = Instantiate(blackPieces[5]);
                }
            }
            piece.transform.position = gameBoard[r, c].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
