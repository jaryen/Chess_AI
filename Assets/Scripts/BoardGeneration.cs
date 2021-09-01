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
                    tileScript.SetColor(lightSquareCol);
                }
                else {
                    tileScript.SetColor(darkSquareCol);
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
