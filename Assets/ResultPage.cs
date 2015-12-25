using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultPage : MonoBehaviour {
	public Text scoreText;
	public Text highestScoreText;
	public AudioClip highestScoreAudio;
	public AudioClip loserAudio;

	private AudioSource source;
	private int currentScore;

	public void Start() {
		source = GetComponent<AudioSource> ();
		int highestScore = PlayerPrefs.GetInt ("highest_score", 0);
		if (currentScore >= highestScore) {
			// source.PlayOneShot (highestScoreAudio);
			source.clip = highestScoreAudio;
		} else {
			source.clip = loserAudio;
		}
		source.Play ();
	}

	void initial(int currentScore) {
		scoreText.text = "" + currentScore;
		int highestScore = PlayerPrefs.GetInt ("highest_score", 0);
		this.currentScore = currentScore;
		highestScoreText.text = "HIGHEST SCORE : " + highestScore;
	}
}
