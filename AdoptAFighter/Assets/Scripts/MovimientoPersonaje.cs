using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 targetPosition;
    private bool isMoving = false;


    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, step);
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false;
            }
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = new Vector3(position.x, transform.position.y, position.z);
        isMoving = true;
    }
}
