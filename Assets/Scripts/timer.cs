using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private float timeToDisplay = 0.0f;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDisplay += Time.deltaTime;
        timeText.text = timeToDisplay.ToString("0.00");
    }
}
