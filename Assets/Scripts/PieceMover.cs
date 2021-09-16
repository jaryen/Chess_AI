using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages piece selection/movement through Tile and
// moves the piece to second Tile selected
public class PieceMover : MonoBehaviour
{
    [Header("Setup")]
    public Camera cam;
    public LayerMask tileMask;
    
    [Header("During Game")]
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
                    if (selectedTile.GetCurrentPiece() != null && selectedPiece.isWhite
                        == selectedTile.GetCurrentPiece().isWhite)
                    {
                        selectedPiece.clearMoves(); // Clear the old selected piece's moves
                        selectedPiece = selectedTile.GetCurrentPiece();
                        selectedPiece.findMoves();
                    }
                    // If newly selected tile has NO piece on it
                    else if (selectedPiece.validMoves.Contains(selectedTile) && 
                        selectedTile.GetCurrentPiece() == null)
                    {
                        selectedPiece.moveToSquare(selectedTile);
                        selectedPiece.clearMoves();
                    }
                    // If a tile outside of selected piece's valid moves is clicked,
                    // set the selected piece as null
                    else if (!selectedPiece.validMoves.Contains(selectedTile))
                    {
                        selectedPiece = null;
                    }
                }
                else // No piece selected yet
                {
                    selectedPiece = selectedTile.GetCurrentPiece();
                    selectedPiece.findMoves();
                }
            }
        }
    }
}