using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

	public float rotSpeed = 90f;

	Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// find player
		if (player == null) {
			GameObject go =GameObject.Find("playerShip");

			if (go!= null){
				player = go.transform;
			}
		}
		if (player == null) {
			return; // try next frame		
		}

		// Now there is a player, trace the player
		Vector3 dir = player.position - transform.position;
		dir.Normalize ();
		float zAngle = Mathf.Atan2 (dir.y,dir.x)*Mathf.Rad2Deg-90;
		// change the rot of gameObject
		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

	}
}
