using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float playerHealth;

	public float cameraDistance = -10f; 
	public float cameraLift = 1.5f;

	private Camera camera;
	private CameraShake cameraShake;

	// Use this for initialization
	void Start () {
		camera = transform.GetComponentInChildren<Camera> ();
		cameraShake = camera.GetComponent<CameraShake> ();
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

		CameraTwitch ();
	}

	private void UpdateCameraColor() {
		float redValue = (500 - playerHealth) / 500;
		Color newColor = new Color (redValue, 0f, 0f);

		camera.backgroundColor = newColor;
	}

	private void CameraTwitch() {
		float twitchAmount = Mathf.Clamp ((500 - playerHealth) / 500, 0f, 1f);
		cameraShake.ChangeShakeAmount (twitchAmount);
		cameraShake.ChangeShakeDuration (1f);
	}

	public void ReduceHealth() {
		playerHealth -= 1;
		Debug.Log (playerHealth);
		UpdateCameraColor ();
		CameraTwitch ();
	}

	public void RecoverHealth() {
		playerHealth += 0.5f;
		Debug.Log (playerHealth);
		UpdateCameraColor ();
		CameraTwitch ();
	}
}
