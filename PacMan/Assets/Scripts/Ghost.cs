using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public int speed = 4;
    public string ghostName;

    Vector2 direction;
    Vector2 screenPoint;//gets the screen position
    Vector2 position;//current position

    public Node currentNode;//current node

    public GameObject Pac;

    int randPosition = 0;//gets random position

    public List<Node> path;//path that the ghost has to take
    List<Vector2> dir = new List<Vector2>();

    GameManager manager;//will only have one instance of gamemanager
    int x = 0;

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
        Test();

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

        if (x == 0)
        {
            Debug.Log("sdfs");
            randPosition = Random.Range(40, 60);//gets random position
            currentNode = GetNode();//gets the current node
            path = NodeList(randPosition, currentNode);//gets the path
            x++;

        }

        if (NodeDistance(path[0]) > 1f)
        {

            Movement();
            direction = dir[0];

        }
        else
        {
            path.RemoveAt(0);
            dir.RemoveAt(0);
            if (path.Count == 0)
                x = 0;
        }

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

    void Movement()
    {


        transform.Translate(direction * speed * Time.deltaTime);

 
    }


    List<Node> NodeList(int num, Node currNode)
    {
        Node testNode = currNode;
        List<Node> holderNode = new List<Node>();//list of nodes to return
        Node previousNode = testNode;
        System.Random rand = new System.Random();
        Vector2 d = Vector2.zero;
        int r = 0;
        int counter = 0;

        while(num > 0)
        {
            while (true)
            {
                if (counter < 10)
                {
                    r = rand.Next(1, 5);
                }
                else
                {
                    r = 0;

                }
                if (r==1&& testNode.up != null && testNode.up != previousNode)//up
                {
                    previousNode = testNode;
                    d = Vector2.up;
                    testNode = testNode.up;

                    break;
                }
                else if (r==2 && testNode.left != null && testNode.left != previousNode)//left
                {
                    previousNode = testNode;
                    testNode = testNode.left;
                    d = Vector2.left;

                    break;
                }

                else if (r==3 && testNode.down != null && testNode.down != previousNode)//down
                {
                    previousNode = testNode;
                    d = Vector2.down;
                    testNode = testNode.down;
                    break;
                }
                else if (r==4 && testNode.right != null && testNode.right != previousNode)//right
                {
                    previousNode = testNode;
                    d = Vector2.right;
                    testNode = testNode.right;

                    break;
                }
                counter++;


            }//end of while looop
                

            holderNode.Add(testNode);//add to node list
            dir.Add(d);
            num--;

        }//end of numOfNodes if
      

        return holderNode;
    }//end of NodeList


    Node GetNode()
    {
        Node node = null;//sets to null

        node = manager.pieces[0];//gets first node

        for (int i = 0; i < manager.pieces.Count; i++)
        {
            if (NodeDistance(manager.pieces[i]) < NodeDistance(node))
            {
                //only checks pacmans position not nodes position
                node = manager.pieces[i];//new closest node
            }
        }

        return node;
    }//end of GetNode

    float NodeDistance(Node node)
    {
        return Mathf.Sqrt(Mathf.Pow(node.transform.position.x - position.x, 2) +
                          Mathf.Pow(node.transform.position.y - position.y, 2));
    }//end of NodeDistance



}//end of scirpt