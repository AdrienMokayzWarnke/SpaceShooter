using UnityEngine;
using System.Collections;

public class ShootForward : MonoBehaviour
{
	public GameObject bowl;
	public float velocity = 500.0f;
	public AudioSource sound;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1")){
			if (bowl) {
				if (sound) {
					sound.Play ();
				}
				GameObject newBullet = Instantiate (bowl, transform.position + new Vector3 (0.0f, 0.0f, -2.0f), transform.rotation);
				newBullet.GetComponent<Rigidbody>().AddForce ( new Vector3(0f,0f,-velocity));
			}
		}
	}
}
