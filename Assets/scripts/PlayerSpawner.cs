using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public GameObject playerPrefab;
	GameObject playerInstance;
	public int numLives = 4;

	float respawnTimmer = 1f;
	// Use this for initialization
	void Start () {
		spawnPlayer();
	}

	void spawnPlayer(){
		numLives--;
		respawnTimmer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
		playerInstance.name = "playerShip";
	}
	// Update is called once per frame
	void Update () {

		if (playerInstance == null && numLives>0) {
			respawnTimmer -= Time.deltaTime;
			if(respawnTimmer <= 0){
				spawnPlayer();	
			}
		}
	}

	void OnGUI(){
		if (numLives > 0 || playerInstance != null) {
			GUI.Label (new Rect (0, 0, 100, 50), "Lives left: " + numLives);
		} else {
			GUI.Label (new Rect (Screen.width/2-50, Screen.width/2-100, 100, 50), "Game over ");
		}
	}
}
