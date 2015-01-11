using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float maxSpeed = 5f;
	
	// Update is called once per frame
	void Update () {
		// move
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime , 0);		
		pos += transform.rotation * velocity;// angle + move
		transform.position = pos;
	}
}
