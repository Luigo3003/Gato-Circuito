using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicComponent : MonoBehaviour
{
    public enum ComponentType { Pared, CableHorizontal, CableVertical, Divisor, Generador, Resistencia, Multiplicador, Breaker, Repetidor};
    [SerializeField] public ComponentType thisComponent;

    private bool HasEnergy;
    private bool IsSet;
    void Start()
    {
        
    }

    void Update()
    {
        CableBehaviour();
    }

    void CableBehaviour()
    {
        if (thisComponent == ComponentType.CableHorizontal)
        {
            RaycastHit2D ComprobationRight = Physics2D.Raycast(transform.position, Vector3.right, 0.5f);
            RaycastHit2D ComprobationLeft = Physics2D.Raycast(transform.position, Vector3.left, 0.5f);
            if (ComprobationRight)
            {
                if(ComprobationRight.collider.GetComponent<ElectronicComponent>().thisComponent == ComponentType.CableHorizontal)
                {
                    Debug.Log("soy un cable, soy un cable");
                }
            }
        }
    }
}
