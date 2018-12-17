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

	}//end of update

    void MovePacMan()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 180);
            direction = Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = Vector2.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            child.transform.rotation = Quaternion.Euler(0, 0, 90);
            direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
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
}//end of Script