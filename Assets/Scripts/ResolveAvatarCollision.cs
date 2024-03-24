using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolveAvatarCollision : MonoBehaviour
{
    float gravity = -9.81f;
    public AudioSource audio;
    public AudioClip clip_diamond , clip_disc, clip_GameOver;
    public GameObject panelGameOver;
    
    void Start()
    {
        Physics.gravity = Vector3.up * gravity *2;
        panelGameOver.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts[0].point.z < 2.4f)
        {
           GetComponent<Rigidbody>().velocity = new Vector3(0f , gravity * -1 , 0f);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0f , gravity * -0.95f , 0f);
        }

        if(SliderController.hasGameStarted==false)
          return;

        if(collision.gameObject.GetComponent<GenerateRandomObstacles>() != null)
        {
            if(!IsDiskAlsothere(collision.transform))
            {
                 ScoreManager.ScoreModifier = 0;
                 ScoreManager.Score ++;
                 ScoreManager.ScoreCounterPosition = collision.contacts[0].point;
                 ScoreManager.ScoreCounterParent =collision.transform;
            }
             
        }
        else
        {
            Slot slot = collision.transform.parent.GetComponent<Slot>();
            ResolveCollision(slot , collision.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PositionResetTrigger>() != null)                  
            return;
        
       
        Slot slot = other.transform.parent.GetComponent<Slot>();
        ResolveCollision(slot , other.gameObject);
    }

    private void ResolveCollision(Slot slot , GameObject other)
    {
        if(slot == null)
        
           
            return;
        
           

        switch(slot.Obstacle)
        {
            case Obstacle.disc:
              ScoreManager.ScoreModifier++;
              ScoreManager.Score++;
              ScoreManager.ScoreCounterPosition = new Vector3(transform.position.x , transform.position.y - 0.5f , transform.position.z);
              ScoreManager.ScoreCounterParent = other.transform.parent.parent;
              audio.clip=clip_disc;
              audio.Play();
              break;
            case Obstacle.spike:
              panelGameOver.SetActive(true);
                audio.clip = clip_GameOver;
                audio.Play();
                GameOver();
                //SceneManager.LoadSceneAsync( 0 , LoadSceneMode.Single); 
                break;
            case Obstacle.diamond:  
              Destroy(other);
              DiamondManager.DiamondScore++;
              audio.clip=clip_diamond;
              audio.Play();
              break;  
        }  
    }

    private bool IsDiskAlsothere(Transform stepTransform)
    {
        for(int i=0 ; i<stepTransform.childCount; i++)
        {
            if(stepTransform.GetChild(i).childCount == 0)
            {
                continue;
            }

            if(stepTransform.GetChild(i).GetComponent<Slot>().Obstacle == Obstacle.disc)
            {
                Vector3 discPos = stepTransform.GetChild(i).GetChild(0).position;
                float extents = stepTransform.GetChild(i).GetChild(0).GetComponent<BoxCollider>().bounds.extents.x;

                if(transform.position.x <= discPos.x + extents && transform.position.x >= discPos.x - extents)
                {
                    return true;
                }
            }
        }

        return false;
    }
    private void GameOver()
    {
        Physics.gravity = Vector3.up * 0f;
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Repetir()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
