using UnityEngine;
using System.Collections;
using System.IO.Ports;
public class MenuScript : MonoBehaviour
{

    public string MyComPort = "COM2";//This should be accessible from a config file

    public SerialPort serial;
    void Start()
    {

        serial = new SerialPort(MyComPort, 9600);
    }

    // Use this for initialization
    public void TurnOnLight(int LightNum)
    {
        if (serial.IsOpen == false)
            serial.Open();
        if (LightNum == 1) serial.Write("A");
        if (LightNum == 2) serial.Write("B");
        if (LightNum == 3) serial.Write("C");
        if (LightNum == 4) serial.Write("D");
    }

    // Update is called once per frame
    public void TurnOffLight(int LightNum)
    {
        if (serial.IsOpen == false)
            serial.Open();
        if (LightNum == 1) serial.Write("a");
        if (LightNum == 2) serial.Write("b");
        if (LightNum == 3) serial.Write("c");
        if (LightNum == 4) serial.Write("d");
    }
}