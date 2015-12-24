using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public Canvas mainPage;
	public Canvas gamePage;
	public Canvas resultPage;

	void Start() {
		setHighestScoreOnMainPage ();
	}
	
	void ClickStartGame() {
		mainPage.gameObject.SetActive (false);
		gamePage.gameObject.SetActive (true);
		resultPage.gameObject.SetActive (false);
		resetGame ();
	}

	private void setHighestScoreOnMainPage() {
		int score = PlayerPrefs.GetInt("highest_score", 0);
		Text[] texts = mainPage.GetComponentsInChildren<Text> ();
		foreach (Text t in texts) {
			if (t.tag == "score") {
				t.text = "Highest Score : " + score;
			}
		}
	}

	void ClickRetry() {
		mainPage.gameObject.SetActive (false);
		gamePage.gameObject.SetActive (true);
		resultPage.gameObject.SetActive (false);
		resetGame ();
	}

	private void resetGame() {
		// reset game before start it
		gamePage.GetComponentInChildren<CountdownTimer> ().reset();
		gamePage.GetComponentInChildren<GameManager> ().reset();
	}

	void ClickMainPage() {
		mainPage.gameObject.SetActive (true);
		gamePage.gameObject.SetActive (false);
		resultPage.gameObject.SetActive (false);
		setHighestScoreOnMainPage ();
	}

	public void MoveToFinalPage(int score) {
		mainPage.gameObject.SetActive (false);
		gamePage.gameObject.SetActive (false);
		resultPage.gameObject.SetActive (true);
		// saving the score if it's higher than previous record
		int highestScore = PlayerPrefs.GetInt("highest_score", 0);
		if (score > highestScore) {
			PlayerPrefs.SetInt("highest_score", score);
		}
		resultPage.SendMessage ("initial", score);
	}
}
