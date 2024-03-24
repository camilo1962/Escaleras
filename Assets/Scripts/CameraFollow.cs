using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private GameObject follower;

    private Vector3 offest;
  
    void Start()
    {
        offest = transform.position - follower.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = follower.transform.position + offest;
    }
}
