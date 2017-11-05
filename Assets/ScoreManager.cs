using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text score_text;
	private int score;

	void Start ()
	{
		score = 0;
	}

	void Update ()
	{
		score_text.text = score.ToString();
	}

	void startInitialize()
	{
		score = 0;
	}

	public void addScore(int value)
	{
		score += value;
	}
}
