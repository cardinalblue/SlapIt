using UnityEngine;
using System.Collections;

public class PeopleAttr : MonoBehaviour {
	public bool isRightDefensed;
	public bool isLeftDefensed;
	public bool isBoss;
	public int score;

	// TODO refactor
	public bool isEnemy = false;
	Animator anim;

	public void Start() {
		anim = GetComponent<Animator>();
	}

	public void left() {
	//	animation.Play ("swipe_left");
		anim.Play ("Die State Left");
	}

	public void right() {
		// anim.SetTrigger (swipeRightHash);
		anim.Play ("Die State Right");
	}

	public void endAnimation() {
		Destroy (gameObject);
	}
}
