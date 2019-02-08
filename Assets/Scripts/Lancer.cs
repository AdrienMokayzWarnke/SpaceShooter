using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer : MonoBehaviour {

	public float force;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(0.0f,0.0f,-force));
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(0.0f,0.0f,-10));
	}
}
