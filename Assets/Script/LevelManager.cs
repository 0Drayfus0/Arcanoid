using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]int blocksCount;
    int indexScene;

    private void Start()
    {
        indexScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void CreateBlock()
    {
        blocksCount++;   
    }
    public void BlockDestroyed()
    {
        blocksCount--;
        if(blocksCount <= 0)
        {
           
            SceneManager.LoadScene(indexScene);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(indexScene);
    }

}
