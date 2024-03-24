using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionResetTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        GameObject First=GetFirstStep();
        GameObject Last=GetLastStep();

        First.transform.position = new Vector3 (0 , Last.transform.position.y + 1 , Last.transform.position.z +2);

        if(SliderController.hasGameStarted ==true)
        {
            First.GetComponent<GenerateRandomObstacles>().Generate();
        }    

        Transform[] allTransform = GetAllRelevantTransforms();

        foreach (Transform t in allTransform)
        {
            t.position = new Vector3(t.position.x , t.position.y -1 , t.position.z - 2);
        }
        
    }

    private GameObject GetFirstStep()
    {
        GameObject[] steps = GameObject.FindGameObjectsWithTag("Step");
        GameObject firstStep= steps[0];
        float z = steps[0].transform.position.z;
        foreach(GameObject step in steps)
        {
            if(step.transform.position.z < z)
            {
                z = step.transform.position.z;
                firstStep = step;
            }
        }
        return firstStep;
    }

    private GameObject GetLastStep()
    {
        GameObject[] steps = GameObject.FindGameObjectsWithTag("Step");
        GameObject lastStep= steps[0];
        float z = steps[0].transform.position.z;
        foreach(GameObject step in steps)
        {
            if(step.transform.position.z > z)
            {
                z = step.transform.position.z;
                lastStep = step;
            }
        }
        return lastStep;
    }
    private Transform[] GetAllRelevantTransforms()
    {
        GameObject[] steps = GameObject.FindGameObjectsWithTag("Step");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject camera = Camera.main.gameObject;


        List<Transform> allTransforms = new List<Transform>();

        foreach(GameObject step in steps)
        {
            allTransforms.Add(step.transform);
        }
        allTransforms.Add(player.transform);
        allTransforms.Add(camera.transform);

        return allTransforms.ToArray();
    }
}
