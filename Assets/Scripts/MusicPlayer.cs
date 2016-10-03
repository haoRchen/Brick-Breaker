using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	//at the start scene, there will be no defined thing called instance. 
	//Hence why its null
	static MusicPlayer instance = null;
	// Use this for initialization
	
	void Awake(){
		//Debug.Log("Music Player Awake " + GetInstanceID());
		if(instance != null){
			Destroy (gameObject);
			print ("duplicate music player self-destructed!");
		}else{
			instance = this;
			//takes in a game object instance, and 
			//makes sure it does not get destroyed on load. 
			GameObject.DontDestroyOnLoad(gameObject);
			//gameObject with a small "g"is an object in the hierachy
		}
	
	}
	void Start () {
		//Debug.Log("Music Player start " + GetInstanceID());
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
