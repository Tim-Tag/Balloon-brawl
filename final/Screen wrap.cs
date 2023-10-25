using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public float wrapPoint = 18f;
    private void Update()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.x > wrapPoint)
        {
            transform.position = new Vector2( wrapPoint * -1, currentPosition.y);
        }
        else if (currentPosition.x < wrapPoint * -1)
        {
            transform.position = new Vector2(wrapPoint, currentPosition.y);
        }
    }
}  
