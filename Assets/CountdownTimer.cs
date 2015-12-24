using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public GameManager gameMgr;
	public int initialTime = 60;
	private Text timer;
	private float currentTimestamp;

	// Use this for initialization
	void Start () {
		reset ();
	}

	public void reset() {
		timer = GetComponent<Text> ();
		currentTimestamp = initialTime;
		timer.text = ((int)currentTimestamp) + "";
	}

	void Update () {
		if (Time.frameCount % 60 == 0) { // FIXME 60 fps is it correct?
			timer.text = ((int)currentTimestamp - 1) + "s";
			currentTimestamp = currentTimestamp - 1;
			if (currentTimestamp <= 0) {
				gameMgr.TimesUp();
				// send message and moving to result page
			}
		}
	}
}
