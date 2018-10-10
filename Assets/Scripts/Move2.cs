using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    [SerializeField] RobotMoveParameters robotMoveParameters;

    Vector3 targetPosition;

    private void OnEnable()
    {
        targetPosition = transform.TransformPoint(Vector3.forward * robotMoveParameters.gridSize * 2);
    }


    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, robotMoveParameters.moveSpeed * Time.deltaTime);
        if (
            Mathf.Abs(transform.position.x - targetPosition.x) < 0.01
            &&
            Mathf.Abs(transform.position.z - targetPosition.z) < 0.01
            )
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            this.enabled = false;
        }
    }

    private void OnDisable()
    {
        targetPosition = Vector3.zero;
    }
}