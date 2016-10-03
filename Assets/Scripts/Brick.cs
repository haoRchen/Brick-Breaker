using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public GameObject smoke; //for smoke effects
	public AudioClip crack;//expose an audio clip
	public Sprite[] hitSprites;//store things that are similar
	private int timesHit;
	private LevelManager levelManager;
	public static int breakableCount = 0;//only one of this variable exist
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag =="breakable");//check object tag 
		//keep track of breakable bricks on creation
		if (isBreakable) {
			breakableCount++;

		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		//put audio source to where the brick is/was(when destroyed)
		//otherwise, the sound will cancel when a brick is destroyed. 
		//third parameter is for volume
		AudioSource.PlayClipAtPoint(crack, transform.position, 1f);
		if (isBreakable) {
			HandleHits();	
		}
	}

	void HandleHits(){
		print ("ball has hit the brick");
		timesHit++;
		int maxHits = hitSprites.Length + 1; //make the maxhit equal to array size +1
		if (timesHit >= maxHits) {
			breakableCount--;
			//get level manager to see if the player has won, then load new level if so. 
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy (gameObject);
		} else {
			//load the damaged sprite
			LoadSprites();
		}
	}
	void PuffSmoke(){
		//instantiate smoke at location of brick with default rotation, cast it as a GameObject to store in variable
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites(){
		//interger to store sprite index to access inside the array
		//starts counting at 0. eg. timeshit = 1, load index 0, then index 1. 
		int spriteIndex = timesHit - 1;
		//if sprite exist
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];	
		}else{
			Debug.LogError("no brick sprite!");
		}

	}
	//TODO remove this method once we can actually win!
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
