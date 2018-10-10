using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTurn : MonoBehaviour
{
    [SerializeField] RobotMoveParameters robotMoveParameters;

    Vector3 targetRotation;

    private void OnEnable()
    {
        targetRotation = -transform.forward;
    }


    private void Update()
    {
        Rotation();
    }


    private void Rotation()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetRotation, robotMoveParameters.rotateSpeed * Time.deltaTime, 0.0f));
        if (
            Mathf.Abs(transform.forward.x - targetRotation.x) < 0.01
            &&
            Mathf.Abs(transform.forward.z - targetRotation.z) < 0.01
            )
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Round(transform.rotation.eulerAngles.y), transform.rotation.eulerAngles.z);
            this.enabled = false; ;
        }
    }

    private void OnDisable()
    {
        targetRotation = Vector3.zero;
    }
}