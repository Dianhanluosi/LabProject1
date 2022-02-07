using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractor : MonoBehaviour
{

    public bool isPlayer = false;

    public Rigidbody2D rb;

    public bool Plus;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attractor[] attractors = FindObjectsOfType<attractor>();
        foreach(attractor attractor in attractors)
        {
            if (attractor.isPlayer && attractor != this)
            {
                if (attractor.Plus == Plus)
                {
                    Expell(attractor);
                }
                else
                {
                    Attract(attractor);

                }
            }
        }
    }

    void Attract(attractor objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }

    void Expell(attractor objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(-force);
    }

}
