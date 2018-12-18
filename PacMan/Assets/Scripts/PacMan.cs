using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour {

    public int speed;//how fast the player goes

    Vector2 direction;//direction player goes
    Vector3 screenPoint;

    Transform child;//gets child object

    GameManager manager;//will only have one instance of gamemanager

	void Start () 
    {
        //gets gamemanager
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        child = this.gameObject.transform.GetChild(0);//gets first child
        direction = Vector2.right;//starts off going right

	}//end of start
	
	void Update () 
    {
        MovePacMan();

        transform.Translate(direction * speed * Time.deltaTime);//always moving 

        //transitions cordinates 
        screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        Debug.Log(GetNode().distance);

	}//end of update

    void MovePacMan()
    {
        Node node = GetNode();

        if (Input.GetKey(KeyCode.A) && node.left != null)
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 180);
            direction = Vector2.left;
        }

        if (Input.GetKey(KeyCode.D) && node.right != null)
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = Vector2.right;
        }

        if (Input.GetKey(KeyCode.W) && node.up != null)
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 90);
            direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.S) && node.down != null)
        {
            child.transform.rotation = Quaternion.Euler(0, 0, -90);
            direction = Vector2.down;
        }

        if (screenPoint.x > 1)
            this.transform.position = new Vector3(-transform.position.x, transform.position.y);
       
        if (screenPoint.x < 0)
            this.transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x 
                                                                                   ,transform.position.y);
    
    }//end of MovePacMan

    Node GetNode()
    {
        Node node = null;//sets to null

        node = manager.pieces[0];//gets first node

        for (int i = 0; i < manager.pieces.Count; i++)
        {
            if(manager.pieces[i].distance-.5 < node.distance)
            {
                node = manager.pieces[i];//new closest node
            }
        }
        return node;
    }





}//end of Script