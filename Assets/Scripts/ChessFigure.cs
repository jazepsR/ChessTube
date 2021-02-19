using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessFigure : MonoBehaviour
{
    public int CurrentX { get; set; }
    public int CurrentY { get; set; }
    public bool isWhite;
    public FigureType type = FigureType.Pawn;
    public int moveCount = 0;
    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    public virtual bool[,] PossibleMove(ChessFigure[,] position)
    {
        return new bool[8, 8];
    }

    public virtual Vector2Int[] MoveCoordinateList(ChessFigure[,] position)
    {
        var allowedMoves = PossibleMove(position);
        Vector2Int[] moveCoordinateList = new Vector2Int[moveCount];
        int movesAdded = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (allowedMoves[i, j])
                {
                    moveCoordinateList[movesAdded] = new Vector2Int(i, j);
                    movesAdded++;
                }
            }
        }
        return moveCoordinateList;
    }
}
