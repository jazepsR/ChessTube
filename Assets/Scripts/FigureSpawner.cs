using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FigureType { King, Queen, Rook, Bishop,Knight, Pawn}
public class FigureSpawner : MonoBehaviour
{
    public static FigureSpawner Instance;

    [SerializeField] private Transform pieceParent;
    [SerializeField] private ChessFigure[] chessFigures;
    [HideInInspector] public List<ChessFigure> activeFigures = new List<ChessFigure>();
    public ChessFigure[,] ChessFigurePositions = new ChessFigure[8,8];

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    public void Start()
    {
        SpawnAllChessFigures();
    }

    public void SpawnAllChessFigures()
    {
        // White
        SpawnChessFigure(FigureType.Rook, 0, 0, true); // Rook
        SpawnChessFigure(FigureType.Knight, 1, 0, true); // Knight
        SpawnChessFigure(FigureType.Bishop, 2, 0, true); // Bishop
        SpawnChessFigure(FigureType.Queen, 3, 0, true); // Queen
        SpawnChessFigure(FigureType.King, 4, 0, true); // King
        SpawnChessFigure(FigureType.Bishop, 5, 0, true); // Bishop
        SpawnChessFigure(FigureType.Knight, 6, 0, true); // Knight
        SpawnChessFigure(FigureType.Rook, 7, 0, true); // Rook

        SpawnChessFigure(FigureType.Pawn, 0, 1, true);
        SpawnChessFigure(FigureType.Pawn, 1, 1, true);
        SpawnChessFigure(FigureType.Pawn, 2, 1, true);
        SpawnChessFigure(FigureType.Pawn, 3, 1, true);
        SpawnChessFigure(FigureType.Pawn, 4, 1, true);
        SpawnChessFigure(FigureType.Pawn, 5, 1, true);
        SpawnChessFigure(FigureType.Pawn, 6, 1, true);
        SpawnChessFigure(FigureType.Pawn, 7, 1, true);

        // Black
        SpawnChessFigure(FigureType.Rook, 0, 7, false); // Rook
        SpawnChessFigure(FigureType.Knight, 1, 7, false); // Knight
        SpawnChessFigure(FigureType.Bishop, 2, 7, false); // Bishop
        SpawnChessFigure(FigureType.Queen, 3, 7, false); // Queen
        SpawnChessFigure(FigureType.King, 4, 7,false); // King
        SpawnChessFigure(FigureType.Bishop, 5, 7, false); // Bishop
        SpawnChessFigure(FigureType.Knight, 6, 7, false); // Knight
         SpawnChessFigure(FigureType.Rook, 7, 7, false); // Rook
       
         SpawnChessFigure(FigureType.Pawn, 0, 6,false);
         SpawnChessFigure(FigureType.Pawn, 1, 6,false);
         SpawnChessFigure(FigureType.Pawn, 2, 6,false);
         SpawnChessFigure(FigureType.Pawn, 3, 6,false);
         SpawnChessFigure(FigureType.Pawn, 4, 6,false);
         SpawnChessFigure(FigureType.Pawn, 5, 6,false);
        SpawnChessFigure(FigureType.Pawn, 6, 6,false);
        SpawnChessFigure(FigureType.Pawn, 7, 6, false);
    }
    public Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (Var.TILE_SIZE * x) + Var.TILE_OFFSET;
        origin.z += (Var.TILE_SIZE * y) + Var.TILE_OFFSET;
        return origin;
    }


    private void SpawnChessFigure(FigureType type, int x, int y ,bool isWhite)
    {
        GameObject fig = GetFigureByType(type, isWhite);
        GameObject figure = Instantiate(fig, GetTileCenter(x, y), fig.transform.rotation);
        figure.transform.SetParent(pieceParent);
        figure.transform.localScale = Vector3.one;
        ChessFigurePositions[x, y] = figure.GetComponent<ChessFigure>();
        ChessFigurePositions[x, y].SetPosition(x, y);
        activeFigures.Add(ChessFigurePositions[x, y]);
    }

    private GameObject GetFigureByType(FigureType figType, bool isWhite)
    {
        foreach(ChessFigure fig in chessFigures)
        {
            if(fig.type == figType && fig.isWhite == isWhite)
            {
                return fig.gameObject;
            }
        }
        return null;
    }

}
