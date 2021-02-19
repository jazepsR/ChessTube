using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessFigure
{
    public override bool[,] PossibleMove(ChessFigure[,] position)
    {
        bool[,] r = new bool[8, 8];
        moveCount = 0;
        ChessFigure c, c2;

        if (isWhite)
        {
            // Diagonal Left
            if (CurrentX != 0 && CurrentY != 7)
            {
                c = position[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isWhite){ r[CurrentX - 1, CurrentY + 1] = true;
                moveCount++;
            }
        }

            // Diagonal Left (chess tube)
            if (CurrentX == 0 && CurrentY != 7)
            {
                c = position[7, CurrentY + 1];
                if (c != null && !c.isWhite){ r[7, CurrentY + 1] = true;
                moveCount++;
            }
        }


            // Diagonal Right
            if (CurrentX != 7 && CurrentY != 7)
            {
                c = position[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isWhite){ r[CurrentX + 1, CurrentY + 1] = true;
                moveCount++;
            }
        }

            // Diagonal Right (chess tube)
            if (CurrentX == 7 && CurrentY != 7)
            {
                c = position[0, CurrentY + 1];
                if (c != null && !c.isWhite){ r[0, CurrentY + 1] = true;
                moveCount++;
            }
        }

            // Forward
            if (CurrentY != 7)
            {
                c = position[CurrentX, CurrentY + 1];
                if (c == null){ r[CurrentX, CurrentY + 1] = true;
                moveCount++;
            }
        }
            // Two Steps Forward
            if (CurrentY == 1)
            {
                c = position[CurrentX, CurrentY + 1];
                c2 = position[CurrentX, CurrentY + 2];
                if (c == null && c2 == null){ r[CurrentX, CurrentY + 2] = true;
                moveCount++;
            }
        }
        }
        else
        {
            // Diagonal Left
            if (CurrentX != 0 && CurrentY != 0)
            {
                c = position[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isWhite){ r[CurrentX - 1, CurrentY - 1] = true;
                moveCount++;
            }
        }

            // Diagonal Left (chess tube)
            if (CurrentX == 0 && CurrentY != 0)
            {
                c = position[7, CurrentY - 1];
                if (c != null && c.isWhite){ r[7, CurrentY - 1] = true;
                moveCount++;
            }
        }

            // Diagonal Right
            if (CurrentX != 7 && CurrentY != 0)
            {
                c = position[CurrentX + 1, CurrentY - 1];
                if (c != null && c.isWhite){ r[CurrentX + 1, CurrentY - 1] = true;
                moveCount++;
            }
        }

            // Diagonal Right (chess tube)
            if (CurrentX == 7 && CurrentY != 0)
            {
                c = position[0, CurrentY - 1];
                if (c != null && c.isWhite){ r[0, CurrentY - 1] = true;
                moveCount++;
            }
        }

            // Forward
            if (CurrentY != 0)
            {
                c = position[CurrentX, CurrentY - 1];
                if (c == null){ r[CurrentX, CurrentY - 1] = true;
                moveCount++;
            }
        }

            // Two Steps Forward
            if (CurrentY == 6)
            {
                c = position[CurrentX, CurrentY - 1];
                c2 = position[CurrentX, CurrentY - 2];
                if (c == null && c2 == null){ r[CurrentX, CurrentY - 2] = true;
                moveCount++;
            }
        }
        }

        return r;
    }
}
