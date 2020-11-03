using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private ChessPlacementConfig _chessPlacement = default;
    
    [SerializeField] private Transform _boardRoot = default;
    [SerializeField] private Cell _cellPrefab = default;
    
    private List<Cell> cells;
    
    private void Start()
    {
        InitializeBoard();
        SpawnInitialFigures();
    }

    private void InitializeBoard()
    {
        cells = new List<Cell>();
        for (int i = 1; i < 9; i++)
        {
            for (int k = 1; k < 9; k++)
            {
                Vector3 spawnPos = new Vector3(i, 0f, k);
                Cell c = 
                    Instantiate(_cellPrefab, spawnPos, Quaternion.identity, _boardRoot);
                c.SetCoordinate(i, k);
                cells.Add(c);
            }
        }
    }

    private void SpawnInitialFigures()
    {
        foreach (var figurePlacement in _chessPlacement.FigurePlacements)
        {
            foreach (var pos in figurePlacement.WhiteFigurePositions)
            {
                Vector3 spawnPos = new Vector3(pos.x, 0.25f, pos.y);
                var figureObj = 
                    Instantiate(figurePlacement.FigureInfo.GetFigurePrefab(FigureSide.White), spawnPos, Quaternion.identity, _boardRoot);
                var figure = figureObj.AddComponent<Figure>();
                Cell cell = cells.First(c => c.Coordinate == pos);
                cell.SetPlacedFigure(figure);
                figure.InitializeFigure(FigureSide.White, figurePlacement.FigureInfo.FigureMovement, cell);
            }
            foreach (var pos in figurePlacement.BlackFigurePositions)
            {
                Vector3 spawnPos = new Vector3(pos.x, 0.25f, pos.y);
                var figureObj = 
                    Instantiate(figurePlacement.FigureInfo.GetFigurePrefab(FigureSide.Black), spawnPos, Quaternion.identity, _boardRoot);
                var figure = figureObj.AddComponent<Figure>();
                Cell cell = cells.First(c => c.Coordinate == pos);
                cell.SetPlacedFigure(figure);
                figure.InitializeFigure(FigureSide.Black, figurePlacement.FigureInfo.FigureMovement, cell);
            }
        }
    }

    public bool IsMovementValid(FigureMovement movement)
    {
        return false;
    }
}
