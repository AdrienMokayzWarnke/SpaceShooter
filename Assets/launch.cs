﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class launch : MonoBehaviour {

	public void Launch(){
		
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);

	}

	public void QuitGame(){
		Application.Quit ();
	}
}
