using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSC : MonoBehaviour
{

    public void FirstScene()
    {
        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
