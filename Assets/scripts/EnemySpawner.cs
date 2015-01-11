using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPref;

	public float enemyRate =5f;
	float nextEnemy = 1f;
	float distanceSpawn =12f;
	// Use this for initialization
	void Start () {
	
	}

	void SpawnEnemy(){
		Vector3 offset = Random.onUnitSphere;
		offset.z = 0;
		offset = offset.normalized * distanceSpawn;
		Instantiate (enemyPref, transform.position + offset, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		nextEnemy -= Time.deltaTime;
		if (nextEnemy < 0) {
			nextEnemy = enemyRate;	
			enemyRate *= 0.9f;
			SpawnEnemy();
		}
	}
}
