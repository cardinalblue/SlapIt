using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultPage : MonoBehaviour {
	public Text scoreText;
	public Text highestScoreText;

	void initial(int currentScore) {
		scoreText.text = "" + currentScore;
		highestScoreText.text = "HIGHEST SCORE : " + PlayerPrefs.GetInt ("highest_score", 0);
	}
}
