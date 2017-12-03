using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour 
{

	public Transform target;
	public float speed = 2f;
	private float minDistance = 1f;
	private float range;


	// Update is called once per frame
	void Update () 
	{
		//transform.LookAt (target);
		range = Vector2.Distance (transform.position, target.position);
		if (range > minDistance)
		{

			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}	
	}




}
