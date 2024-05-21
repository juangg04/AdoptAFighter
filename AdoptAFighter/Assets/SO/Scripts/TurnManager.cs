using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private FloatValueSO turn;


    // Start is called before the first frame update
    void Start()
    {
        turn.Value = 0f;
    }


    public void ButtonPressed(){
        turn.Value += 1f;
        if(turn.Value > 4f){
            turn.Value = 0f;
        }
    }
}
