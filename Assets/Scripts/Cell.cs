using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    [SerializeField] private float _placedFigureHeight = 0.25f;
 
    private Figure _placedFigure;
    private Vector2 _coordinate;

    public Vector2 Coordinate => _coordinate;
    
    public bool IsOccupied => _placedFigure != null;

    [Header("Selection settings")]
    [SerializeField] private Color _selectedColor = Color.yellow;
    [SerializeField] private Color _hoverColor = Color.green;
    private Color _defaultColor;

    
    private Material _material;
    private bool _isSelected = false;
    
    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _defaultColor = _material.color;
    }

    public Vector3 GetFigurePlacementPosition()
    {
        return new Vector3(transform.position.x, _placedFigureHeight, transform.position.z);
    }

    public FigureSide GetPlacedFigureSide()
    {
        return _placedFigure.Side;
    }
    
    public void SetCoordinate(int row, int col)
    {
        _coordinate = new Vector2((float)row, (float)col);
    }

    public void SetPlacedFigure(Figure figure)
    {
        if (_placedFigure != null)
        {
            Destroy(_placedFigure.gameObject);
            _placedFigure = null;
        }
        _placedFigure = figure;
    }

    public bool TryMoveFigure(Cell targetCell)
    {
        return _placedFigure.TryMove(targetCell);
    }

    public void OnSelect()
    {
        _isSelected = true;
        _material.DOColor(_selectedColor, 0.2f);
    }

    public void OnDeselect()
    {
        _isSelected = false;
        _material.DOColor(_defaultColor, 0.2f);
    }

    private void OnMouseEnter()
    {
        if(!_isSelected)
            _material.DOColor(_hoverColor, 0.2f);
    }

    private void OnMouseExit()
    {
        if(!_isSelected)
            _material.DOColor(_defaultColor, 0.2f);
    }
}
