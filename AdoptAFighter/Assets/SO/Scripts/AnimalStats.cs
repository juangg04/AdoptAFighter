using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStats : MonoBehaviour
{

    [SerializeField] private FloatValueSO currentHealth;

    [SerializeField] private FloatValueSO defense;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth.Value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            damaged(0.2f);
        }
    }

    public void damaged(float damage){
        currentHealth.Value -= damage * defense.Value;
    }

}
