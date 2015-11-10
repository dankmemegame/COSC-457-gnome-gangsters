﻿using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
    public int timer;
	// Use this for initialization
	void Start () {
        timer = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer -= 1;
        if (timer == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag != "player")
	        Destroy(this.gameObject);

		if (collision.tag == "mob")
			Destroy (collision.gameObject);
    }
}