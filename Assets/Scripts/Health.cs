using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float playerHealth;

	private Camera camera;

	// Use this for initialization
	void Start () {
		camera = transform.GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth > 500) { //Caps health at 100
			playerHealth = 500;
		}

		if (playerHealth <= 0) {
			//Dead
			Debug.Log ("Player dead");
		}
	}

	private void UpdateCameraColor() {
		float redValue = (500 - playerHealth) / 500;
		Color newColor = new Color (redValue, 0f, 0f);

		camera.backgroundColor = newColor;
	}

	public void ReduceHealth() {
		playerHealth -= 1;
		Debug.Log (playerHealth);
		UpdateCameraColor ();
	}

	public void RecoverHealth() {
		playerHealth += 0.5f;
		Debug.Log (playerHealth);
		UpdateCameraColor ();
	}
}
