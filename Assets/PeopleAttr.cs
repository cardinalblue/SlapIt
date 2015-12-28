using UnityEngine;
using System.Collections;

public class PeopleAttr : MonoBehaviour {
	public bool isRightDefensed;
	public bool isLeftDefensed;
	public bool isBoss;
	public int score;

	// TODO refactor
	public bool isEnemy = false;
	public bool isBonus = false;

	Animator anim;

	public void Start() {
		anim = GetComponent<Animator>();
		anim.applyRootMotion = true;
	}

    public void getBonus() {
		if (isBonus) {
			anim.Play ("Move Up");
		}
	}
	public void left() {
		anim.Play ("Die State Left");
	}

	public void right() {
		anim.Play ("Die State Right");
	}

	public void endAnimation() {
		Destroy (gameObject);
	}
}
