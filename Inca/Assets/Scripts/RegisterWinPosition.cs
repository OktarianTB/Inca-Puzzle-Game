using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterWinPosition : MonoBehaviour
{

    public Vector3 winPosition;

    void Start()
    {
        winPosition = transform.position;
    }
}
