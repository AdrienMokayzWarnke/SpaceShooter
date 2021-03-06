using UnityEngine;
using System.Collections;

public class bullet_rules : MonoBehaviour
{

	public GameObject plane;
	public float maxDistance = 12.0f;
	public float lifetime = 5.0f;


	// Use this for initialization
	void Start ()
	{
	
	}
	void Awake(){
		if (GameObject.FindGameObjectsWithTag ("avion").Length > 0) {
			plane = GameObject.FindGameObjectWithTag ("avion");
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if(plane){
			float dist = Vector3.Distance (plane.transform.position, transform.position);
			if(dist > maxDistance){
				if (gameObject) {
					Destroy (gameObject);
				}
			}
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name != "Wall_bot" && col.gameObject.name != "Wall_top" && col.gameObject.name != "avion") {
			Destroy (gameObject);
		}
	}
}

