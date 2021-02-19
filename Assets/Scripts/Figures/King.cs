using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessFigure
{
    public override bool[,] PossibleMove(ChessFigure[,] position)
    {
        bool[,] r = new bool[8, 8];
        moveCount = 0;
        ChessFigure c;
        int i, j;

        // Top
        i = CurrentX - 1;
        j = CurrentY + 1;
        if (CurrentY < 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = position[i, j];
                    if (c == null){ r[i, j] = true;
                        moveCount++;
                    }
                    else if (c.isWhite != isWhite){ r[i, j] = true;
                    moveCount++;
                }
            }
                i++;
            }
        }

        // Bottom
        i = CurrentX - 1;
        j = CurrentY - 1;
        if (CurrentY > 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = position[i, j];
                    if (c == null){ r[i, j] = true;
                    moveCount++;
                }
                else if (c.isWhite != isWhite){ r[i, j] = true;
                    moveCount++;
                }
            }
                i++;
            }
        }

        // Left
        if (CurrentX > 0)
        {
            c = position[CurrentX - 1, CurrentY];
            if (c == null){ r[CurrentX - 1, CurrentY] = true;
            moveCount++;
        }
        else if (c.isWhite != isWhite){ r[CurrentX - 1, CurrentY] = true;
            moveCount++;
        }
    }

        // Left (chesstube)
        if (CurrentX == 0)
        {
            c = position[7, CurrentY];
            if (c == null){ r[7, CurrentY] = true;
            moveCount++;
        }
        else if (c.isWhite != isWhite){ r[7, CurrentY] = true;
            moveCount++;
        }
    }



        // Right
        if (CurrentX < 7)
        {
            c = position[CurrentX + 1, CurrentY];
            if (c == null){ r[CurrentX + 1, CurrentY] = true;
            moveCount++;
        }
        else if (c.isWhite != isWhite){ r[CurrentX + 1, CurrentY] = true;
            moveCount++;
        }
    }

        // Right (Chesstube)
        if (CurrentX == 7)
        {
            c = position[0, CurrentY];
            if (c == null){ r[0, CurrentY] = true;
            moveCount++;
        }
        else if (c.isWhite != isWhite){ r[0, CurrentY] = true;
            moveCount++;
        }
    }

        return r;
    }
}
