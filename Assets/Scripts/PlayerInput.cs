using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LayerMask _cellsLayer = default;
    
    private Cell _selectedCell;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_selectedCell == null)
            {
                TrySelectCell();
            }
            else
            {
                TryMoveFigure();
            }
        }
    }

    private void TrySelectCell()
    {
        _selectedCell = TryGetCell();
        if (_selectedCell != null)
        {
            _selectedCell.OnSelect();
        }
    }

    private void TryMoveFigure()
    {
        if (_selectedCell == TryGetCell())
        {
            _selectedCell.OnDeselect();
            _selectedCell = null;
            return;
        }
        Cell targetCell = TryGetCell();
        if (targetCell != null)
        {
            if (_selectedCell.TryMoveFigure(targetCell))
            {
                _selectedCell.OnDeselect();
                _selectedCell = null;
            }
            else
            {
                _selectedCell.OnDeselect();
                _selectedCell = null;
            }
        }
    }

    private Cell TryGetCell()
    {
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 200.0f, _cellsLayer))
        {
            var cell = hit.collider.GetComponent<Cell>();
            if (cell != null)
            {
                return cell;
            }
        }
        return null;
    }
}
