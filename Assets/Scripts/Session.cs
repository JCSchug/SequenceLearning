using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Session : MonoBehaviour
{

    public SpriteRenderer B1;
    public SpriteRenderer B2;
    public SpriteRenderer B3;
    public SpriteRenderer B4;
    public float Timer = 0;
    public float endtime = 0;

    [SerializeField]
    private GameObject Finish_panel;


    private int[] Sequences;
    private int[] mPushedbtn;
    private float[] mMeasuredTime;
    private int[] mTrueBTN;
    int index = 0;
    public int seqindex = 0;
    private int REPITION_INDEX = 1;
    private int LAST_BUTTON;
    public float result = 0;
    public bool canPress = false;
    private bool end = false;
    private Sess session;
    private int BTN_INDEX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Init", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            CSVWriter cSVWriter = new CSVWriter(mTrueBTN, Sequences, mPushedbtn, mMeasuredTime);
            cSVWriter.GenerateCSVFile(0);
            Finish_panel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canPress)
            {
                Debug.Log("A");
                endtime = Time.time - Timer;
                Sequences[index] = session.MSequences[seqindex].MSequenceName;
                mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                mMeasuredTime[index] = endtime;
                mPushedbtn[index] = 1;
                switch (session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX])
                {
                    case 1:
                        B1.color = Color.white;
                        break;
                    case 2:
                        B2.color = Color.white;
                        break;
                    case 3:
                        B3.color = Color.white;
                        break;
                    case 4:
                        B4.color = Color.white;
                        break;
                }
                index++;
                canPress = false;
                if (BTN_INDEX + 1 < session.MSequences[seqindex].MOrderedBTNs.Length)
                {
                    BTN_INDEX++;
                    SetNextButton();
                }
                else
                {
                    LAST_BUTTON = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                    BTN_INDEX = 0;
                    SetNextButton();
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (canPress)
            {
                Debug.Log("S");
                endtime = Time.time - Timer;
                Sequences[index] = session.MSequences[seqindex].MSequenceName;
                mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                mMeasuredTime[index] = endtime;
                mPushedbtn[index] = 2;
                switch (session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX])
                {
                    case 1:
                        B1.color = Color.white;
                        break;
                    case 2:
                        B2.color = Color.white;
                        break;
                    case 3:
                        B3.color = Color.white;
                        break;
                    case 4:
                        B4.color = Color.white;
                        break;
                }
                index++;
                canPress = false;
                if (BTN_INDEX + 1 < session.MSequences[seqindex].MOrderedBTNs.Length)
                {
                    BTN_INDEX++;
                    SetNextButton();
                }
                else
                {
                    LAST_BUTTON = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                    BTN_INDEX = 0;
                    SetNextButton();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canPress)
            {
                Debug.Log("K");
                endtime = Time.time - Timer;
                Sequences[index] = session.MSequences[seqindex].MSequenceName;
                mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                mMeasuredTime[index] = endtime;
                mPushedbtn[index] = 3;
                switch (session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX])
                {
                    case 1:
                        B1.color = Color.white;
                        break;
                    case 2:
                        B2.color = Color.white;
                        break;
                    case 3:
                        B3.color = Color.white;
                        break;
                    case 4:
                        B4.color = Color.white;
                        break;
                }
                index++;
                canPress = false;
                if (BTN_INDEX + 1 < session.MSequences[seqindex].MOrderedBTNs.Length)
                {
                    BTN_INDEX++;
                    SetNextButton();
                }
                else
                {
                    LAST_BUTTON = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                    BTN_INDEX = 0;
                    SetNextButton();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (canPress)
            {
                Debug.Log("L");
                endtime = Time.time - Timer;
                Sequences[index] = session.MSequences[seqindex].MSequenceName;
                mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                mMeasuredTime[index] = endtime;
                mPushedbtn[index] = 4;

                switch (session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX])
                {
                    case 1:
                        B1.color = Color.white;
                        break;
                    case 2:
                        B2.color = Color.white;
                        break;
                    case 3:
                        B3.color = Color.white;
                        break;
                    case 4:
                        B4.color = Color.white;
                        break;
                }
                index++;
                canPress = false;
                if (BTN_INDEX + 1 < session.MSequences[seqindex].MOrderedBTNs.Length)
                {
                    BTN_INDEX++;
                    SetNextButton();
                }
                else
                {
                    LAST_BUTTON = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                    BTN_INDEX = 0;
                    SetNextButton();
                }
            }
        }
        if (Input.anyKey)
        {
            if (!end)
            {
                if (canPress)
                {
                    Debug.Log("Any: " + Input.inputString);
                    endtime = Time.time - Timer;
                    Sequences[index] = session.MSequences[seqindex].MSequenceName;
                    mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                    mMeasuredTime[index] = endtime;
                    mPushedbtn[index] = 4;
                    switch (session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX])
                    {
                        case 1:
                            B1.color = Color.white;
                            break;
                        case 2:
                            B2.color = Color.white;
                            break;
                        case 3:
                            B3.color = Color.white;
                            break;
                        case 4:
                            B4.color = Color.white;
                            break;
                    }
                    index++;
                    canPress = false;
                    if (BTN_INDEX + 1 < session.MSequences[seqindex].MOrderedBTNs.Length)
                    {
                        BTN_INDEX++;
                        SetNextButton();
                    }
                    else
                    {
                        LAST_BUTTON = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                        BTN_INDEX = 0;
                        SetNextButton();
                    }
                }

            }
        }

    }
    private void SetNextButton()
    {

        if (REPITION_INDEX + 1 == session.MRepitions)
        {
            REPITION_INDEX = 0;
            if (session.MSequences[seqindex].MSequenceName == 0 && session.MSequences[seqindex + 1].MSequenceName == 0 || session.MSequences[seqindex].MSequenceName == 1 && session.MSequences[seqindex + 1].MSequenceName == 0)
            {
                session.MSequences[seqindex + 1].MOrderedBTNs = generateRandomObject(0, LAST_BUTTON);
            }

            seqindex++;
        }
        else if (REPITION_INDEX + 1 < session.MRepitions && BTN_INDEX == session.MSequences[seqindex].MOrderedBTNs.Length)
        {

            REPITION_INDEX++;
            if (session.MSequences[seqindex].MSequenceName == 0)
                session.MSequences[seqindex].MOrderedBTNs = generateRandomObject(0, LAST_BUTTON);
            else if (REPITION_INDEX + 1 == session.MRepitions && session.MSequences[seqindex].MSequenceName == 0 && session.MSequences[seqindex + 1].MSequenceName == 1)//Letzte Random Initialisierung vor Systematic
            {
                session.MSequences[seqindex].MOrderedBTNs = generateRandomObject(0, LAST_BUTTON, new int[6], session.MSequences[seqindex].MOrderedBTNs[0]);
            }
        }


        switch (session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX])
        {
            case 1:
                Debug.Log("Button" + 1);
                StartCoroutine(PauseTilNext());
                B1.color = Color.red;
                canPress = true;
                Timer = Time.time;
                break;
            case 2:
                Debug.Log("Button" + 2);
                StartCoroutine(PauseTilNext());
                B2.color = Color.red;
                canPress = true;
                Timer = Time.time;
                break;
            case 3:
                Debug.Log("Button" + 3);
                StartCoroutine(PauseTilNext());
                B3.color = Color.red;
                canPress = true;
                Timer = Time.time;
                break;
            case 4:
                Debug.Log("Button" + 4);
                StartCoroutine(PauseTilNext());
                B4.color = Color.red;
                canPress = true;
                Timer = Time.time;
                break;
        }
    }
    private IEnumerator PauseTilNext()
    {
        yield return new WaitForSeconds(1f);
    }
    public void onClicMenu()
    {
        Subject_Counting.setSNR();
        SceneManager.LoadScene(0);
    }
    private void Init()
    {
        Sequence A = new Sequence(new int[] { 1, 4, 3, 1, 3, 2 }, 1);//1324
        Sequence R = new Sequence(new int[6], 0);//Random
        List<Sequence> mSequences = new List<Sequence> { R, A, A, A, R, A, R, A };
        session = new Sess(mSequences, 5);
        //Check if first sequence is Random
        if (session.MSequences[0].MSequenceName == 0)
        {
            session.MSequences[0].MOrderedBTNs = generateRandomObject(0);
        }
        Sequences = new int[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MRepitions];//e.g.: Session has eight Sequences, multiply with four (because of the four buttons) and then the sum of Iterations.
        mPushedbtn = new int[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MRepitions];
        mTrueBTN = new int[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MRepitions];
        mMeasuredTime = new float[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MRepitions];
        Debug.Log("Starting Init");
        SetNextButton();
    }
    private int[] generateRandomObject(int index, int lastnumber = 0, int[] totalResult = null, int beginning = 0)
    {
        int[] random = new int[] { 1, 2, 3, 4 };
        int rnd = Random.Range(1, random.Length);
        if (totalResult == null)
            totalResult = new int[6];
        if (random[rnd] == lastnumber)
            return generateRandomObject(index, lastnumber, totalResult, beginning);
        else if (index == random.Length - 1 && random[rnd] == beginning)
            return generateRandomObject(index, lastnumber, totalResult, beginning);
        else
        {
            totalResult[index] = random[rnd];
            if (index + 1 == totalResult.Length)
            {
                Debug.Log(totalResult[0] + ", " + totalResult[1] + ", " + totalResult[2] + ", " + totalResult[3] + ", " + totalResult[4] + ", " + totalResult[5]);
                return totalResult;
            }
            else
            {
                index++;
                lastnumber = random[rnd];
                return generateRandomObject(index, lastnumber, totalResult, beginning);
            }

        }

    }
}
