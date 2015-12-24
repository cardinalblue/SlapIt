using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public UIController controller;
	public Text score;
	public AudioClip slapAudio;
	public AudioClip hostageAudio;
	public AudioClip bonusAudio;

	private AudioSource source;
	private PeopleAttr currentPeople; // FIXME we can handle multiple people in the same time
	private int currentScore = 0; // TODO refactor by accessorator

	public void Start() {
		source = GetComponent<AudioSource> ();
	}
	public void AttackEnemy(int direction) {
		if (currentPeople != null) {
			PeopleAttr attr = currentPeople;
			if (attr.isEnemy) {
				switch(direction) {
				case 2:
					if (!attr.isLeftDefensed) {
						attr.left();
						source.PlayOneShot (slapAudio);
						currentPeople = null;
						currentScore += attr.score;
					}
					break;
				case 1:
					if (!attr.isRightDefensed) {
						attr.right();
						source.PlayOneShot (slapAudio);
						currentPeople = null;
						currentScore += attr.score;
					}
					break;
				}
			} else {
				source.PlayOneShot(hostageAudio);
				currentScore -= attr.score;
			}
			score.text = "" + currentScore;
		}
	}

	public void reset() {
		currentScore = 0;
		score.text = "" + currentScore;
	}

	public void Saving() {
		if (currentPeople != null) {
			if (currentPeople.isEnemy) {
				currentScore -= currentPeople.score;
			} else {
				currentScore += currentPeople.score;
			}
			currentPeople = null;
			score.text = "" + currentScore;
		}
	}

	void GetBonus() {
		// TODO
	}

	public void TimesUp() {
		controller.MoveToFinalPage (currentScore);
	}

	public void AddEnemy(GameObject gameobject) {
		currentPeople = gameobject.GetComponent<PeopleAttr>();
		gameobject.transform.SetParent(this.transform, false);
	}
}
