using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterObjectPosition : MonoBehaviour
{

    CheckValidInput validInputChecker;

    void Start()
    {
        validInputChecker = FindObjectOfType<CheckValidInput>();
        if (!validInputChecker)
        {
            Debug.LogWarning("CheckValidInput is missing off of player (GameObject: " + gameObject.name + " )");
            return;
        }

        validInputChecker.objects.Add(transform.position);

    }

}
