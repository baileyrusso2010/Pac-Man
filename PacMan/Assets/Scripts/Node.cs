using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public SpriteRenderer render;
    public Sprite sp;
    public SpriteRenderer pacMan;
    GameObject Pac;
    public bool isFood = false;

    Vector2 position;
    public float distance = 0f;

    public Node left, right, up, down;
    GameManager manager;//will only have one instance of gamemanager


    void Start () 
    {
        render = this.GetComponent<SpriteRenderer>();//gets this gameobject S.R.
        sp = render.sprite;

        Pac = GameObject.FindWithTag("Pacman");//finds pacman gameobject
        pacMan = Pac.transform.GetChild(0).GetComponent<SpriteRenderer>();//gets pacmans S.R.
        position = this.transform.position;//gets the position of this food
       //render.sprite = null;
    }//end of start 
	
	void Update () 
    {
        //distance between pacman and this
        distance = Mathf.Sqrt(Mathf.Pow(Pac.transform.position.x - position.x,2)+
                              Mathf.Pow(Pac.transform.position.y - position.y,2));

        if (distance < .5f)
            render.sprite = null;

        //set distance to less that /.05
        //put this in a method and then when we set the sprite render equal to null
        //say when not null not to do this
	}//end of update
}