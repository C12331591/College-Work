using UnityEngine;
using System.Collections;

public class blockageTest : MonoBehaviour {

	private bool destroyed;

	// Use this for initialization
	void Start () {
		destroyed = false;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Gadget1")
		{
			destroyed = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (destroyed)
		{
			Destroy(this.gameObject);
		}
	}
}
