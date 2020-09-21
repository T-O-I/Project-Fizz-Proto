using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawn : MonoBehaviour
{
    public GameObject particle;
    public int particleAmount = 60;
    private Transform spawnTransform;
    private float timeRemaining = 2.5f;
    float interval = 0.05f;
    float nextTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTransform = GetComponent<Transform>();
        InvokeRepeating("spawnParticle", 0.0f, 0.025f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            CancelInvoke();
        }
        if (Input.GetKey("x"))
        {
            if(Time.time >= nextTime)
            {
                spawnParticle();
                nextTime += interval;
            }
        }
    }

    public void spawnParticle()
    {
        GameObject p = Instantiate(particle, spawnTransform.position, Quaternion.identity);
        Rigidbody2D r2d = p.GetComponent<Rigidbody2D>();
        float rangeX = Random.Range(-10.0f, 10.0f);
        float rangeY = Random.Range(-10.0f, 10.0f);
        r2d.AddForce(new Vector2(rangeX, rangeY));
    }
}
