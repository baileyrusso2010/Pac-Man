using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    GameObject[] nodes;
    public List<Node> pieces;

    public int lives;//number of lives


    void Start () {

        nodes = GameObject.FindGameObjectsWithTag("food");
        for (int i = 0; i < nodes.Length;i++)
        {
            pieces.Add(nodes[i].GetComponent<Node>());

        }
	}
	
	void Update () {
		
	}//end of update

    void Restart()
    {


    }//end of restart

}//end of script