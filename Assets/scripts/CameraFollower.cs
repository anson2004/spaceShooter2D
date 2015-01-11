using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	// Use this for initialization
	public Transform myTarget;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (myTarget != null) {
			Vector3 targetPos = myTarget.position;
			targetPos.z = transform.position.z;
			transform.position = targetPos;
		}
	}
}
