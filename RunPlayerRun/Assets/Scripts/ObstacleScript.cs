using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {

	public float objectSpeed = -0.5f;
	public GameControlScript pControl;
	
	// Use this for initialization
	void Start () {
		}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1) {
						transform.Translate (0, 0, objectSpeed);
				}
	}
}



