using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFigureMovement", menuName = "Chess/FigureMovement")]
public class FigureMovement : ScriptableObject
{
    public bool IsMovementAvailiable(Cell startCell, Cell targetCell)
    {
        // TODO: Implement different movement mechanics
        return true;
    }
}
