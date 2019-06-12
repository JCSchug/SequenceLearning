using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class CSWriter : MonoBehaviour
{

    private List<string> mSequences = new List<string>();
    private List<string> mPushedbtn = new List<string>();
    private List<float> mMeasuredTime = new List<float>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public CSWriter(List<string> mSequences, List<string> mPushedbtn, List<float> mMeasuredTime)
    {
        this.mSequences = mSequences;
        this.mPushedbtn = mPushedbtn;
        this.mMeasuredTime = mMeasuredTime;



    }

    public void GenerateCSVFile()
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy+HH-mm-ss");
        string filepath = getPath() + date + ".csv";
        Debug.Log(filepath);
        StreamWriter csvWriter = new StreamWriter(filepath);
        csvWriter.WriteLine("Sequence, pushedBTN, succes, measuredTime");
        bool success = false;
        for (int i = 0; i < mSequences.Count; i++)
        {

            if (mPushedbtn[i].Equals(mSequences[i]))
                success = true;
            else
                success = false;
            csvWriter.WriteLine(mSequences[i] + "," + mPushedbtn[i] + "," + success+"," + mMeasuredTime[i].ToString("F2", CultureInfo.InvariantCulture));

        }
        csvWriter.Flush();
        csvWriter.Close();



    }


    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/";
#else
        return Application.persistentDataPath;
#endif




    }





}
