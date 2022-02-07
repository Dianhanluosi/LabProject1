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


        numString = numOfChange.ToString();

        num.text = numString;


    }
}
