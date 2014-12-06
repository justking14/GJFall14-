using UnityEngine;
using System.Collections;
public class BlockCode : MonoBehaviour {
	public Color c;
	public Color c2;
	public Color c3;
	int blockNum = 0;
	public bool hasFound = false;
	// Use this for initialization
	void Start () {
		if(transform.position.x <= 13 && transform.position.y >= -9){
			renderer.material.color = Color.cyan;
			blockNum = 1;
		}
		if(transform.position.x > 13 && transform.position.x <= 28  && transform.position.y >= -9){
			renderer.material.color = Color.blue;
			blockNum = 2;
		}
		if(transform.position.x > 28 && transform.position.y >= -9){
			renderer.material.color = Color.green;
			blockNum = 3;
		}
		if(transform.position.x <= 13 && transform.position.y < -9 && transform.position.y >= -19){
			renderer.material.color = Color.red;
			blockNum = 4;
		}
		if(transform.position.x > 13 && transform.position.x <= 28  && transform.position.y < -9 && transform.position.y >= -19){
			renderer.material.color = Color.white;
			blockNum = 5;
		}
		if(transform.position.x > 28 && transform.position.y < -9 && transform.position.y >= -19){
			renderer.material.color = Color.yellow;
			blockNum = 6;
		}
		if(transform.position.x <= 13 && transform.position.y <=-20){
			renderer.material.color = Color.magenta;
			blockNum = 7;
		}
		if(transform.position.x > 13 && transform.position.x <= 28  && transform.position.y <=-20){
			renderer.material.color = c2;
			blockNum = 8;
		}
		if(transform.position.x > 28 && transform.position.y <=-20){
			renderer.material.color = c3;
			blockNum = 9;
		}
	}
	
	// Update is called once per frame
	void Update () {
 
	}
	public void alter(int type){
		if(type == blockNum){
			hasFound = true;
			renderer.material.color = c;
		}
	}
}
