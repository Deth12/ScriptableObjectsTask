using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public FigureSide Side;
    
    private FigureMovement _figureMovement;
    
    private Cell _currentCell;

    private bool _isDragging;
    private Vector3 _dragStartPos;

    public void InitializeFigure(FigureSide side, FigureMovement movement, Cell cell)
    {
        Side = side;
        _figureMovement = movement;
        _currentCell = cell;
    }

    public bool TryMove(Cell targetCell)
    {
        if (!_figureMovement.IsMovementAvailiable(_currentCell, targetCell))
            return false;
        if (targetCell.IsOccupied && targetCell.GetPlacedFigureSide() == Side)
            return false;
        else
        {
            Move(targetCell);
            return true;
        }
    }

    private void Move(Cell cell)
    {
        transform.position = cell.GetFigurePlacementPosition();
        _currentCell = cell;
        cell.SetPlacedFigure(this);
    }
}
