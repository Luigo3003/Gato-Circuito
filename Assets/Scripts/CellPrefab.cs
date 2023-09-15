using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPrefab : MonoBehaviour
{
    private Transform GridTransform;
    public void OnTouchReleased() 
    {
        if(GridTransform)
            gameObject.transform.position = GridTransform.position; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        collision.GetComponent<SpriteRenderer>().color = Color.green;
        GridTransform = collision.transform;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().color = Color.white;

    }
}
