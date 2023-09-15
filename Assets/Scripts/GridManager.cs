using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField]
    GameObject CellSelected;
    public GameObject GridPrefab;
    bool CellIsSelected = false;
    Vector2 pos;
    [SerializeField] LayerMask cellMask;
    public int sizeX = 0;
    public int sizeY = 0;
    void Start()
    {
        createGrid();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            pos = Camera.main.ScreenToWorldPoint(finger.position);
            if (CellIsSelected == false)
            {
                CellSelected = UpdateCellSelected();
            }
            if (CellIsSelected == true)
            {
                CellSelected.transform.position = pos;
            }
        }
        else if (Input.touchCount == 0)
        {
            if(CellSelected != null)
            {
                CellSelected.GetComponent<CellPrefab>().OnTouchReleased();
            }
            CellSelected = null;
            CellIsSelected = false;

        }

    }
    GameObject UpdateCellSelected()
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.forward, cellMask);

        if (hit)
        {
            if (hit.collider.CompareTag("Cell"))
            {
                CellIsSelected = true;
                return hit.collider.gameObject;
            }
            else
                return null;
        }
        else
        {
            return null;
        }

    }

    void createGrid()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                Vector2 NewPos = new Vector2(i, j);
                GameObject gridCell = Instantiate(GridPrefab, this.transform);
                gridCell.transform.position = NewPos;
            }
        }
    }

}
