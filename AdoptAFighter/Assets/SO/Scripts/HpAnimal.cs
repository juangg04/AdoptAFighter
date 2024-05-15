using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpAnimal : MonoBehaviour
{

    [SerializeField] private FloatValueSO currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth.Value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Z)){
            currentHealth.Value -=  0.25f;
        }

        if (currentHealth.Value <= 0){

            currentHealth.Value = 1;
        }
    }
}
