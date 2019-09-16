using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour {
	public bool isFalling = false;
	float speed = 5f;
	Vector2 posRack = Vector2.zero;

	void Start()
	{
		posRack = GameObject.Find("racket").transform.position;
	}
	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(isFalling == false)
		{
			Debug.Log("set it to true");
			isFalling = true;
		}
		else
		{
			Debug.Log("destroying");
			Destroy(gameObject);
		}
		if(collisionInfo.gameObject.name == "racket")
		{
			Debug.Log("quit because racket");
			SceneManager.LoadScene("RestartScreen");
		}
	}
	
	void FixedUpdate()
	{
		if(isFalling == true)
		{
			Vector2 newPos = gameObject.transform.position;
			newPos.y += -.1f;
			gameObject.transform.position = newPos;
		}
		if(gameObject.transform.position.y<=posRack.y)
		{
			Debug.Log("Block out of game");
			SceneManager.LoadScene("RestartScreen");
		}
	}
}
