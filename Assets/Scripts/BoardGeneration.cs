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

        for (int r = 0; r < boardHeight; r++)
        {
            for (int c = 0; c < boardWidth; c++)
            {
                SetPiecePosition(r, c);
            }
        }
    }

    private void GenerateBoard()
    {
        for (int r = 0; r < boardHeight; r++) {
            float yOffSet = r + transform.position.y;
            for (int c = 0; c < boardWidth; c++) {
                float xOffSet = c + transform.position.y;
                GameObject tile = Instantiate(newTile, new Vector2(xOffSet, yOffSet), Quaternion.identity);

                // Set tile colors
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

    private void SetPiecePosition(int r, int c)
    {
        GameObject piece = null;
        bool isWhite = true;

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
                isWhite = false;
            }
        }
        else if (r == 0 || r == 7)
        {
            if (c == 0 || c == 7)
            {
                // Set rooks
                //piece = (r == 0) ? Instantiate(whitePieces[1]) : Instantiate(blackPieces[1]);
            }
            else if (c == 1 || c == 6)
            {
                // Set knights
                piece = (r == 0) ? Instantiate(whitePieces[2]) : Instantiate(blackPieces[2]);
            }
            else if (c == 2 || c == 5)
            {
                // Set bishops
                piece = (r == 0) ? Instantiate(whitePieces[3]) : Instantiate(blackPieces[3]);

            }
            else if (c == 3)
            {
                // Set queen
                piece = (r == 0) ? Instantiate(whitePieces[4]) : Instantiate(blackPieces[4]);
            }
            else
            {
                // Set king
                piece = (r == 0) ? Instantiate(whitePieces[5]) : Instantiate(blackPieces[5]);
            }
        }
        if (piece)
        {
            piece.transform.position = gameBoard[r, c].transform.position;
            Piece p = piece.GetComponent<Piece>();
            p.isWhite = isWhite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
