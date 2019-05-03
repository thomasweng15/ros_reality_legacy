﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class DepthRosGeometryView : MonoBehaviour {

    private WebsocketClient wsc;
    string depthTopic;
    string colorTopic;
    int framerate = 100;
    public string compression = "none"; 
    string depthMessage;
    string colorMessage;

    public Material Material;
    Texture2D depthTexture;
    Texture2D colorTexture;

    int width = 640;
    int height = 480;

    Matrix4x4 m;

    // Use this for initialization
    void Start() {
        // Create a texture for the depth image and color image
        depthTexture = new Texture2D(width, height, TextureFormat.R16, false);
        colorTexture = new Texture2D(width, height, TextureFormat.RGB24, false);

        wsc = GameObject.Find("WebsocketClient").GetComponent<WebsocketClient>();
        depthTopic = "camera/depth_registered/image";
        colorTopic = "camera/rgb/image_raw";
        wsc.Subscribe(depthTopic, "sensor_msgs/Image", compression, framerate);
        wsc.Subscribe(colorTopic, "sensor_msgs/Image", compression, framerate);
        InvokeRepeating("UpdateTexture", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void UpdateTexture() {
        try {
            depthMessage = wsc.messages[depthTopic];
            byte[] depthImage = System.Convert.FromBase64String(depthMessage);

            depthTexture.LoadRawTextureData(depthImage);
            depthTexture.Apply();
        }
        catch (Exception e) {
            Debug.Log(e.ToString());
        }   

        try {
            colorMessage = wsc.messages[colorTopic];
            byte[] colorImage = System.Convert.FromBase64String(colorMessage);
            colorTexture.LoadRawTextureData(colorImage);
            colorTexture.Apply();
        }
        catch (Exception e) {
            Debug.Log(e.ToString());
            return;
        }
    }

    void OnRenderObject() {

        Material.SetTexture("_MainTex", depthTexture);
        Material.SetTexture("_ColorTex", colorTexture);
        Material.SetPass(0);

        m = Matrix4x4.TRS(this.transform.position, this.transform.rotation, this.transform.localScale);
        Material.SetMatrix("transformationMatrix", m);

        Graphics.DrawProcedural(MeshTopology.Points, width * height, 1);
    }
}