using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomObstacles : MonoBehaviour
{
    public void Generate()
    {
        ResetSlots();

        int numberofSpikes = Random.Range(0,5);

        while(numberofSpikes !=0)
        {
             int randomIndex = Random.Range(0,5);
             if(transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle != Obstacle.spike)
             {
                transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle = Obstacle.spike;
                numberofSpikes--;
             }   
        }


        int numberofDiscs = 1;

        while(numberofDiscs !=0)
        {
             int randomIndex = Random.Range(0,5);
             if(transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle == Obstacle.empty)
             {
                transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle = Obstacle.disc;
                numberofDiscs--;
             }   
        } 

        int numberofDiamond = 1;
        int chanceofDiamonds = Random.Range(5,15);
        int count = 0;


        while(numberofDiamond !=0)
        {
             int randomIndex = Random.Range(0,5);
             if(transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle == Obstacle.empty)
             {
                transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle = Obstacle.diamond;
                numberofDiamond--;
             }   

             count++;

             // stops the loop
             if(count == 6)
              numberofDiamond = 0;
        } 
    }

    private void ResetSlots()
    {
        for(int i=0 ; i<transform.childCount ; i++)
        {
            Slot slot = transform.GetChild(i).GetComponent<Slot>();
            if(slot != null)
            {
                slot.Obstacle = Obstacle.empty;
            }
        }

    }
}
