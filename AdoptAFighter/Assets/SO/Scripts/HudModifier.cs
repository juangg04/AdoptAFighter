using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudModifier : MonoBehaviour
{
    [SerializeField] private Image animal1;
    [SerializeField] private Image animal2;
    [SerializeField] private Image animal3;
    [SerializeField] private Image animal4;

    public Sprite animal1Img;
    public Sprite animal1ImgDead;
    public Sprite animal2Img;
    public Sprite animal2ImgDead;
    [SerializeField] FloatValueSO vida1;
    [SerializeField] FloatValueSO vida2;
    [SerializeField] FloatValueSO vida3;
    [SerializeField] FloatValueSO vida4;

    [SerializeField] FloatValueSO turno;


    void Start()
    {
        animal1.GetComponent<Image>().sprite = animal1Img;
        animal2.GetComponent<Image>().sprite = animal2Img;

        animal3.GetComponent<Image>().sprite = animal1Img;
        animal4.GetComponent<Image>().sprite = animal2Img;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida1.Value <= 0 ){
            animal1.GetComponent<Image>().sprite = animal1ImgDead;
        }
        if (vida2.Value <= 0 ){
            animal2.GetComponent<Image>().sprite = animal2ImgDead;
        }
        if (vida3.Value <= 0 ){
            animal3.GetComponent<Image>().sprite = animal1ImgDead;
        }
        if (vida4.Value <= 0 ){
            animal4.GetComponent<Image>().sprite = animal2ImgDead;
        }

            switch (turno.Value)
            {
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
            case 4:
                if(vida4.Value <= 0){
                    
                    break;
                }
                break;
       } 
    }
}
