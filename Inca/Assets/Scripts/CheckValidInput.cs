using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckValidInput : MonoBehaviour
{
    float max = 3f;
    public List<Vector3> objects;

    public bool LeftInputIsValid(Vector3 position)
    {
        Vector3 checkPos = position + new Vector3(-1f, 0f, 0f);

        if (position.x < -max) //checks if there is a wall left
        {
            return false;
        }
        else if(CheckForObject(checkPos)) // checks if there is an object to the left
        {
            return false;
        }

        return true;
    }

    public bool RightInputIsValid(Vector3 position)
    {
        Vector3 checkPos = position + new Vector3(1f, 0f, 0f);

        if (position.x > max)
        {
            return false;
        }
        else if (CheckForObject(checkPos))
        {
            return false;
        }

        return true;
    }

    public bool UpInputIsValid(Vector3 position)
    {
        Vector3 checkPos = position + new Vector3(0f, 1f, 0f);

        if (position.y > max)
        {
            return false;
        }
        else if (CheckForObject(checkPos))
        {
            return false;
        }

        return true;
    }

    public bool DownInputIsValid(Vector3 position)
    {
        Vector3 checkPos = position + new Vector3(0f, -1f, 0f);

        if (position.y < -max)
        {
            return false;
        }
        else if (CheckForObject(checkPos))
        {
            return false;
        }

        return true;
    }

    private bool CheckForObject(Vector3 positionToCheck)
    {
        foreach (Vector3 objectPos in objects)
        {
            if (objectPos == positionToCheck)
            {
                return true;
            }
        }
        return false;
    }

}
