using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float playerHealth;

	public float cameraDistance = -10f; 
	public float cameraLift = 1.5f;
    public SpriteRenderer noiseRender;

    private Camera camera;
	private CameraShake cameraShake;
    private ViewClip viewClip;
    private float maxHealth = 800f;

	// Use this for initialization
	void Start () {
		camera = transform.GetComponentInChildren<Camera> ();
		cameraShake = camera.GetComponent<CameraShake> ();
        viewClip = transform.GetComponentInChildren<ViewClip>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth > 800) { //Caps health at 800
			playerHealth = 800;
		}

		if (playerHealth <= 0) {
            //Dead
            Application.LoadLevel(4);
		}
	}

    private void UpdateNoiseRender()
    {
        Color temp = new Color(1f, 1f, 1f, 0f);
        temp.a = Mathf.Log((800 - playerHealth) / maxHealth) +  0.8f;
        noiseRender.color = temp;
    }

	private void CameraTwitch() {
		float twitchAmount = Mathf.Clamp ((maxHealth - playerHealth) / maxHealth, 0f, 1f);
		cameraShake.ChangeShakeAmount (twitchAmount);
		cameraShake.ChangeShakeDuration (1f);
	}

	public void ReduceHealth() {
		playerHealth -= 1f;
		//UpdateCameraColor ();
		CameraTwitch ();
        UpdateNoiseRender();
        viewClip.UpdateViewClip(playerHealth);
        
    }

	public void RecoverHealth() {
		playerHealth += 0.5f;
		//UpdateCameraColor ();
		CameraTwitch ();
        UpdateNoiseRender();
        viewClip.UpdateViewClip(playerHealth);
    }
}
