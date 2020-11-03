using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChessPlacementConfig", menuName = "Chess/Placement Config")]
public class ChessPlacementConfig : ScriptableObject
{
    [SerializeField] private List<FigurePlacement> _figurePlacements = new List<FigurePlacement>();
    public List<FigurePlacement> FigurePlacements => _figurePlacements;
}

[Serializable]
public class FigurePlacement
{
    public FigureInfo FigureInfo;
    public List<Vector2> WhiteFigurePositions;
    public List<Vector2> BlackFigurePositions;
}
