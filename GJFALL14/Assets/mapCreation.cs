using UnityEngine;
using System.Collections;

public class mapCreation : MonoBehaviour {
	
	public Camera cam; 
	public GameObject player; 
	public GameObject goalOfConq;

	public Transform floor_valid;
	public Transform floor_obstacle;

	public const char sfloor_valid = 'P';
	public const char sfloor_obstacle = 'W';
	public const char sstart = 'S'; 
	public const char sGoal = 'G'; 

	public Vector3 startPosition;


	public bool firstPlayer = false;
	
	public bool hasEstablishedGoal = false;
	int count = 0;
	int AorB = 0;
	int currentH = 0; 

	public int U = 0;
	public int L = 0;
	public int R = 0;
	public int D = 0;
	float bT;

	int Score = 0;
	int previousDirection = 0;
	private float startTime;
	private string ellapsedTime;
	
	void Awake(){
		startTime = Time.time;

		bT = PlayerPrefs.GetFloat("bTFL");
	}

	void Start(){
		Screen.SetResolution(1366, 768, true);
		string text = System.IO.File.ReadAllText("MAP4.txt");
		string[] lines = text.Split(new[]{ '\r', '\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		char[][]data;
		data = new char[lines.Length][];
		for(int i = 0; i < lines.Length; i++){
			data[i] = lines[i].ToCharArray();
		}
		for (int y = 0; y < data.Length; y++) {//for the height of the map
			for (int x = 0; x < data[0].Length; x++) {//for the width of the map
				switch (data[y][x]){
				case sfloor_valid:		 //if the characher is a .
					//Instantiate(floor_valid, new Vector3(x, -.2f, -y), Quaternion.identity);
					break;
				case sfloor_obstacle:
					Instantiate(floor_obstacle, new Vector3(x, -y, 0), Quaternion.identity);
					break;
				case sGoal:
					Instantiate(goalOfConq, new Vector3(x, -y, 0), Quaternion.identity);
					break;
				case sstart:
					player = Instantiate(player, new Vector3(x, -y, 0), Quaternion.identity) as GameObject;
					//Instantiate(floor_valid, new Vector3(x, -.2f, -y), Quaternion.identity);

					startPosition = new Vector3(x, 0, -y);
					break;
 
 
				}
			}
		} 
	//	InvokeRepeating("ch", .05f,.125f);
	//	InvokeRepeating("ch2", .05f,.125f);

	}	
	void Update(){  

		bool check = false;
		GameObject[] tiles = GameObject.FindGameObjectsWithTag("Finish");
		foreach(GameObject tile in tiles){
			BlockCode script = tile.GetComponent(typeof(BlockCode)) as BlockCode;
			if(script != null){
				if(script.hasFound == false){
					check = true;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.A)){
			check = false;
		}
		if(check == false){ 
			if(bT == 0){
				PlayerPrefs.SetFloat("bTFL", (Time.time-startTime));
			}else if(bT > (Time.time-startTime)){
				PlayerPrefs.SetFloat("bTFL", (Time.time-startTime));
			}
			Application.LoadLevel(0);
		}
		 
	}
 

	/*void OnGUI(){
		string y  = "CT  "+(Time.time - startTime).ToString();

		string x  = "BT  "+bT.ToString();
		ellapsedTime = (Time.time - startTime).ToString();
		GUI.Label(new Rect(10, 10, 100, 20), y);
		GUI.Label(new Rect(10, 30, 100, 20), x);

	}*/
}
