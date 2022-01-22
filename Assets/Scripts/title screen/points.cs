using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class points : MonoBehaviour {

    string path;
    StreamReader stream;
    StreamWriter sr;
    int point = 0;
    int rate = 0;
    int dmg = 0;
    int dprice = 0;
    int rprice = 0;
    public GameObject total;
    public GameObject rp;
    public GameObject dp;
    public GameObject rt;
    public GameObject dt;


    public void readTextFile()
    {
        try
        {
            stream = new StreamReader(path);
         }
        catch (FileNotFoundException)
        {
            sr = System.IO.File.CreateText(path);
            sr.WriteLine("0");
            sr.WriteLine("2");
            sr.WriteLine("2");
            sr.Close();
            stream = new StreamReader(path);
        }
        point = int.Parse(stream.ReadLine());
        rate = int.Parse(stream.ReadLine());
        dmg = int.Parse(stream.ReadLine());
        stream.Close();


    }
    public void upgrade(string type)
    {

        readTextFile();

        if (type == "rate")
        {
            if (point < rprice)
            {
                return;
            }
            else
            {
                point -= rprice;
                rate += 1;
            }

        }

        if (type == "damage")
        {
            if (point < dprice)
            {
                return;
            }
            else
            {
                point -= dprice;
                dmg += 1;
            }

        }

        WriteToFile(point, rate, dmg);
    }

    private void Start()
    {
        path = Application.persistentDataPath + "/points.txt";
        readTextFile();

        dprice = (((int)(dmg / 10)) * 10) * 10;
        if (dprice == 0)
        {
            dprice = 10;
        }

        rprice = (((int)(rate / 10)) * 10) * 10;
        if (rprice == 0)
        {
            rprice = 10;
        }

        total.GetComponent<Text>().text = point.ToString();

        rt.GetComponent<Text>().text = rate.ToString();
        dt.GetComponent<Text>().text = dmg.ToString();

        rp.GetComponent<Text>().text = rprice.ToString();
        dp.GetComponent<Text>().text = dprice.ToString();
    }


    public void WriteToFile(int points, int rate, int dmgLevel)
    {
        
        sr = System.IO.File.CreateText(path);
        //print(cachePoints + points);
        sr.WriteLine(points);
        sr.WriteLine(rate);
        sr.WriteLine(dmgLevel);

        sr.Close();
        Start();
    }
}
