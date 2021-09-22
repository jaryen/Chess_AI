using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages piece selection/movement through Tile and
// moves the piece to second Tile selected
public class PieceMover : GameManager
{
    [Header("Setup")]
    public Camera cam;
    public LayerMask tileMask;

    private Color lightSquareCol = new Color(0.933f, 0.933f, 0.824f);
    private Color darkSquareCol = new Color(0.463f, 0.588f, 0.337f);
    private Color selLightSquare = new Color(0.965f, 0.965f, 0.412f);
    private Color selDarkSquare = new Color(0.729f, 0.792f, 0.169f);

    [Header("During Game")]
    private Tile prevTile;
    private Tile selectedTile;
    private Piece selectedPiece;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Gets the current position of the mouse
    public Vector3 GetMousePosition()
    {
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        return mouseWorldPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = GetMousePosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePos, new Vector2(0, 0), 0.1f, tileMask, -100, 100);

        // If mouse is over a tile collider
        if (hit.collider != null)
        {
            // Get the tile gameobject being hovered over
            GameObject tileObject = hit.transform.root.gameObject;

            // Clicked on the tile
            if (Input.GetMouseButtonDown(0))
            {
                // Get the selected tile's script component
                selectedTile = tileObject.GetComponent<Tile>();

                // If piece already selected
                if (selectedPiece != null)
                {
                    // First check if newly selected tile has a piece and is same 
                    // color. If so, set the current piece to the piece on new tile.
                    if (selectedTile.GetCurrentPiece() != null && selectedPiece.isWhite == selectedTile.GetCurrentPiece().isWhite)
                    {
                        selectedPiece.clearMoves(); // Clear the old selected piece's moves
                        selectedPiece = selectedTile.GetCurrentPiece();
                        selectedPiece.findMoves(selectedTile);
                        prevTile = selectedTile;
                    }
                    // If newly selected tile is a valid tile AND has NO piece on it
                    // Move selected piece to that tile
                    else if (selectedPiece.validMoves.Contains(selectedTile))
                    {
                        if (selectedTile.GetCurrentPiece() != null)
                        {
                            takePiece(selectedTile.GetCurrentPiece());
                            Destroy(selectedTile.GetCurrentPiece().gameObject);
                        }
                        selectedPiece.moveToSquare(selectedTile);
                        selectedPiece.clearMoves();
                        selectedPiece.transform.position = selectedTile.transform.position;
                        prevTile.SetCurrentPiece(null);
                        selectedPiece = null;
                        swapTurns();
                    }
                    // If a tile outside of selected piece's valid moves is clicked,
                    // set the selected piece as null
                    else
                    {
                        SpriteRenderer selectedTileSR = selectedTile.GetComponent<SpriteRenderer>();
                        selectedPiece.clearMoves();
                        selectedPiece = null;
                    }
                }
                else // No piece selected yet
                {
                    if (selectedTile.GetCurrentPiece() != null && 
                        (selectedTile.GetCurrentPiece().isWhite && currentTurn == turn.white || !selectedTile.GetCurrentPiece().isWhite && currentTurn == turn.black))
                    {
                        selectedPiece = selectedTile.GetCurrentPiece();
                        selectedPiece.clearMoves();
                        selectedPiece.findMoves(selectedTile);

                        // Highlight selected tile
                        SpriteRenderer selectedTileSR = selectedTile.GetComponent<SpriteRenderer>();
                        if (selectedTile.GetColor() == lightSquareCol)
                        {
                            Debug.Log("Light Square Selected");
                            selectedTileSR.color = selLightSquare;
                        }
                        else
                        {
                            Debug.Log("Dark Square Selected");
                            selectedTileSR.color = selDarkSquare;
                        }
                        prevTile = selectedTile;
                    }
                }
            }
        }
    }
}