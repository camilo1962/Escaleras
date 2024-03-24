using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarMove : MonoBehaviour
{
    Camera main;
    float avatarYSpeed,avatarZSpeed;
    public Joystick joystick;
    void Start()
    {
	   avatarYSpeed = 1 * Time.fixedDeltaTime;
       avatarZSpeed = 2 * Time.fixedDeltaTime;
       main=Camera.main;
    }

    void FixedUpdate()
    {
	   transform.position = new Vector3(transform.position.x , transform.position.y + avatarYSpeed , transform.position.z + avatarZSpeed);
       main.transform.position= new Vector3(main.transform.position.x,main.transform.position.y + avatarYSpeed,main.transform.position.z + avatarZSpeed);

       if(transform.position.y < 0)
         SceneManager.LoadSceneAsync( 0 , LoadSceneMode.Single); 
    }

}
