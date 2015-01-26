using UnityEngine;
using System.Collections;

public class playerLight : MonoBehaviour {

	private bool held;
	public bool hasLight;

	// Use this for initialization
	void Start () {
		this.light.enabled = false;
		held = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("l"))
		{
			if (hasLight && !held)
			{
				this.light.enabled = !this.light.enabled;
			}

			held = true;
		}
		else
		{
			held = false;
		}
	}
}
