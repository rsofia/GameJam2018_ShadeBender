//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class FileWriter : MonoBehaviour {

    public void WriteFile(int index)
    {

        if (!File.Exists(Application.dataPath + "/Levels.txt"))
        {
            var myFile = File.Create(Application.dataPath + "/Levels.txt"); 
            myFile.Close();
        }


        if(!IsIndexSaved(index))
        {
            TextWriter myTXT = new StreamWriter(Application.dataPath + "/Levels.txt", true);
            myTXT.WriteLine(index);
            myTXT.Close();
        }
        
    }

    public bool IsIndexSaved(int index)
    {
        bool wasPlayed = false;
        string path = Application.dataPath + "/Levels.txt";
        Debug.Log("Path saved: " + path);
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string str in lines)
            {
                if (str == index.ToString())
                    wasPlayed = true;
            }
        }
        return wasPlayed;
    }
}
