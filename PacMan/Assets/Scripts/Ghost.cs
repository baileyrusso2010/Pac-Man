using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public int speed = 4;
    public string ghostName;

    Vector2 direction;
    Vector2 screenPoint;//gets the screen position
    Vector2 position;//current position

    Node currentNode;//current node

    public GameObject Pac;

    int randPosition = 0;//gets random position

    List<Node> path;//path that the ghost has to take

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
   

    void Test()
    {
       
        randPosition = Random.Range(0, 9);//gets random position

        currentNode = GetNode();//gets the current node
        path = NodeList(randPosition,currentNode);//gets the path




    }//end of test

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

    List<Node> NodeList(int num, Node currenNode)
    {

        Node child = currenNode;
        List<Node> holderNode = new List<Node>();

        System.Random rand = new System.Random();
        int randomNum = rand.Next(0, 4);

        if (randomNum == 0)
        {
            
        }else if(randomNum == 1)
        {
            
        }else if(randomNum == 2)
        {
            
        }else if (randomNum == 3)
        {
            
        }

        if(num > 0)
        {
            while(true)
            {
                break;
            }


            num--;

        }
      

        return holderNode;
    }


    Node GetNode()
    {
        Node node = null;//sets to null

        node = manager.pieces[0];//gets first node

        for (int i = 0; i < manager.pieces.Count; i++)
        {
            if (manager.pieces[i].distance < node.distance)
            {
                node = manager.pieces[i];//new closest node
            }
        }

        return node;
    }//end of GetNode


}//end of scirpt