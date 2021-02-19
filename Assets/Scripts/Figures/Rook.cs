using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessFigure
{
    public override bool[,] PossibleMove(ChessFigure[,] position)
    {
        bool[,] r = new bool[8, 8];
        moveCount = 0;
        ChessFigure c;
        int i;
        bool reachedEnd = true;
        // Left
        i = CurrentX;
        while (true)
        {
            i--;
            if (i < 0) break;
            c = position[i, CurrentY];
            if (c == null)
            {
                r[i, CurrentY] = true;
                moveCount++;
            }
            else
            {
                if (c.isWhite != isWhite){ r[i, CurrentY] = true;
                moveCount++;
            }
                reachedEnd = false;
                break;
            }
        }

        // Left (Chess tube)
        if (reachedEnd)
        {
            i = 8;
            while (true)
            {
                i--;
                if (i < CurrentX) break;
                c = position[i, CurrentY];
                if (c == null){
                    r[i, CurrentY] = true;
                moveCount++;
            }
                else
                {
                    if (c.isWhite != isWhite)
                    {
                        r[i, CurrentY] = true;
                        moveCount++;
                    }
                    break;
                }
            }
        }
        reachedEnd = true;
        // Right
        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8) break;
            c = position[i, CurrentY];
            if (c == null){ r[i, CurrentY] = true;
            moveCount++;
        }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY] = true;
                    moveCount++;
                }
                reachedEnd = false;
                break;
            }
        }

        if (reachedEnd)
        {
            // Right (chess tube)
            i = -1;
            while (true)
            {
                i++;
                if (i >= CurrentX) break;
                c = position[i, CurrentY];
                if (c == null){ r[i, CurrentY] = true;
                moveCount++;
            }
                else
                {
                    if (c.isWhite != isWhite)
                    {
                        r[i, CurrentY] = true;
                        moveCount++;
                    }
                    break;
                }
            }
        }

        // Forward
        i = CurrentY;
        while (true)
        {
            i++;
            if (i >= 8) break;
            c = position[CurrentX, i];
            if (c == null) {r[CurrentX, i] = true;
            moveCount++;
        }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, i] = true;
                    moveCount++;
                }
                break;
            }
        }

        // Back
        i = CurrentY;
        while (true)
        {
            i--;
            if (i < 0) break;
            c = position[CurrentX, i];
            if (c == null){ r[CurrentX, i] = true;
            moveCount++;
        }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, i] = true;
                    moveCount++;
                }
                break;
            }
        }

        return r;
    }
}
