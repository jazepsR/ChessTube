using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessFigure
{
    ChessFigure[,] position;
    public override bool[,] PossibleMove(ChessFigure[,] position)
    {
        bool[,] r = new bool[8, 8];
        this.position = position;
        moveCount = 0;

        // Up / Left
        KnightMove(CurrentX - 1, CurrentY + 2, ref r);
        KnightMove(CurrentX - 2, CurrentY + 1, ref r);

        // Up / Right
        KnightMove(CurrentX + 1, CurrentY + 2, ref r);
        KnightMove(CurrentX + 2, CurrentY + 1, ref r);

        // Down / Left
        KnightMove(CurrentX - 1, CurrentY - 2, ref r);
        KnightMove(CurrentX - 2, CurrentY - 1, ref r);

        // Down / Right
        KnightMove(CurrentX + 1, CurrentY - 2, ref r);
        KnightMove(CurrentX + 2, CurrentY - 1, ref r);

        return r;
    }

    public void KnightMove(int x, int y, ref bool[,] r)
    {
        ChessFigure c;
        if (x >= 8)
        {
            x -= 8;
        }
        if(x<0)
        {
            x += 8;
        }


        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            c = position[x, y];
            if (c == null){ r[x, y] = true;
            moveCount++;
        }
        else if (c.isWhite != isWhite){ r[x, y] = true;
            moveCount++;
        }
    }
    }
}
