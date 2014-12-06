using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public float rLength = .25f;
 	bool canjump = true;
	int lastHit = 0;
	public Color c;
	bool caught = false;
	public int pNum = 0;
	private float startTime;
	private string ellapsedTime;

	bool canJumpLeft = true;
	bool canJumpRight = true;
	void Awake(){
		startTime = Time.time;
	}

	// Use this for initialization
	void Start () {
		c = new Color(Random.Range(0,.9f), Random.Range(0,.9f),Random.Range(0,.9f));
		renderer.material.color = c;


		if(transform.position.x <= 13 && transform.position.y >= -9){
			pNum = 1;
		}
		if(transform.position.x > 13 && transform.position.x <= 28  && transform.position.y >= -9){
			pNum = 2;
		}
		if(transform.position.x > 28 && transform.position.y >= -9){
			pNum = 3;
		}
		if(transform.position.x <= 13 && transform.position.y < -9 && transform.position.y >= -19){
			pNum = 4;
		}
		if(transform.position.x > 13 && transform.position.x <= 28  && transform.position.y < -9 && transform.position.y >= -19){
			pNum = 5;
		}
		if(transform.position.x > 28 && transform.position.y < -9 && transform.position.y >= -19){
			pNum = 6;
		}
		if(transform.position.x <= 13 && transform.position.y <=-20){
			pNum = 7;
		}
		if(transform.position.x > 13 && transform.position.x <= 28  && transform.position.y <=-20){
			pNum = 8;
		}
		if(transform.position.x > 28 && transform.position.y <=-20){
			pNum = 9;
		}
	}
	
	// Update is called once per frame
	void Update () {
 	
		bool leftHit = false;
		bool rightHit = false;

		Vector3 lft = transform.TransformDirection(Vector3.left);
		Vector3 rgt = transform.TransformDirection(-Vector3.left);
		Vector3 dwm = transform.TransformDirection(-Vector3.up);
		if(Physics.Raycast(transform.position, lft, .15f)){
			//Debug.Log("left3");
			canJumpRight = true;
 			if(lastHit != 1){
				lastHit = 1;
				canjump = true;
			}
		}
		if(Physics.Raycast(transform.position, rgt, .15f)){
			//Debug.Log("right3");
			canJumpLeft = true;
 			if(lastHit != 2){
				lastHit = 2;
				canjump = true;
			}
		}
		if(Physics.Raycast(transform.position, dwm, .15f)){
			//Debug.Log("down3");
			lastHit = 0;
			canJumpLeft = true;
			canJumpRight = true;
		}
		if(Physics.Raycast(new Vector3(transform.position.x+.1f,transform.position.y,transform.position.z), dwm, .15f)){
			//Debug.Log("down3");
			lastHit = 0;
			canJumpLeft = true;
			canJumpRight = true;
		}
		if(Physics.Raycast(new Vector3(transform.position.x-.1f,transform.position.y,transform.position.z), dwm, .15f)){
			//Debug.Log("down3");
			lastHit = 0;
			canJumpLeft = true;
			canJumpRight = true;
		}

		if(caught == false){
		if(Input.GetKeyUp (KeyCode.RightArrow) && canJumpRight == true){
				canJumpRight = false;
				audio.Play();
				transform.rigidbody.AddForce(Vector3.up * 400);
				transform.rigidbody.AddForce(Vector3.right * 300);
			
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow) && canJumpLeft == true){
				canJumpLeft = false;
				audio.Play();
				transform.rigidbody.AddForce(Vector3.up * 400);
				transform.rigidbody.AddForce(Vector3.right * -300);
			
			
		}
		if(Input.GetKeyUp(KeyCode.UpArrow)){ 
			//transform.rigidbody.AddForce(Vector3.up * 300);
			
		}
		if(Input.GetKeyUp(KeyCode.DownArrow)){ 
		}
		}

	}
		void OnCollisionEnter(Collision collision){
			Debug.Log(collision.gameObject.name);

			if(collision.gameObject.name == "goal(Clone)"){
			Debug.Log("EEEEEEEEEEEEEEEEE");
			}
		}
	void OnTriggerEnter(Collider collision) {

		Debug.Log(collision.gameObject.name);
		if(collision.gameObject.name == "goal(Clone)"){
			caught = true;
			transform.rigidbody.useGravity = false;
			transform.position = collision.gameObject.transform.position;
			transform.rigidbody.velocity = Vector3.zero;

			GameObject[] tiles = GameObject.FindGameObjectsWithTag("Finish");
			foreach(GameObject tile in tiles){
					BlockCode script = tile.GetComponent(typeof(BlockCode)) as BlockCode;
					if(script != null){
					script.alter(pNum);
				}
			}
				
		}
				
	}
	 

}
