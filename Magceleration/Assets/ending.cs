using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class ending : MonoBehaviour
{
    public bool end = false;

    public Transform tr;

    public SpriteRenderer sr;

    public float rate;

    public float scale;

    public MagBallController mc;

    public bool reload = false;

    public float cd = 3f;

    public string MyComPort;
    public SerialPort serial;
    public SerialController serialController;


    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();

        sr = gameObject.GetComponent<SpriteRenderer>();


        serial = new SerialPort(MyComPort, 9600);

    }

    // Update is called once per frame
    void Update()
    {
       
        

        if (end)
        {

            TurnOnLight(1);
            
                scale = rate * Time.deltaTime;

            tr.localScale = new Vector2(tr.localScale.x + scale, tr.localScale.y + scale);

            reload = true;
        }


        if (mc.numOfChange == 0 && !end)
        {

            TurnOnLight(2);

            sr.color = new Color(1f, 0.175f, 0.3f, 1f);

            scale = rate * Time.deltaTime;

            tr.localScale = new Vector2(tr.localScale.x + scale, tr.localScale.y + scale);

            reload = true;
        }

        if (reload)
        {
            cd -= Time.deltaTime;
            if (cd <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            end = true;

        }
    }

    public void TurnOnLight(int LightNum)
    {
        
        if (serial.IsOpen == false)
        { serial.Open(); }
        if (LightNum == 1) { serialController.SendSerialMessage("A"); }
        if (LightNum == 2) { serialController.SendSerialMessage("B"); }

    }

}
