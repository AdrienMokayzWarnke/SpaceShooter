using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quille_comportement : MonoBehaviour {

	public float movement_speed = 10.0f;
	public float changeDirectionTime = 0.0f;
	public float deltaTimer = 2.0f;
	public float randomDeplacementX;
	public float randomDeplacementY;
	public float randomRange=0.05f;
	public float fonceTime=float.MinValue;
	public float delayFonce = 1.5f;
	float randZ;
	GameObject player;


	GameController gameC;


	// Use this for initialization
	void Start () {

		gameC = GameObject.FindObjectOfType<GameController>();
		randomDeplacementX = Random.Range(-randomRange,randomRange);
		randomDeplacementY= Random.Range(-randomRange,randomRange);
		randZ= Random.Range(-1.0f,1f)*2.0f;
		
	}

	void Awake(){

		player = GameObject.FindGameObjectWithTag ("avion");
		//Debug.Log ("Tesst");
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("deadly")) {
			//Debug.Log (obj);
			foreach (Collider col in obj.GetComponentsInChildren<Collider>()) {
				Physics.IgnoreCollision (col, GetComponent<Collider> ());
			}
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "projectile") {
			gameC.AddScore (1500);
			Destroy (gameObject);
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "avion") {
			gameC.UpdateHealth (-0.10f);
			Destroy (gameObject);
		}if (col.gameObject.tag == "wall") {
			GetComponent<Rigidbody> ().velocity = -GetComponent<Rigidbody> ().velocity;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player && gameObject) {
			if (gameObject.transform.position.z + 10.0f + randZ < player.transform.position.z) {
				transform.position += new Vector3 (0.0f, 0.0f, 0.5f);
			} else {
				if (fonceTime < 0.0f) {
					transform.position += new Vector3 (randomDeplacementX, randomDeplacementY, -movement_speed * Time.deltaTime);
					if (changeDirectionTime < Time.time) {
						changeDirectionTime += deltaTimer;
					}
					fonceTime = Time.time + delayFonce;
				} else {
					if (fonceTime < Time.time) {
						
					} else {
						transform.position += new Vector3 (randomDeplacementX, randomDeplacementY, -movement_speed * Time.deltaTime);
						if (changeDirectionTime < Time.time) {
							changeDirectionTime += deltaTimer;
						}
					}
				}
			}
		}
	}
}
