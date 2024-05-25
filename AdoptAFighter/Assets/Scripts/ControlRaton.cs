using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRaton : MonoBehaviour
{
    private Ray rayo;
    public LayerMask capaTransitable;
    private RaycastHit hit;
    public GridBehavior gridBehavior;
    public int personaje;
    public bool movible = true;


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && movible)
        {
            rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayo, out hit, 100, capaTransitable))
            {
                GridStat gridStat = hit.collider.GetComponent<GridStat>();
                if (gridStat != null)
                {
                    gridBehavior.movX = gridStat.x;
                    gridBehavior.movY = gridStat.y;
                    gridBehavior.Personaje = personaje;
                    gridBehavior.encontrarDistancia = true;
                }
            }
            movible = false;
        }
    }
}