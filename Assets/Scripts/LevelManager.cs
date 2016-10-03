using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//load new level
	public void LoadLevel(string name) {
		Debug.Log("Level load requested for: " + name);
		Application.LoadLevel(name);
		Brick.breakableCount = 0;//reseting the amount of breakables
	}
	
	public void QuitRequest(){
		Debug.Log("i want to quit!");
		Application.Quit();
	}
	public void LoadNextLevel(){
		Brick.breakableCount = 0;//reseting the amount of breakables
		//load next level in the build sequence 
		Application.LoadLevel(Application.loadedLevel+1);
		
	}
	public void BrickDestroyed(){
		//if the last brick has been destroyed
		//brick's static breakablecount is accessable by all
		if(Brick.breakableCount <= 0){
		   LoadNextLevel();
		}
	}
}
