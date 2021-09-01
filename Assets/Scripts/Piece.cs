using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private ArrayList validMoves;   //stores all possible moves for this piece

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //adds a valid move into the validMoves list
    public void addMove(GameObject square) {
        validMoves.Add(square);
    }

    //clears validMoves list
    public void clearMoves() {
        validMoves.Clear();
    }

    //moves the piece to the selected square, return true if successful, else return false
    public bool moveToSquare(GameObject dest) {
        foreach (GameObject i in validMoves) {
            if (i == dest) { 
                /**if(opposing piece is here){
                    Destroy(destPiece);
                }
                move the piece**/
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
