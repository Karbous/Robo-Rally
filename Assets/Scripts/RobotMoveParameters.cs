using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Robot movement parametrs")]
public class RobotMoveParameters : ScriptableObject
{
    public float moveSpeed = 0;
    public float rotateSpeed = 0;
    public int gridSize = 10;
}


