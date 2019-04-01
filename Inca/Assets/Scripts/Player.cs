using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float moveSpeed = 2.5f;
    bool allowPlayerInput = true;
    Vector3 currentMovementVector;
    Vector3 moveLeft = new Vector3(-1f, 0f, 0f);
    Vector3 moveRight = new Vector3(1f, 0f, 0f);
    Vector3 moveUp = new Vector3(0f, 1f, 0f);
    Vector3 moveDown = new Vector3(0f, -1f, 0f);

    Rigidbody2D playerRigidbody;
    RoundPosition roundPos;
    CheckValidInput inputCheck;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        roundPos = FindObjectOfType<RoundPosition>();
        inputCheck = FindObjectOfType<CheckValidInput>();

        if (!playerRigidbody)
        {
            Debug.LogWarning("Rigidbody2D component is missing on Player");
        }
        if (!roundPos)
        {
            Debug.LogWarning("RoundPosition is missing");
        }
        if (!inputCheck)
        {
            Debug.LogWarning("CheckValidInput is missing");
        }
    }
    
    void Update()
    {
        if (!playerRigidbody || !roundPos ||!inputCheck)
        {
            Debug.LogWarning("An error has been detected. Update is no longer running.");
            return;
        }
        PlayerInput();
        MovePlayer();
    }

    private void PlayerInput()
    {
        if (allowPlayerInput)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && inputCheck.LeftInputIsValid(transform.position))
            {
                currentMovementVector = moveLeft;
                ManagePlayerInputAllow();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && inputCheck.RightInputIsValid(transform.position))
            {
                currentMovementVector = moveRight;
                ManagePlayerInputAllow();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && inputCheck.UpInputIsValid(transform.position))
            {
                currentMovementVector = moveUp;
                ManagePlayerInputAllow();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && inputCheck.DownInputIsValid(transform.position))
            {
                currentMovementVector = moveDown;
                ManagePlayerInputAllow();
            }
        }
    }

    private void ManagePlayerInputAllow()
    {
        allowPlayerInput = !allowPlayerInput;
    }

    private void MovePlayer()
    {
        if (!allowPlayerInput) //means player has pressed a direction key and the player is now moving in that direction
        {
            Vector3 targetPosition = transform.position + currentMovementVector;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), Mathf.Clamp(transform.position.y, -3.5f, 3.5f), 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = roundPos.RoundPlayerPosition(transform.position);
        allowPlayerInput = true;
    }

}
