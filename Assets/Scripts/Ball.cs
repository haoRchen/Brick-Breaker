using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		//adds Paddle object programmatically
		paddle = GameObject.FindObjectOfType<Paddle>();
		//get difference between ball and paddle position
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector);
		
	}
	
	// Update is called once per frame
	void Update () {
		//if game has not started, then lock the ball to paddle
		if (!hasStarted) {
			// makes the ball stay with the paddle at the beginning of the game
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//if started then add velocity to ball. 
			if(Input.GetMouseButtonDown(0)){
				print("mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}

	}
	void OnCollisionEnter2D(Collision2D collision){
		//add random value of x and y to velocity.
		Vector2 tweak = new Vector2(Random.Range (0f, 0.2f), Random.Range (0f,0.2f));
		if(hasStarted){
		GetComponent<AudioSource>().Play();
		//velocity is a 3d vector, even if the rigidbody is 2d. 
		GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
