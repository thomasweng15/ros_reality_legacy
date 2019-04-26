using System;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {
    //websocket client connected to ROS network
    private WebsocketClient wsc;
   
    //the end effector that holds the array of ghost transforms
    private GameObject electricFingers;
    private bool playPressed;

    void Start() {
        playPressed = false;
        electricFingers = GameObject.FindWithTag("EndEffector");
        // Get the live websocket client
        wsc = GameObject.Find("WebsocketClient").GetComponent<WebsocketClient>();

        // Create publisher to the Baxter's arm topic (uses Ein)
        wsc.Advertise("ein/" + "right" + "/forth_commands", "std_msgs/String");
        // Asychrononously call sendControls every .1 seconds
        InvokeRepeating("SendControls", .1f, .1f);
    }
    void SendControls() {
        List<String> commands = electricFingers.GetComponent<copyItself>().ghostCommands;

        while(commands.Count > 0 && playPressed){
            String message = commands[0];
            commands.RemoveAt(0);
            //Send the message to the websocket client (i.e: publish message onto ROS network)
            wsc.SendEinMessage(message, "right");
        }

        playPressed = false;
    }
}

