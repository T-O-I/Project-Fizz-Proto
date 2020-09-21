using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupController : MonoBehaviour
{
    private Transform cupTransform;
    // Start is called before the first frame update
    void Start()
    {
        cupTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float rtInput = Input.GetAxisRaw("Trigger Right");
        float ltInput = Input.GetAxisRaw("Trigger Left");// * -1;

        if(rtInput > 0)
        {
            cupTransform.Rotate(0, 0, rtInput * 0.15f);
        }
        if(ltInput > 0)
        {
            cupTransform.Rotate(0, 0, ltInput * -0.15f);
        }
    }
}
