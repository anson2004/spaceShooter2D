using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int health = 1;
	public float invulnPerid = 0f;
	SpriteRenderer spriteRender;//UI box in unity
	float invulnTimer = 0;

	int correctLayer;
	//void OnCollisionEnter2D(){
	//	Debug.Log ("collison");
	//}
	void Start(){
		correctLayer = gameObject.layer;

		spriteRender = GetComponent<SpriteRenderer>();

		if (spriteRender == null) {
			spriteRender = transform.GetComponentInChildren<SpriteRenderer>();
			if(spriteRender == null) { 
				Debug.Log ("object " + gameObject.name + " has no sprite render ");
			}
		}
	}

	void OnTriggerEnter2D(){
		Debug.Log ("trigger");

		health--; 
		if (invulnPerid > 0) {
			invulnTimer = invulnPerid;
			gameObject.layer = 10;	
		}
	
	}

	void Update() {

		if (invulnTimer > 0) {
			invulnTimer -= Time.deltaTime;
			if (invulnTimer <= 0) {
				gameObject.layer = correctLayer;
				if(spriteRender != null) {
					spriteRender.enabled = true;
				}
			}else {
				if(spriteRender != null) {
					spriteRender.enabled = !spriteRender.enabled;
				}
			}
		}

		if(health <= 0){
			Die();
		}
	}

	void Die() {
		Destroy(gameObject);
	}
}
