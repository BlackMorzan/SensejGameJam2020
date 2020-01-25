using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
	// Start is called before the first frame update

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag == "Player")
		{
			SceneManager.LoadScene("Stage2", LoadSceneMode.Single);

		}
	}
}
