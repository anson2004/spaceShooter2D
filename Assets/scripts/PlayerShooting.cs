using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject bulletPrefab;
	public float fireDelay = 0.25f;
	public Vector3 bulletOffset = new Vector3(0,0.5f,0);
	float cooldownTimer = 0;
	int bulletLayer;

	void Start(){
		bulletLayer =  gameObject.layer;
	}
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if (Input.GetButton("Fire1") && cooldownTimer <= 0) {
			//shoot
			Debug.Log ("shoot");
			cooldownTimer = fireDelay;
			Vector3 offset = transform.rotation * bulletOffset;
			// create an instance of bulletPrefab gameobject
			GameObject bulletGo = (GameObject)Instantiate(bulletPrefab,transform.position + offset,transform.rotation);
			bulletGo.layer = bulletLayer;		
		}
	}
}
