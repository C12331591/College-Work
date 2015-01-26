using UnityEngine;
using System.Collections;

public class keyPickup : MonoBehaviour {

	public bool red, green, blue;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (red)
			{
				col.gameObject.GetComponent<playerStatus>().redKey = true;
			}

			if (green)
			{
				col.gameObject.GetComponent<playerStatus>().greenKey = true;
			}

			if (blue)
			{
				col.gameObject.GetComponent<playerStatus>().blueKey = true;
			}

			Destroy(this.gameObject);
		}
	}
}
