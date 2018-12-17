using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] nodes;

    void Start () {

        nodes = GameObject.FindGameObjectsWithTag("food");
	}
	
	void Update () {
		
	}

    void Test() 
    {
        Debug.Log("we in this bitch");
    }
}