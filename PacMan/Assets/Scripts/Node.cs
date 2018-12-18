using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    SpriteRenderer render;
    SpriteRenderer pacMan;
    GameObject Pac;

    Vector2 position;
    public float distance = 0f;

    public Node left, right, up, down;

    void Start () 
    {
        render = this.GetComponent<SpriteRenderer>();//gets this gameobject S.R.
        Pac = GameObject.FindWithTag("Pacman");//finds pacman gameobject
        pacMan = Pac.GetComponent<SpriteRenderer>();//gets pacmans S.R.
        position = this.transform.position;//gets the position of this food
    }//end of start 
	
	void Update () 
    {
        
        distance = Mathf.Sqrt(Mathf.Pow(Pac.transform.position.x - position.x,2)+
                              Mathf.Pow(Pac.transform.position.y - position.y,2));

        //set distance to less that /.05
        //put this in a method and then when we set the sprite render equal to null
        //say when not null not to do this
	}//end of update
}