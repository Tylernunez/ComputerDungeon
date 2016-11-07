using UnityEngine;
using System.Collections;

public class platformMovement : MonoBehaviour {

	public float speed = 6.0F;
	private int direction = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Target")
		{
			if(direction == 1)
				direction = -1;
			else
				direction = 1;
		}
		if(other.tag == "Player")
			other.transform.parent = transform;
	}
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			other.transform.parent = null;
		}
	}
}
