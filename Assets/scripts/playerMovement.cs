using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	public float maxSpeed = 3.0f;
	public float rotSpeed = 180f;
	float shipBoundaryRadius = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Input.GetKeyDown (KeyCode.Space);

		// rotate
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z += -rotSpeed * Time.deltaTime * Input.GetAxis ("Horizontal");
		rot = Quaternion.Euler (0, 0, z);// recreate the quaternion
		transform.rotation = rot;
		// move
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime * Input.GetAxis ("Vertical"), 0);

		// pos.y += maxSpeed*Time.deltaTime*Input.GetAxis("Vertical");// return  a float from -1.0 to 1.0
		pos += rot * velocity;// angle + move

		// restrict the player to camera's boundarie
		if (pos.y+shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize-shipBoundaryRadius;
		}
		if (pos.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize+shipBoundaryRadius;
		}
		float screenRadius = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRadius;

		if (pos.x+shipBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho-shipBoundaryRadius;
		}
		if (pos.x-shipBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho+shipBoundaryRadius;
		}
		//update position for player ship
		transform.position = pos;
	}
}
