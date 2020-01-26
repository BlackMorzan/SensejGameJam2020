using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSC : MonoBehaviour
{
    public int Scene;

    public void FirstScene()
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
