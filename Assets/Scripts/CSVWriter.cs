using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class CSVWriter 
{

    private string[] mSequences;
    private string[] mPushedbtn;
    private float [] mMeasuredTime;
    private string[] mTrueBTN;

    public CSVWriter(string[] mTrueBTN,string[] mSequences, string[] mPushedbtn, float[] mMeasuredTime)
    {
        this.mSequences = mSequences;
        this.mPushedbtn = mPushedbtn;
        this.mMeasuredTime = mMeasuredTime;
        this.mTrueBTN = mTrueBTN;
    }

    public void GenerateCSVFile(int index)
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy+HH-mm-ss");
        string filepath = getPath(index) + "Probant"+Subject_Counting.getSNR()+"+"+ date + ".csv";
        Debug.Log(filepath);
        StreamWriter csvWriter = new StreamWriter(filepath);
        csvWriter.WriteLine("Sequence,trueBtn,pushedBTN,succes,measuredTime");
        bool success = false;
        for (int i = 0; i < mPushedbtn.Length; i++)
        {

            if (mPushedbtn[i].Equals(mTrueBTN[i]))
                success = true;
            else
                success = false;
            csvWriter.WriteLine(mSequences[i] + "," + mTrueBTN[i]+","+ mPushedbtn[i] + "," + success+"," + mMeasuredTime[i].ToString("F2", CultureInfo.InvariantCulture));

        }
        csvWriter.Flush();
        csvWriter.Close();
    }


    private string getPath(int index)
    {
        if (index == 0)
        {
            if (!Directory.Exists(Application.dataPath + "/CSV/Testing/") || !Directory.Exists(Application.persistentDataPath + "/CSV/Testing/"))
            {

#if UNITY_EDITOR
                Directory.CreateDirectory(Application.dataPath + "/CSV/Testing/");
                return Application.dataPath + "/CSV/Testing/";
#else
                Directory.CreateDirectory(Application.persistentDataPath + "/CSV/Testing/");
                return Application.persistentDataPath + ""/CSV/Testing/";
#endif
            }
            else
            {
#if UNITY_EDITOR
                return Application.dataPath + "/CSV/Testing/";
#else
                return Application.persistentDataPath+"/CSV/Testing/";
#endif

            }
        }
        else if (index == 1)
        {
            if (!Directory.Exists(Application.dataPath + "/CSV/Questionaire_DATA/") || !Directory.Exists(Application.persistentDataPath + "/CSV/Questionaire_DATA/"))
            {
#if UNITY_EDITOR
                Directory.CreateDirectory(Application.dataPath + "/CSV/Questionaire_DATA/");
                return Application.dataPath + "/CSV/Questionaire_DATA/";
#else
                Directory.CreateDirectory(Application.persistentDataPath + "/CSV/Questionaire_DATA/");
                return Application.persistentDataPath + "/CSV/Questionaire_DATA/";
#endif
            }
            else
            {
#if UNITY_EDITOR
                return Application.dataPath + "/CSV/Questionaire_DATA/";
#else
                return Application.persistentDataPath + "/CSV/Questionaire_DATA/";
#endif
            }
        }
        else if (index == 2)
        {
            if (!Directory.Exists(Application.dataPath + "/CSV/Questionaire_FINAL/") || !Directory.Exists(Application.persistentDataPath + "/CSV/Questionaire_FINAL/"))
            {
#if UNITY_EDITOR
                Directory.CreateDirectory(Application.dataPath + "/CSV/Questionaire_FINAL/");
                return Application.dataPath + "/CSV/Questionaire_FINAL/";
#else
                Directory.CreateDirectory(Application.persistentDataPath + "/CSV/Questionaire_FINAL/");
                return Application.persistentDataPath + "/CSV/Questionaire_FINAL/";
#endif
            }
            else
            {
#if UNITY_EDITOR
                return Application.dataPath + "/CSV/Questionaire_FINAL/";
#else
                return Application.persistentDataPath + "/CSV/Questionaire_FINAL/";
#endif

            }
        }
        else
            return "";
    }
}
