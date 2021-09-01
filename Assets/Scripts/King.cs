using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    private bool inCheck;
    private bool left, right, top, bottom;  //true if the side can be moved to, false if not

    // Start is called before the first frame update
    void Start()
    {
        inCheck = false;
        left = true;
        right = true;
        top = true;
        bottom = true;
    }

    //finds all possible moves
    public void findMoves()
    {
        switch (row) {
            case 0:
                bottom = false;
                break;

            case 7:
                top = false;
                break;
        }

        switch (col)
        {
            case 0:
                left = false;
                break;

            case 7:
                right = false;
                break;
        }
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
