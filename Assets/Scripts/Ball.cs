﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed = 100.0f;
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.up*speed;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("On Collision");
		if(col.gameObject.name == "racket")
		{
			float x = hitFactor(transform.position,
			col.transform.position,col.collider.bounds.size.x);

			Vector2 dir = new Vector2(x, 1).normalized;

			GetComponent<Rigidbody2D>().velocity = dir*speed;
		}
		if(col.gameObject.name == "border_top"||col.gameObject.name == "border_right"||col.gameObject.name == "border_left")
		{
			Debug.Log("Hit wall and sped up");
			GetComponent<Rigidbody2D>().velocity = Vector2.down*speed;
		}
	}
	
	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
	{
		Debug.Log("hit factor");
		return(ballPos.x - racketPos.x)/racketWidth;
	}

	/*void FixedUpdate()
	{
		if((GameObject.Find("racket").transform.position.y)<GameObject.Find("ball").transform.position.y)
		{
			Debug.Log("Trying to quit");
			Application.Quit();
		}
	}*/
}
