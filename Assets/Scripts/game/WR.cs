using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class WR : MonoBehaviour
{

    public int cachePoints;
    private string PointsString;
    public int point;
    public int rate;
    public int dmg;

    private void Start()
    {
        try
        {
            readTextFile();
        }
        catch (FileNotFoundException)
        {
            WriteToFile(0, 1, 1);
        }
    }

    private void FixedUpdate()
    {

        if (cachePoints >= 1000000)
        {
            PointsString = (cachePoints /1000 / 1000f).ToString() + "M";
            gameObject.GetComponent<Text>().text = PointsString;
        }
        else if (cachePoints >= 1000)
        {
            PointsString = (cachePoints / 1000f).ToString() + "K";
            gameObject.GetComponent<Text>().text = PointsString;
        }
        else
        {
            PointsString = (cachePoints).ToString();
            gameObject.GetComponent<Text>().text = PointsString;
        }
    }

    public void chache(int addPoints)
    {

        cachePoints += addPoints;

    }

    public void readTextFile()
    {
        string path = Application.persistentDataPath + "/points.txt";
        StreamReader stream = new StreamReader(path);
        point = int.Parse(stream.ReadLine());
        rate = int.Parse(stream.ReadLine());
        dmg = int.Parse(stream.ReadLine());
        stream.Close();

        WriteToFile(point, rate, dmg);
    }

    public void WriteToFile(int points, int rate, int dmgLevel)
    {

        string path = Application.persistentDataPath + "/points.txt";
        StreamWriter sr = System.IO.File.CreateText(path);
        //print(cachePoints + points);
        sr.WriteLine(points+cachePoints);
        sr.WriteLine(rate);
        sr.WriteLine(dmgLevel);


        sr.Close();
    }
}