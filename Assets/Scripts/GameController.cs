using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private static GameController instance;

	public GameObject pauseMenuUI;

	public Button retryButton;

	public Button resumeButton;

	public Scrollbar health;

	public float playerHealth;

	public int score;

	public bool gameOver = false;

	public Text scoreText;

	public Text info;

	public bool gameIsPaused;

	public int killStreak = 0;

	public AudioSource killingSpree;
	public AudioSource monsterKill;
	public AudioSource gameOverSound;


	 
	public static GameController Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<GameController> ();
			}
			if (FindObjectsOfType<GameController> ().Length > 1) {
				Debug.LogError ("There is more than 1 GameController wtf dude !");
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start ()
	{
		playerHealth = 1.0f;
		
	}

	public void EndGame(){
		if (gameOver == false) {
			gameOver = true;
			gameOverSound.Play ();
			info.color = new Color32 (255, 0, 0, 255);
			info.text = "YOU DIED";
			pauseMenuUI.SetActive (true);
			retryButton.gameObject.SetActive (true);
			resumeButton.gameObject.SetActive (false);
			Time.timeScale = 0f;
		}
	}

	public void AddScore (int newScore){
		score += newScore;
		info.color = new Color32 (255, 0, 255, 255);
		info.text = "+ " + newScore;
		killStreak++;
		if (killStreak > 6 && killStreak < 12) {
			info.text += " KILLING SPREE !!!";
			killingSpree.Play ();
		} else if (killStreak > 12) {
			info.text += " MOMOMOMOOONSTER KILL !!!";
			monsterKill.Play ();
		}
		UpdateScore ();
	}
	public void UpdateScore(){
		scoreText.text = "Score: " + score;

	}
	public void UpdateHealth(float newHealth){
		health.size += newHealth;
		playerHealth += newHealth;
		info.color = new Color32 (255, 0, 0, 255);
		info.text = "Wasted ! " + newHealth*100.0f;
		killStreak = 0;
	}

	public void Restart(){
		gameOver = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void Pause(){
		pauseMenuUI.SetActive (true);
		resumeButton.gameObject.SetActive (true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void QuitGame(){
		Application.Quit ();
	}
	// Update is called once per frame
	void Update ()
		{
		if (playerHealth < 0.0f) {
			player player = FindObjectOfType<player> ();
			if (player) {
				player.Explode ();
			}
			Invoke("EndGame",1f);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gameIsPaused == true && gameOver == false) {
				Resume ();
			} else if(gameIsPaused == false && gameOver == false){
				Pause ();
			}
		}
	}
}

