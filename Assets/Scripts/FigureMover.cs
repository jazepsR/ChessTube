using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FigureMover : MonoBehaviour
{
    private FigureSpawner spawner;
    private bool isWhiteMove = true;
    public static ChessFigure selectedFigure = null;
    private bool[,] allowedMoves = new bool[8, 8];
    [SerializeField] private GameObject resetText;

    private void Awake()
    {
        spawner = GetComponent<FigureSpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        resetText.SetActive(false);
       Var.canMakeMove = true;
    }

    // Update is called once per frame
    void Update()
    {



        if (BoardManager.selectionX >= 0 && BoardManager.selectionY >= 0 &&
            BoardManager.selectionX <8  && BoardManager.selectionY <8)
        {

            if (Input.GetMouseButtonDown(0))
            {

                if (selectedFigure == null)
                {
                    SelectChessFigure(BoardManager.selectionX, BoardManager.selectionY);
                }
                else
                {
                    MoveChessFigure(BoardManager.selectionX, BoardManager.selectionY);
                }
            }
        }
    }

    private void SelectChessFigure(int x, int y)
    {

        if (!Var.canMakeMove) return;
        if (spawner.ChessFigurePositions[x, y] == null) return;
        if (spawner.ChessFigurePositions[x, y].isWhite != isWhiteMove) return;

        bool hasAtLeastOneMove = false;
        allowedMoves = spawner.ChessFigurePositions[x, y].PossibleMove(spawner.ChessFigurePositions);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (allowedMoves[i, j])
                {
                    hasAtLeastOneMove = true;
                    i = 7;
                    break;
                }
            }
        }

        if (!hasAtLeastOneMove) return;

        selectedFigure = spawner.ChessFigurePositions[x, y];
        BoardHighlighting.Instance.HighlightAllowedMoves(allowedMoves);
    }

    private void MoveChessFigure(int x, int y)
    {
        Debug.Log("making move. is white: " + isWhiteMove +" " + selectedFigure.name + " move: x " + x + " y " + y);
        if (allowedMoves[x, y])
        {
            bool gameOver = false;                ;
            ChessFigure c = spawner.ChessFigurePositions[x, y];
            if (c != null && c.isWhite != isWhiteMove)
            {
                spawner.activeFigures.Remove(c);
                Destroy(c.gameObject);

                if (c.type == FigureType.King)
                {
                    gameOver = true;
                }
            }

            spawner.ChessFigurePositions[selectedFigure.CurrentX, selectedFigure.CurrentY] = null;
            selectedFigure.transform.position = spawner.GetTileCenter(x, y);
            selectedFigure.SetPosition(x, y);
            spawner.ChessFigurePositions[x, y] = selectedFigure;


            if(gameOver)
            {
                EndGame();
                return;
            }

            isWhiteMove = !isWhiteMove;
           // LogBoardState(spawner.ChessFigurePositions);
            if (isWhiteMove != Var.isPlayerWhite && Var.gameType == GameType.AI)
            {
                Var.canMakeMove = false;
                Vector2Int move = BotController.Instance.GetMove(isWhiteMove, spawner.ChessFigurePositions);
                ExecuteAIMove(move);
            }
        }
        else
        {
            Debug.Log("move failed! Selected figure: " + selectedFigure.name + " move: x " +x+ " y " + y);
        }
       // LogBoardState(spawner.ChessFigurePositions);
        BoardHighlighting.Instance.HideHighlights();
        selectedFigure = null;
    }

    public void LogBoardState(ChessFigure[,] boardState)
    {
        for (int i = 0; i < 8; i++)
        {
            string line = "line " + i + " ";
            for (int j = 0; j < 8; j++)
            {
                if (boardState[j, i] != null)
                {
                    line += boardState[j, i].name + " ";
                }
                else
                {
                    line += "- ";
                }
            }
            Debug.Log(line);
        }
    }


    public void ExecuteAIMove(Vector2Int moveCoordinates)
    {
        allowedMoves = selectedFigure.PossibleMove(spawner.ChessFigurePositions);
        BoardHighlighting.Instance.ShowLastMove(selectedFigure.CurrentX, selectedFigure.CurrentY);
        MoveChessFigure(moveCoordinates.x,moveCoordinates.y);
        Var.canMakeMove = true;
    }


    private void EndGame()
    {
        if (isWhiteMove)
            Debug.Log("White team won!");
        else
            Debug.Log("Black team won!");
        Var.canMakeMove = false;
        resetText.SetActive(true);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
