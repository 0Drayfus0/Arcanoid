using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool pauseActive;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pauseActive)
            {
                Time.timeScale = 1f;
                pauseActive = false;
            }
            else
            {
                Time.timeScale = 0f;
                pauseActive = true;
            }
        }
    }
}
