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


    public void ButtonPressed()
    {
        turn.Value += 1f;
<<<<<<< Updated upstream
        if(turn.Value > 3f){
=======
        if (turn.Value > 4f)
        {
>>>>>>> Stashed changes
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