using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public UIController controller;
	public Text score;
	private PeopleAttr currentPeople;
	private int currentScore = 0; // TODO refactor by accessorator

	public void AttackEnemy(int direction) {
		if (currentPeople != null) {
			PeopleAttr attr = currentPeople;
			if (attr.isEnemy) {
				switch(direction) {
				case 2:
					if (!attr.isLeftDefensed) {
						attr.left();
						currentPeople = null;
						currentScore += attr.score;
					}
					break;
				case 1:
					if (!attr.isRightDefensed) {
						attr.right();
						currentPeople = null;
						currentScore += attr.score;
					}
					break;
				}
			} else {
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
		// report the final score and moving to result page
		controller.MoveToFinalPage (System.Int32.Parse(score.text));
	}

	public void AddEnemy(GameObject gameobject) {
//		foreach (Transform child in enemyLayer.transform) {
//			Destroy(child.gameObject);
//		}
		currentPeople = gameobject.GetComponent<PeopleAttr>();
		gameobject.transform.SetParent(this.transform, false);
	}
}
