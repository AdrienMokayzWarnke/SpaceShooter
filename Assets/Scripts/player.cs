using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
	public float movement_speed = 10.0f;
	public float rotate_speed = 2.0f;
	public int invert = 1;
	public GameObject explosion;
	public AudioSource sound;
	Rigidbody rs;
	// Use this for initialization
	void Start ()
	{
		rs = gameObject.GetComponent<Rigidbody> ();
	}
		
	// Update is called once per frame
	void Update ()
	{
		rs.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		transform.position += (new Vector3 (invert*Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0)) * movement_speed * Time.deltaTime;
		transform.position += new Vector3 (0f, 0f, -movement_speed*Time.deltaTime);
		transform.Rotate(new Vector3(0.0f,0.0f, rotate_speed * Input.GetAxis ("Barrel_left")));
		transform.Rotate(new Vector3(0.0f,0.0f, -rotate_speed * Input.GetAxis ("Barrel_right")));
	}
		
	public void PlayerEndGame(){
		GameController gameC = FindObjectOfType<GameController> ();
		if (gameC) {
			gameC.EndGame();
		}
	}

	public void Explode(){
		explosion.SetActive (true);
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag=="deadly") {
			Explode ();
			sound.Play ();
			GameController gameC = FindObjectOfType<GameController> ();
			if (gameC) {
				Invoke("PlayerEndGame",1f);
			}
		}
	}
		
}

