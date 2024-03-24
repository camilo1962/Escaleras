using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour 
{
    public static bool hasGameStarted;
    public GameObject Instructions;
    
    private Transform avatarTransform;
    private Slider movementSlider;
    private float multiplier = 2.655f;

    void Start()
    {
        movementSlider = GetComponent<Slider>();
        avatarTransform = GameObject.FindGameObjectWithTag("Player").transform;

        movementSlider.onValueChanged.AddListener(delegate {SliderChange();});

         movementSlider.onValueChanged.AddListener(delegate {GameStart();});

    }
    public void SliderChange()
    {
        avatarTransform.position = new Vector3(movementSlider.value * (multiplier + 2.25f) , avatarTransform.position.y , avatarTransform.position.z);
    }

    public void GameStart()
    {
        hasGameStarted =true;
        Instructions.SetActive(false);
        movementSlider.onValueChanged.RemoveAllListeners();
        movementSlider.onValueChanged.AddListener(delegate {SliderChange();});

    }

    private void OnDestroy()
    {
        hasGameStarted =false;
    }
}
