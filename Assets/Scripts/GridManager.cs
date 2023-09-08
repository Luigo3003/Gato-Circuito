using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private bool Touched;
    [SerializeField]
    GameObject CellSelected;
    bool CellIsSelected = false;
    Vector2 pos;
    [SerializeField] LayerMask cellMask;
    void Start()
    {
        Touched = false; 
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
            CellSelected = null;
            CellIsSelected = false;

        }

    }

    GameObject UpdateCellSelected()
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.forward, cellMask);

        if (hit.collider.tag == "Cell")
        {
            CellIsSelected = true;
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }

    }
}
