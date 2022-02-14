using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractor : MonoBehaviour
{

    public bool isPlayer = false;

    public Rigidbody2D rb;

    public bool Plus;


    //arduino stuff
    private string latestMessage;


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

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
        latestMessage = msg.Trim(); //remove new line character at end of string

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
