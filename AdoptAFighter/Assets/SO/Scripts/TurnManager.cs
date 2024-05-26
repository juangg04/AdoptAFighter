using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    //Poner un bool para que cuando se mueve el personaje no pueda pulsar el turno y que cuando acabe de moverse pueda pulsar el boton de nuevo

    [SerializeField] private FloatValueSO turn;
    public ControlRaton control;
    public GameObject collider1;
    public GameObject collider2; 
    public GameObject collider3;
    public GameObject collider4;


    // Start is called before the first frame update
    void Start()
    {
        turn.Value = 0f;
    }

    void Update()
    {
        switch (turn.Value)
        {
            case 0: control.personaje = 0;
                collider1.GetComponent<Collider>().enabled = false;
                collider2.GetComponent<Collider>().enabled = false;
                collider3.GetComponent<Collider>().enabled = false;
                collider4.GetComponent<Collider>().enabled = false;
                break;
            case 1: control.personaje = 1;
                collider1.GetComponent<Collider>().enabled = true;
                collider2.GetComponent<Collider>().enabled = false;
                collider3.GetComponent<Collider>().enabled = false;
                collider4.GetComponent<Collider>().enabled = false; 
                break;
            case 2: control.personaje = 2;
                collider1.GetComponent<Collider>().enabled = false;
                collider2.GetComponent<Collider>().enabled = true;
                collider3.GetComponent<Collider>().enabled = false;
                collider4.GetComponent<Collider>().enabled = false; 
                break;
            case 3: control.personaje = 3;
                collider1.GetComponent<Collider>().enabled = false;
                collider2.GetComponent<Collider>().enabled = false;
                collider3.GetComponent<Collider>().enabled = true;
                collider4.GetComponent<Collider>().enabled = false; 
                break;
            case 4: control.personaje = 4;
                collider1.GetComponent<Collider>().enabled = false;
                collider2.GetComponent<Collider>().enabled = false;
                collider3.GetComponent<Collider>().enabled = false;
                collider4.GetComponent<Collider>().enabled = true; 
                break;
        }
    }


    public void ButtonPressed()
    {
        turn.Value += 1f;
        if (turn.Value > 4f)
        {
            turn.Value = 0f;
        }
        if (turn.Value > 0f)
        {
            control.movible = true;
        }
        else
        {
            control.movible = false;
        }
    }
}