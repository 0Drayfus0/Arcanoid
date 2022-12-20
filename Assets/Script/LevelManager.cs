using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]int blocksCount;

    public void CreateBlock()
    {
        blocksCount++;   
    }
    public void BlockDestroyed()
    {
        blocksCount--;
        if(blocksCount <= 0)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        }
    }
  
}
