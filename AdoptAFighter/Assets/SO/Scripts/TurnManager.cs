using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private FloatValueSO turn;
    public ControlRaton control;


    // Start is called before the first frame update
    void Start()
    {
        turn.Value = 0f;
    }

    void Update()
    {
        switch (turn.Value)
        {
            case 0 : control.personaje = 0; break;
            case 1: control.personaje = 1; break;
            case 2: control.personaje = 2; break;
            case 3: control.personaje = 3; break;
            case 4: control.personaje = 4; break;
        }
    }


    public void ButtonPressed(){
        turn.Value += 1f;
        if(turn.Value > 4f){
            turn.Value = 0f;
        }
    }
}
