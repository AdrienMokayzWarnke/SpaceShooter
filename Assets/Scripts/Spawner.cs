using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnerTime = 8.0f;
	public float spawnSpeed = 8.0f;
	public float distanceSpawn = 10.0f;
	public GameObject quille;
	public GameObject player;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("avion");
		if (player!=null) {
			spawnerTime += spawnSpeed; //* Vector3.Distance (Vector3.Normalize (gameObject.transform.position), Vector3.Normalize (player.transform.position)) + float.Epsilon;
		} else {
			Debug.Log ("No player ?!");
		}
	}
		
	// Update is called once per frame
	void Update ()
	{
		if(spawnerTime<Time.time){
			if (player) {
				if(Vector3.Distance(gameObject.transform.position,player.transform.position)> distanceSpawn && player.transform.position.z>-300.0f){
				Instantiate (quille, transform.position, transform.rotation);
				spawnerTime += spawnSpeed; // Vector3.Distance (Vector3.Normalize (gameObject.transform.position), Vector3.Normalize (player.transform.position)) + float.Epsilon;
				}
			} else {
				Debug.Log ("No player ?!");
			}
		}
	}
}

