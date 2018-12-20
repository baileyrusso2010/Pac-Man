using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public int speed = 4;
    public string ghostName;

    Vector2 direction;
    Vector2 screenPoint;
    Vector2 position;

    Node currentNode;

    public GameObject Pac;

    GameManager manager;//will only have one instance of gamemanager


    /*
     * Note it looks like 
     * all the ghosts have
     * pre determined positions
     * so dont update every frame
     */



    void Start()
    {
        Pac = GameObject.FindWithTag("Pacman");//finds pacman gameobject
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        position = this.transform.position;
    }

    void Update()
    {
        position = this.transform.position;    
    }

    void Chase()
    {
        /*
         * Will have to find pacmans position
         * and possible where he is facing
         * and then make the determination
         * of what to do. get in front of him
         * or chase him fastely
         */

    }//end of chase
   
    void Scatter()
    {

        /*
         * need to manually input cordinates
         * so that the ghosts
         * know where to go
         * have bool to say which ghost is which
        */
    }//end of chase 

    void Frighten()
    {
        /*
         * If pacman eats the food
         * go somewhere away from him
         */



    }

    float Distance()
    {

        return Mathf.Sqrt(Mathf.Pow(Pac.transform.position.x - position.x, 2) +
                      Mathf.Pow(Pac.transform.position.y - position.y, 2));
    }

}//end of scirpt