using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Setup")]
    public SpriteRenderer tile;

    [SerializeField] public int row;
    [SerializeField] public int col;
    private Color tileCol;
    private Piece currentPiece;
    public bool isLight;

    // Start is called before the first frame update
    void Start()
    {
        tileCol = new Color();
    }

    // Set color of tile
    public void SetColor(Color c)
    {
        tileCol = c;
        tile.color = tileCol;
    }

    public Color GetColor()
    {
        return tileCol;
    }

    // Set the current piece of this tile
    public void SetCurrentPiece(Piece piece)
    {
        currentPiece = piece;
    }

    // When tile is clicked, set whatever is
    // in currentPiece to the selectedPiece
    public Piece GetCurrentPiece()
    {
        return currentPiece;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
