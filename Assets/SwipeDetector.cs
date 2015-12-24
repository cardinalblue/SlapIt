using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour {
	public GameManager mgr;

	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;

	// Use this for initialization
	void Start () {
	}

	void moveUp() {
	}

	void moveDown() {
		mgr.Saving ();
	}

	void moveLeft() {
		mgr.AttackEnemy(2);
	}
	void moveRight() {
		mgr.AttackEnemy(1);
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				switch (touch.phase) {
				case TouchPhase.Began :
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;
					
				case TouchPhase.Canceled :
					/* The touch is being canceled */
					isSwipe = false;
					break;
				case TouchPhase.Ended :
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;
					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}else{
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}
						if(swipeType.x != 0.0f){
							if(swipeType.x > 0.0f){
								// MOVE RIGHT
								moveRight();
								Debug.Log("swipe right");
							}else{
								// MOVE LEFT
								moveLeft();
								Debug.Log("swipe left");
							}
						}
						if(swipeType.y != 0.0f){
							if(swipeType.y > 0.0f){
								// MOVE UP
								moveUp();
								Debug.Log("swipe up");
							}else{
								// MOVE DOWN
								moveDown();
								Debug.Log("swipe down");
							}
						}
					}
					break;
				}
			}
		}
	}
}
