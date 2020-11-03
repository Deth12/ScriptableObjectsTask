using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFigureInfo", menuName = "Chess/Figure Info")]
public class FigureInfo : ScriptableObject
{
    [SerializeField] private GameObject _figureObjectWhite = default;
    [SerializeField] private GameObject _figureObjectBlack = default;
    [SerializeField] private FigureMovement _figureMovement = default;

    public GameObject GetFigurePrefab(FigureSide figureSide)
    {
        return figureSide == FigureSide.Black ? _figureObjectBlack : _figureObjectWhite;
    }

    public FigureMovement FigureMovement => _figureMovement;
}
