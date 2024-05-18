using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudModifier : MonoBehaviour
{
    [SerializeField] private Image animal1;
    [SerializeField] private Image animal2;
    [SerializeField] private Image animal3;

    [SerializeField] FloatValueSO vida1;
    [SerializeField] FloatValueSO vida2;
    [SerializeField] FloatValueSO vida3;

    [SerializeField] FloatValueSO turno;

    // Update is called once per frame
    void Update()
    {
        if (vida1.Value <= 0 ){
            animal1.GetComponent<Image>().color = new Color32(250,67,67,171);
        }
        if (vida2.Value <= 0 ){
            animal2.GetComponent<Image>().color = new Color32(250,67,67,171);
        }
        if (vida3.Value <= 0 ){
            animal3.GetComponent<Image>().color = new Color32(250,67,67,171);
        }

       switch(turno.Value){
            case 1:
                if(vida1.Value <= 0){
                    //Mostrar por pantalla animal muerto y no hacer nada
                    break;
                }
                break;
            case 2:
                if(vida2.Value <= 0){
                    
                    break;
                }
                break;
            case 3:
                if(vida3.Value <= 0){
                    
                    break;
                }
                break;
       } 
    }
}
