using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay = true; 
	private Ball ball;
	
	void Start(){
	//stores Ball object in ball variable. 
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay)
		{
			MoveWithMouse();
		}else{
			AutoPlay();
		}
			
	}
	
	void AutoPlay(){
		//vector3 is basically a struct with 3 floats, "f" signifies float
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y,0f);
		Vector3 ballPos = ball.transform.position; //get ball position
		//print (mousePosInBlocks);//16 == gameworld units
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
		
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse(){
		//vector3 is basically a struct with 3 floats, "f" signifies float
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y,0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		//print (mousePosInBlocks);//16 == gameworld units
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		
		this.transform.position = paddlePos;
	}
}
