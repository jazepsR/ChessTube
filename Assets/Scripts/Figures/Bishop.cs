using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessFigure
{
    public override bool[,] PossibleMove(ChessFigure[,] position)
    {
        bool[,] r = new bool[8, 8];
        moveCount = 0;
        ChessFigure c;
        int i, j;

        // Top Left
        i = CurrentX;
        j = CurrentY;
        while (true)
        {           
            j++;
            i--;
            if(i<0)
            {
                i = 7;
            }


            if (j >= 8) break;
            c = position[i, j];
            if (c == null)
            {
                r[i, j] = true;
                moveCount++;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    moveCount++;
                    r[i, j] = true;
                }
                break;
            }
        }

        // Top Right
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i == 8)
            {
                i = 0;
            }


            if (j >= 8) break;
            c = position[i, j];
            if (c == null)
            {
                r[i, j] = true;
                moveCount++;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
                    moveCount++;
                }
                break;
            }
        }

        // Bottom Left
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j--;
            if (i < 0)
            {
                i = 7;
            }
            if (i < 0 || j < 0) break;
            c = position[i, j];
            if (c == null) {
                r[i, j] = true;
                moveCount++;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                r[i, j] = true;
                moveCount++;
                }
                break;
            }
        }

        // Bottom Right
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i == 8)
            {
                i = 0;
            }
            if ( j < 0) break;
            c = position[i, j];
            if (c == null)
            {
                r[i, j] = true;
                moveCount++;
            }
            else
            {
            if (c.isWhite != isWhite)
            {
                r[i, j] = true;
                moveCount++;
            }
            break;
            }
        }

        return r;
    }
}