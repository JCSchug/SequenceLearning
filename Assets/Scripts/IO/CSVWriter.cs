using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class CSVWriter
{
    //Serializing Data in Main Application
    private int[] mSequences;
    private int[] mPushedbtn;
    private float[] mMeasuredTime;
    private int[] mTrueBTN;
    //Serializing Data in First Questionaire
    private string mSex;
    private int mAge;
    private bool mPlayingGames;
    private string mHowManyHours;
    private bool mPlayingInstrument;
    private string mInstrument;
    //Serializing Data in Last Questionaire
    private bool mSomethingHappend;
    private bool mRandomOrNot;
    private bool mTryToDraw;
    private int[] ChoosenSequences; 

    public CSVWriter(int[] mTrueBTN, int[] mSequences, int[] mPushedbtn, float[] mMeasuredTime)//Constructor for Serializing Data From Main Application
    {
        this.mSequences = mSequences;
        this.mPushedbtn = mPushedbtn;
        this.mMeasuredTime = mMeasuredTime;
        this.mTrueBTN = mTrueBTN;
    }

    public CSVWriter(string mSex, int mAge, bool mPlayingGames, string mHowManyHours, bool mPlayingInstrument, string mInstrument)//Constructor for Serializing Data From Main Application
    {
        this.mSex = mSex;
        this.mAge = mAge;
        this.mPlayingGames = mPlayingGames;
        this.mHowManyHours = mHowManyHours;
        this.mPlayingInstrument = mPlayingInstrument;
        this.mInstrument = mInstrument;
    }

    public CSVWriter(bool mSomethingHappend, bool mRandomOrNot, bool mTryToDraw, int[] choosenSequences)
    {
        this.mSomethingHappend = mSomethingHappend;
        this.mRandomOrNot = mRandomOrNot;
        this.mTryToDraw = mTryToDraw;
        ChoosenSequences = choosenSequences;
    }

    public void GenerateCSVFile(int index)
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy+HH-mm-ss");
        string filepath = getPath(index) + "Probant" + Subject_Counting.getSNR() + "+" + date + ".csv";
        StreamWriter csvWriter = new StreamWriter(filepath);
        switch (index)
        {
            case 0://Serializing Data From Main Application
                Debug.Log(filepath);
                csvWriter.WriteLine("Sequence,trueBtn,pushedBTN,succes,measuredTime");
                bool success = false;
                for (int i = 0; i < mPushedbtn.Length; i++)
                {

                    if (mPushedbtn[i].Equals(mTrueBTN[i]))
                        success = true;
                    else
                        success = false;
                    csvWriter.WriteLine(mSequences[i].ToString() + "," + mTrueBTN[i].ToString() + "," + mPushedbtn[i].ToString() + "," + success + "," + mMeasuredTime[i].ToString("F2", CultureInfo.InvariantCulture));
                }
                csvWriter.Flush();
                csvWriter.Close();
                break;
            case 1://Serializing Data From First Questionaire
                if (mSex.ToLower().Equals("männlich"))
                {
                    mSex = "male";
                }else if (mSex.ToLower().Equals("weiblich"))
                {
                    mSex = "female";
                }
                csvWriter.WriteLine("Sex,Age,PlayingGames,PlayingGamesHours,PlayingInstrument,Instrument");
                csvWriter.WriteLine(mSex + "," +mAge+","+ mPlayingGames +"," + mHowManyHours + "," + mPlayingInstrument + "," + mInstrument);
                csvWriter.Flush();
                csvWriter.Close();
                break;
            case 2://Serializing Data From Last Questionaire
                csvWriter.WriteLine("Somethinghappend,Random,TryToDraw");
                csvWriter.WriteLine(mSomethingHappend + "," + mRandomOrNot + "," + mTryToDraw);
                csvWriter.WriteLine("guessedorder");
                for(int i=0; i< ChoosenSequences.Length; i++)
                {
                    if(i == 0)
                    {
                        csvWriter.Write(ChoosenSequences[i] + ",");
                    }else if(i == 1)
                    {
                        csvWriter.Write(ChoosenSequences[i] + ",");
                    }
                    else if (i == 2)
                    {
                        csvWriter.Write(ChoosenSequences[i] + ",");
                    }
                    else if (i == 3)
                    {
                        csvWriter.Write(ChoosenSequences[i] + "\n");
                    }
                    if(i > 3)
                    {
                        
                        if (i%4 == 3)
                        {
                            csvWriter.Write(ChoosenSequences[i] + "\n");
                        }
                        else
                        {
                            csvWriter.Write(ChoosenSequences[i] + ",");
                        }
                    }
                }
                csvWriter.Flush();
                csvWriter.Close();
                break;

        }

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
                return Application.persistentDataPath + "/CSV/Testing/";
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
