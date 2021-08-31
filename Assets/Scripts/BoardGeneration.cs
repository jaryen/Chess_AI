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

    private Color lightSquareCol = new Color(238, 238, 210);
    private Color darkSquareCol = new Color(118, 150, 86);

    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int y = 0; y < boardHeight; y++)
        {
            for (int x = 0; x < boardWidth; x++)
            {
                GameObject newTile = Instantiate(tile);
                newTile.transform.position = new Vector2(x, y);

                SpriteRenderer tileSprite = newTile.GetComponent<SpriteRenderer>();
                tileSprite.color = 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
