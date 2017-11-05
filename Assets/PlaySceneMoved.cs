using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneMoved : MonoBehaviour
{
	void Start ()
	{
	}
	
	void Update ()
	{
		if (0 < Input.touchCount) {
			SceneManager.LoadScene("PlayScene");
		}
	}
}
