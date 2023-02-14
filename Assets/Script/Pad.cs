using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public float padMaxX;

    public bool autoplay;
    float yPosition;
    Pause pause;
    MainMenu mainMenu;
    Ball ball;

    private void Start()
    {
        pause = FindObjectOfType<Pause>();
        mainMenu = FindObjectOfType<MainMenu>();
        ball = FindObjectOfType<Ball>();

        yPosition = transform.position.y;
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector3 padNewPosition;

        if (pause.pauseActive || mainMenu.menuActive)
        {
            return;
        }

        if (autoplay)
        {
            Vector3 ballPosition = ball.transform.position;
            padNewPosition = new Vector3(ballPosition.x, yPosition, 0);
        }
        else
        {
            Vector3 mousePixelPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

            padNewPosition = new Vector3(mouseWorldPosition.x, yPosition, 0); 
        }

        padNewPosition.x = Mathf.Clamp(padNewPosition.x, -padMaxX, padMaxX);
        transform.position = padNewPosition;
    }
}
