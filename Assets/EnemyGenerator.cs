using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public Canvas canvas;
	public GameObject enemyRight;
	public GameObject enemyLeft;
	public GameObject goodBoy;

	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 40 == 0) {
			GameObject a;
			int r =  Random.Range(0, 1000);
			if (r <= 20) {
				// TODO bonus
			}
			if (r <= 200) {
				a = (GameObject)Instantiate(goodBoy);
			} else {
				if (r%2 == 0) {
					a = (GameObject)Instantiate(enemyRight); 
				} else {
					a = (GameObject)Instantiate(enemyLeft); 
				}
			}
			canvas.SendMessage("AddEnemy", a);
		}
	}
}
