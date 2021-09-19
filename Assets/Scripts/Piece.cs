using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : BoardGeneration
{
    public ArrayList validMoves = new ArrayList();   //stores all possible moves for this piece
    public bool taken = false;
    [SerializeField] public bool isWhite;
    [SerializeField] public int row;
    [SerializeField] public int col;

    protected BoardGeneration boardGeneration;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GameObject boardGeneratorGO = GameObject.Find("BoardGenerator");
        boardGeneration = boardGeneratorGO.GetComponent<BoardGeneration>();
    }

    //clears validMoves list
    public void clearMoves() {
        validMoves.Clear();
    }

    public bool checkOutOfBounds(int r, int c) {
        if (r < 0 || r > 7 || c < 0 || c > 7) {
            return false;
        }
        return true;
    }

    public abstract void findMoves();

    //moves the piece to the selected square, return true if successful, else return false
    public abstract bool moveToSquare(Tile dest);

    // Update is called once per frame
    void Update()
    {
        
    }
}
