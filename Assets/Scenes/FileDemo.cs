//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace DataLogger
{
    public class FileDemo
    {
        /* Fields */
        public enum LogType {OnStart, OnDestroy, SpaceBar, OnClick}
        protected string m_outFileName;
        StreamWriter m_outFile = null;
        const string DEFAULT_FILE = "text.txt";
        /* Constructor */
        public FileDemo(string outFileName = "")
        {
            m_outFileName = outFileName;

            if (outFileName == "")
            {
                m_outFileName = DEFAULT_FILE;
            }

            if(File.Exists(m_outFileName) == false)
            {
                File.Create(m_outFileName).Close();
            }

            m_outFile = new StreamWriter(m_outFileName);

        }
        /* Mutators */
        public void AddToStrToFile(string message)
        {
            m_outFile.WriteLine(message);
            
        }
        /* Accessors */
        public string GetCurrentTime(LogType logType)
        {
            string TimeStampMsg = "";
            switch (logType)
            {
                case LogType.OnStart:
                    TimeStampMsg += "OnStart ~ ";
                    break;
                case LogType.OnDestroy:
                    TimeStampMsg += "OnDestroy ~ ";
                    break;
                case LogType.SpaceBar:
                    TimeStampMsg += "SpaceBar ~ ";
                    break;
                case LogType.OnClick:
                    TimeStampMsg += "OnClick ~ ";
                    break;
                default:
                    return "ERROR: Invalid Argument Input";
            }
            TimeStampMsg += "Time Stamp Message: " + DateTime.Now.ToString() + Environment.NewLine;
            return TimeStampMsg;
        }
        /* Utility Functions */
        public void LogCurrentTime(LogType logType)
        {
            Debug.Log(GetCurrentTime(logType));
            AddToStrToFile(GetCurrentTime(logType));
        }
        public void HandleClick()
        {
            Debug.Log(GetCurrentTime(LogType.OnClick));
            AddToStrToFile(GetCurrentTime(LogType.OnClick));
        }
        public void SaveAndCloseFile()
        {
            m_outFile.Close();
        }
    }
}