using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Movement and rotation speed")]
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float rotateSpeed = 1;

    [Header("Distance to move")]
    [SerializeField] int forwardDistanceToMove = 0;
    [SerializeField] int sideDistanceToMove = 0;

    //[Header("Angle to rotate")]
    //[SerializeField] int angleToRotate = 0;

    [Header("Only for debuging - remove from inspecotr")]
    [SerializeField] bool isMoving = false;
    [SerializeField] bool isRotating = false;

    Vector3 targetPosition;
    Vector3 targetRotation;

    private void Start()
    {
        targetPosition = transform.TransformPoint(new Vector3Int(sideDistanceToMove, 0, forwardDistanceToMove));
        targetRotation = transform.right;
    }


    private void Update()
    {
        if (isMoving)
        {
            Movement();
        }
        else if (isRotating)
        {
            Rotation();
        }
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (
            Mathf.Abs(transform.position.x - targetPosition.x) < 0.01
            &&
            Mathf.Abs(transform.position.z - targetPosition.z) < 0.01
            )
        {
            isMoving = false;
        }
    }

    private void Rotation()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetRotation, rotateSpeed * Time.deltaTime, 0.0f));
        if (transform.forward == targetRotation)
        {
            isRotating = false;
        }
    }

}


