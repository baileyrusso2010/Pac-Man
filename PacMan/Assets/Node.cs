using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    SpriteRenderer render;
    SpriteRenderer pacMan;

	// Use this for initialization
	void Start () 
    {
        render = this.GetComponent<SpriteRenderer>();
        pacMan = GameObject.FindWithTag("Pacman").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}