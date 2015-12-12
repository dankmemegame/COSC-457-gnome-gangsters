﻿using UnityEngine;
using System.Collections;

public class ImpossibruAI : MonoBehaviour {

	public bool seen = false;
	Vector3 player_pos;
	Vector3 position;
	public GameObject projectile;
	public float speed = 0.1f;
	private Rigidbody2D rigid;// = GetComponent<Rigidbody2D>();
	public static CircleCollider2D cc;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		//Debug.Log ("Pancake");
	}
	
	// Update is called once per frame
	void Update () {
		if (seen)
		{

			player_pos = PlayerController.player.transform.position;
			position = this.transform.position - player_pos;

			if(position.x < 0.2f)
			{
				this.transform.Rotate(0.0f, 0.0f, -10.0f);
				//rigid.velocity = new Vector3(speed, rigid.velocity.y, 0.0f);
			}
			else if(position.x > -0.2f)
			{
				this.transform.Rotate(0.0f, 0.0f, 10.0f);
				//rigid.velocity = new Vector3(-speed, rigid.velocity.y, 0.0f);
			}
			/*
			if(position.y < 0.2f)
			{
				rigid.velocity = new Vector3(rigid.velocity.x, speed, 0.0f);
			}
			else if(position.y > -0.2f)
			{
				rigid.velocity = new Vector3(rigid.velocity.x, -speed, 0.0f);
			}
			*/

			//use normalize subtraction of positions as the velocity vector
			rigid.velocity = -Vector3.Normalize(position)*speed;

		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("enter");
		GameObject collided_with = other.gameObject;
		if ( collided_with.tag == "Player" ) {
			seen = true;
		}
		if (collided_with.tag == "Fireball") {
			Destroy (transform.parent.gameObject);
		}
	}

	void setSeen()
	{
		seen = true;
	}

	void OnDestroy()
	{
		//float randomAngle;
		Debug.Log ("Is anyone there?");
		float randomX;
		float randomY;
		GameObject clone;
		for(int i = 0; i < 4; i++)
		{
			//randomAngle = Random.value * 360 * Mathf.Rad2Deg;
			randomX = transform.position.x + Random.value*2-1;
			randomY = transform.position.y + Random.value*2-1;
			clone = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
			clone.transform.LookAt(new Vector3(randomX, randomY, 1f));
			clone.GetComponent<Rigidbody2D>().velocity = clone.transform.forward * 15.0f;
		}

	}
}
