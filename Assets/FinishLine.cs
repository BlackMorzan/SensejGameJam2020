using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public int Scene;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag == "Player")
		{
			SceneManager.LoadScene(Scene, LoadSceneMode.Single);

		}
	}
}
