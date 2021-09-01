using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGeneration : MonoBehaviour
{
    [Header("Setup")]
    public GameObject tile;

    [Header("Attributes")]
    [SerializeField] private int boardWidth = 8;
    [SerializeField] private int boardHeight = 8;

    private Color lightSquareCol = new Color(0.933f, 0.933f, 0.824f, 1);
    private Color darkSquareCol = new Color(0.463f, 0.588f, 0.337f, 1);

    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        Color currTileCol = darkSquareCol;
        for (float y = 0; y < boardHeight; y++)
        {
            float offSetY = transform.position.y + y;
            for (float x = 0; x < boardWidth; x++)
            {
                GameObject newTile = Instantiate(tile);
                float offSetX = transform.position.x + x;
                newTile.transform.position = new Vector2(offSetX, offSetY);

                SpriteRenderer tileSprite = newTile.GetComponent<SpriteRenderer>();
                tileSprite.color = currTileCol;
                currTileCol = (currTileCol == lightSquareCol) ? darkSquareCol : lightSquareCol;
            }
            currTileCol = (currTileCol == lightSquareCol) ? darkSquareCol : lightSquareCol;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
