using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public GameObject bulletPrefab;
	public float fireDelay = 0.5f;
	public Vector3 bulletOffset = new Vector3(0,0.5f,0);
	float cooldownTimer = 0;
	int bulletLayer;
	Transform player;

	
	void Start(){
		bulletLayer =  gameObject.layer;
	}
	// Update is called once per frame
	void Update () {
		if (player == null) {
			GameObject go =GameObject.Find("playerShip");
			
			if (go!= null){
				player = go.transform;
			}
		}
		cooldownTimer -= Time.deltaTime;
		if (  cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position,player.position)<3 ) {
			//shoot
			Debug.Log ("enemy pew");
			cooldownTimer = fireDelay;
			Vector3 offset = transform.rotation * bulletOffset;
			// create an instance of bulletPrefab gameobject
			GameObject bulletGo = (GameObject)Instantiate(bulletPrefab,transform.position + offset,transform.rotation);
			bulletGo.layer = bulletLayer;
		}
	}
}
