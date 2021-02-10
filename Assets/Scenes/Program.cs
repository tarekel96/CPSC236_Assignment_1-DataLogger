using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace DataLogger
{
    public class Program : MonoBehaviour
    {
        FileDemo FileHandler;
        //const string FileName = "text.txt";

        // Start is called before the first frame update
        void Start()
        {
            FileHandler = new FileDemo();

            /* Timestamp of when App first loads */
            FileHandler.LogCurrentTime(FileDemo.LogType.OnStart);
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FileHandler.LogCurrentTime(FileDemo.LogType.SpaceBar);
            }

        }

        // OnDestroy called when program shuts down
        void OnDestroy()
        {
            if(FileHandler != null)
            {
                /* Timestamp of when App is about to quit */
                FileHandler.LogCurrentTime(FileDemo.LogType.OnDestroy);
                FileHandler.SaveAndCloseFile();
                Debug.Log("Check the file: " + Environment.CurrentDirectory + "/text.txt");
            }
        }
        // Utility Functions
        public void InvokeHandleClick()
        {
            FileHandler.HandleClick();
        }
    }
}
