using UnityEngine;
using System.Collections;

public class camera_follow : MonoBehaviour
{	
	
	public float movement_speed = 10.0f;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update (){
			transform.position += new Vector3 (0f, 0f, -movement_speed*Time.deltaTime);
		}
	
}