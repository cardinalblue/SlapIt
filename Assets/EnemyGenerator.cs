using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public Canvas canvas;
	public GameObject enemyRight;
	public GameObject enemyLeft;
	public GameObject goodBoy;
	
	// Update is called once per frame
	int count = 0;
	void Update () {
		if (Time.frameCount % 60 == 0) {
			GameObject a;
			if (count++ % 2 == 0) {
				a = (GameObject)Instantiate(enemyRight); 
			} else {
				a = (GameObject)Instantiate(enemyLeft); 
			}
			canvas.SendMessage("AddEnemy", a);
		}
	}
}
