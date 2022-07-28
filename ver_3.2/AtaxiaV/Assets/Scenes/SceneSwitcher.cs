using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void playTarget()
    {
        SceneManager.LoadScene(sceneName:"Leap Target Game");
    }
    public void playTouch()
    {
        SceneManager.LoadScene(sceneName: "Leap Touching Rhythm Game");
    }
    public void menu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
    
    public void playDraw()
    {
        SceneManager.LoadScene(sceneName: "Drawing and Coloring Game");
    }

    public void playMaze()
    {
        SceneManager.LoadScene(sceneName: "Speech Recognition Maze Game");
    }
}
