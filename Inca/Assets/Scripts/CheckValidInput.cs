using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckValidInput : MonoBehaviour
{
    float max = 3f;

    public bool LeftInputIsValid(Vector3 position)
    {
        if (position.x < -max)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool RightInputIsValid(Vector3 position)
    {
        if (position.x > max)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool UpInputIsValid(Vector3 position)
    {
        if (position.y > max)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool DownInputIsValid(Vector3 position)
    {
        if (position.y < -max)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
