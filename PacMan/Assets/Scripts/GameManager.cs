using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject[] nodes;
    public List<Node> pieces;
    public List<Ghost> gh;

    public int level;

    public int score;
    public int lives;//number of lives

    private int nodeLength;

    void Start () 
    {

        nodes = GameObject.FindGameObjectsWithTag("food");
        for (int i = 0; i < nodes.Length;i++)
        {
            pieces.Add(nodes[i].GetComponent<Node>());

        }
	}//end of start
	
	void Update () {
		
	}//end of update

    public void PacmanDied()
    {
        //reset ghost positions
        if(lives > 0)
        {
            lives--;
            //need a spawn point to reset pacman 

            //ghosts need to go back to home

        }else
        {
            //go to end screen
        }

    }//end of PacmanDied

    void NextLevel()
    {
        for (int i = 0; i < pieces.Count;i++)
        {
            //will reset all of the pieces
            pieces[i].render.sprite = pieces[i].sp;
        }

    }//end of restart

}//end of script