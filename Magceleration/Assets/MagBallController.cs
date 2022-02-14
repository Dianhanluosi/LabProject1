using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagBallController : MonoBehaviour
{

    public bool positive = true;
    public GameObject plus;
    public attractor att;

    public int numOfChange;

    public Text num;

    public string numString;
    

    //arduino stuff
    private string latestMessage;
    bool buttonPressed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (positive)
        {
            plus.gameObject.SetActive(true);
        }
        else
        {
            plus.gameObject.SetActive(false);
        }
        if (numOfChange > 0 &&  Input.GetKeyDown(KeyCode.Space))
        {
            numOfChange -= 1;
            positive = !positive;
            att.Plus = !att.Plus;
        }

        
        //arduino
        if (latestMessage == "1")
        {
            buttonPressed = false;
        }
        if (latestMessage == "0" && buttonPressed == false)
        {
            positive = !positive;
            buttonPressed = true;
        }
        




        numString = numOfChange.ToString();

        num.text = numString;


    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
        latestMessage = msg.Trim(); //remove new line character at end of string

    }

    }
}
