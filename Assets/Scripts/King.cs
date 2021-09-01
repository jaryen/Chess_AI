using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    private bool inCheck;

    // Start is called before the first frame update
    void Start()
    {
        inCheck = false;
    }

    //finds all possible moves
    public void findMoves()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.validMoves.Count == 0 && inCheck) { //no more valid moves
            //TODO: check for ways a piece can block a check
            Application.Quit();
        }
    }
}
