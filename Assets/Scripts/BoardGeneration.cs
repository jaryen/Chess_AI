using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGeneration : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int boardWidth = 8;
    [SerializeField] private int boardHeight = 8;

    private Color lightSquareCol = new Color(0.933f, 0.933f, 0.824f, 1);
    private Color darkSquareCol = new Color(0.463f, 0.588f, 0.337f, 1);

    public Tile [,] gameBoard;    //2d array to store all tiles

    // Start is called before the first frame update
    void Start()
    {
        gameBoard = new Tile[boardHeight, boardWidth];
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for (int r = 0; r < boardHeight; r++) {
            for (int c = 0; c < boardWidth; c++) {
                Tile tile = new Tile();
                if ((r + c) % 2 == 0){  //set color of each tile
                    tile.SetColor(lightSquareCol);
                }
                else {
                    tile.SetColor(darkSquareCol);
                }
                gameBoard[r, c] = tile;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
