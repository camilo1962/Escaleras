using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondManager : MonoBehaviour
{
    private static TextMeshProUGUI diamondsText;
    private static int diamondscore;
    public TMP_Text diamantesText, recordDiamantesText;

    private void Start()
    {
        diamondscore = 0;
        diamondsText = GetComponent<TextMeshProUGUI>();
    }

    public static int DiamondScore
    {
        get
        {
            return diamondscore;
        }
        set
        {
            diamondscore = value;
            diamondsText.text = diamondscore.ToString();
            PlayerPrefs.SetInt("diamantes", 0);
            
        }
    }
    public void Update()
    {
        
        diamantesText.text = diamondscore.ToString();
        recordDiamantesText.text = PlayerPrefs.GetInt("diamantes", 0).ToString();
        if (diamondscore > PlayerPrefs.GetInt("diamantes", 0))
        {
            PlayerPrefs.SetInt("diamantes", diamondscore);
            recordDiamantesText.text = PlayerPrefs.GetInt("diamantes", 0).ToString();
        }

    }

    private void OnDestroy()
    {
        diamondscore=0;
    }
}
