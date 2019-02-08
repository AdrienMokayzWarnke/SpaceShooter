using UnityEngine;
using System.Collections;

public class section_turn : MonoBehaviour
{
	public float rotation = 10f;
	Rigidbody rs;
	// Use this for initialization
	void Start ()
	{
		rs = gameObject.GetComponent<Rigidbody> ();
		rs.AddTorque (transform.up * rotation);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

