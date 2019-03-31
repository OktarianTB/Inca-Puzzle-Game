using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPosition : MonoBehaviour
{

    public Vector3 RoundPlayerPosition(Vector3 position)
    {
        float xPos = Mathf.Round(position.x * 2) / 2; // Rounds the position to the closest .5/
        float yPos = Mathf.Round(position.y * 2) / 2;
        Vector3 newPosition = new Vector3(xPos, yPos, 0f);
        return newPosition;
    }

}
