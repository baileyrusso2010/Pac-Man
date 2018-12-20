using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour {

    //https://theuijunkie.com/pac-man-ghosts-movement/

    public int speed;//how fast the player goes

    Vector2 direction;//direction player goes
    Vector3 screenPoint;

    Transform child;//gets child object

    GameManager manager;//will only have one instance of gamemanager

    public Node headNode;//get current node

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
        headNode = GetNode();

        if (canMove(headNode) == true)
        {
            transform.Translate(direction * speed * Time.deltaTime);//always moving 
        }
        else
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,
                                                                 transform.position.y),
                                                     new Vector2(headNode.transform.position.x,
                                                                 headNode.transform.position.y),
                                                        speed * Time.deltaTime);
        //transitions cordinates for screen wrapping
        screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);

	}//end of update

    bool canMove(Node node)
    {
        if(node.left == null && direction == Vector2.left)
        {
            return false;

        }
        if (node.right == null && direction == Vector2.right)
        {
            return false;

        }
        if (node.up == null && direction == Vector2.up)
        {
            return false;

        }
        if (node.down == null && direction == Vector2.down)
        {
            return false;

        }

        return true;
    }//end of canMove

    void MovePacMan()
    {
        Node node = GetNode();

        if (Input.GetKey(KeyCode.A) && node.left != null)
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.position = new Vector3(this.transform.position.x, node.transform.position.y);
            direction = Vector2.left;
        }

        else if (Input.GetKey(KeyCode.D) && node.right != null)
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(this.transform.position.x, node.transform.position.y);
            direction = Vector2.right;
        }

        else if (Input.GetKey(KeyCode.W) && node.up != null)
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.position = new Vector3(node.transform.position.x,this.transform.position.y);
            direction = Vector2.up;
        }

        else if (Input.GetKey(KeyCode.S) && node.down != null)
        {
            child.transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.position = new Vector3(node.transform.position.x, this.transform.position.y);

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
            if(manager.pieces[i].distance < node.distance)
            {
                node = manager.pieces[i];//new closest node
            }
        }

        return node;
    }//end of GetNode

}//end of Script