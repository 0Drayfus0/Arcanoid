using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public float padMaxX; 
    float yPosition;
    private void Start()
    {
        yPosition = transform.position.y;
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector3 mousePixelPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

        //mouseWorldPosition.z = 0;
        //mouseWorldPosition.y = yPosition;

        Vector3 padNewPosition = new Vector3(mouseWorldPosition.x, yPosition, 0);

        padNewPosition.x = Mathf.Clamp(padNewPosition.x, - padMaxX, padMaxX);

        //if (padNewPosition.x > padMaxX)
        //{
        //    padNewPosition.x = padMaxX;
        //}
        //if(padNewPosition.x < -padMaxX)
        //{
        //    padNewPosition.x = -padMaxX;
        //}

        transform.position = padNewPosition;
    }

}
