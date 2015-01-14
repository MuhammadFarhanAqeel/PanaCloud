using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject obstacle;
	public GameObject powerup;

	float timeElapsed = 0;
	float spawnCycle = 0.5f;
	bool spawnPowerUp = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed > spawnCycle) {
			GameObject temp;
			if(spawnPowerUp)
			{
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-4,4), 1,40);
			}
			else
			{
				temp = (GameObject)Instantiate(obstacle);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-4,4), 1,40);
			}


			timeElapsed-=spawnCycle;
			spawnPowerUp = ! spawnPowerUp;


		}

	}
	/*void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "wall")
		   {
			Destroy(col.gameObject);
			Debug.Log("Done");
		}
	}*/
}
