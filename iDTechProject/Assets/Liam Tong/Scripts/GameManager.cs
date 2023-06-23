using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //static so we can use the class name GameManager to access it

    public int currentBuildIndex = 1;

    // Start is called before the first frame update
    void Awake() //save copy of GameManager to Instance variable
    {
        Instance = this;
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(currentBuildIndex);
    }

    public void NextLevel()
    {
        currentBuildIndex++;
        
        Debug.Log(currentBuildIndex);
    }
}
