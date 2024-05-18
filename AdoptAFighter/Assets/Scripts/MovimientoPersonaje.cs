using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            MoveTowardsTarget();
        }
    }

    public void SetTargetPosition(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }

    void MoveTowardsTarget()
    {
        Vector3 newPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
}
