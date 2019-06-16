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
    public float result = 0;
    public bool canPress = false;
    private bool pressed = false;
    private bool end = false;
    private Sess session;
    private int BTN_INDEX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Init", 2f);
    }
    IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(1f);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {

            if (canPress)
            {
                B1.color = Color.white;

                endtime = Time.time - Timer;
                Sequences[index] = session.MSequences[seqindex].MSequenceName;
                mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                mMeasuredTime[index] = endtime;
                mPushedbtn[index] = 1;

                index++;
                canPress = false;
                pressed = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            if (canPress)
            {
                B2.color = Color.white;

                endtime = Time.time - Timer;
                Sequences[index] = session.MSequences[seqindex].MSequenceName;
                mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                mMeasuredTime[index] = endtime;
                mPushedbtn[index] = 2;

                index++;
                canPress = false;
                pressed = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canPress)
            {
                B3.color = Color.white;

                endtime = Time.time - Timer;
                Sequences[index] = session.MSequences[seqindex].MSequenceName;
                mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                mMeasuredTime[index] = endtime;
                mPushedbtn[index] = 3;

                index++;
                canPress = false;
                pressed = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (canPress)
            {
                B4.color = Color.white;

                endtime = Time.time - Timer;
                Sequences[index] = session.MSequences[seqindex].MSequenceName;
                mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                mMeasuredTime[index] = endtime;
                mPushedbtn[index] = 4;

                index++;
                canPress = false;
                pressed = true;
            }
        }
        if (Input.anyKey)
        {
            if (!end)
            {
                if (canPress)
                {
                    endtime = Time.time - Timer;
                    Sequences[index] = session.MSequences[seqindex].MSequenceName;
                    mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                    mMeasuredTime[index] = endtime;
                    mPushedbtn[index] = 5;

                    index++;
                    canPress = false;
                    pressed = true;
                }
            }

        }
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
        List<Sequence> mSequences = new List<Sequence> { R, A, A, A, R, A, R,A };        
        session = new Sess(mSequences, 20);
        //Check if first sequence is Random
        if(session.MSequences[0].MSequenceName == 0)
        {
            for(int i=0; i < session.MSequences[0].MOrderedBTNs.Length; i++)
            {

            }
        }
        Sequences = new int[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MRepitions];//e.g.: Session has eight Sequences, multiply with four (because of the four buttons) and then the sum of Iterations.
        mPushedbtn = new int[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MRepitions];
        mTrueBTN = new int[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MRepitions];
        mMeasuredTime = new float[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MRepitions];
        CreateSession();
    }
    public void CreateSession()
    {
        StartSession(session, 1f);
    }

    public void StartSession(Sess session, float dur)
    {
        StartCoroutine(Blink(session, dur));
    }

    public IEnumerator Blink(Sess session, float dur)
    {
        if (session.MSequences[seqindex].MSequenceName.Equals("A") || session.MSequences[seqindex].MSequenceName.Equals("B") || session.MSequences[seqindex].MSequenceName.Equals("C") || session.MSequences[seqindex].MSequenceName.Equals("D") || session.MSequences[seqindex].MSequenceName.Equals("R"))
        {

            switch (session.MSequences[seqindex].getspecificBTNElement(BTN_INDEX))//switch-case method: which button is activated?
            {
                case 1:
                    B1.color = Color.red;
                    Timer = Time.time;
                    canPress = true;
                    pressed = false;
                    yield return new WaitForSeconds(dur);
                    if (!pressed)
                    {
                        endtime = Time.time - Timer;
                        Sequences[index] = session.MSequences[seqindex].MSequenceName;
                        mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                        mMeasuredTime[index] = endtime;
                        mPushedbtn[index] = 5;
                        index++;
                        canPress = false;
                    }
                    B1.color = Color.white;
                    if (BTN_INDEX < 3)
                        BTN_INDEX++;
                    else
                    {
                        BTN_INDEX = 0;
                        seqindex++;
                    }
                    yield return new WaitForSeconds(.25f);
                    break;
                case 2:
                    B2.color = Color.red;
                    Timer = Time.time;
                    canPress = true;
                    pressed = false;
                    yield return new WaitForSeconds(dur);
                    if (!pressed)
                    {
                        endtime = Time.time - Timer;
                        Sequences[index] = session.MSequences[seqindex].MSequenceName;
                        mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                        mMeasuredTime[index] = endtime;
                        mPushedbtn[index] = 5;
                        index++;
                        canPress = false;
                    }
                    B2.color = Color.white;
                    if (BTN_INDEX < 3)
                        BTN_INDEX++;
                    else
                    {
                        BTN_INDEX = 0;
                        seqindex++;
                    }
                    yield return new WaitForSeconds(0.25f);
                    break;
                case 3:
                    B3.color = Color.red;
                    Timer = Time.time;
                    canPress = true;
                    pressed = false;
                    yield return new WaitForSeconds(dur);
                    if (!pressed)
                    {
                        endtime = Time.time - Timer;
                        Sequences[index] = session.MSequences[seqindex].MSequenceName;
                        mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                        mMeasuredTime[index] = endtime;
                        mPushedbtn[index] = 5;
                        index++;
                        canPress = false;
                    }
                    B3.color = Color.white;
                    if (BTN_INDEX < 3)
                        BTN_INDEX++;
                    else
                    {
                        BTN_INDEX = 0;
                        seqindex++;
                    }
                    yield return new WaitForSeconds(0.25f);
                    break;
                case 4:
                    B4.color = Color.red;
                    Timer = Time.time;
                    canPress = true;
                    pressed = false;
                    yield return new WaitForSeconds(dur);
                    if (!pressed)
                    {
                        endtime = Time.time - Timer;
                        Sequences[index] = session.MSequences[seqindex].MSequenceName;
                        mTrueBTN[index] = session.MSequences[seqindex].MOrderedBTNs[BTN_INDEX];
                        mMeasuredTime[index] = endtime;
                        mPushedbtn[index] = 5;
                        index++;
                        canPress = false;
                    }
                    B4.color = Color.white;
                    if (BTN_INDEX < 3)
                        BTN_INDEX++;
                    else
                    {
                        BTN_INDEX = 0;
                        seqindex++;
                    }
                    yield return new WaitForSeconds(0.25f);
                    break;
            }
        }

        // Rekursiver Aufruf der Klasse
        if (!end)
        {
            if (REPITION_INDEX <= session.MRepitions && seqindex < session.MSequences.Count)
            {
                StartCoroutine(Blink(session, dur));
            }
            else if (seqindex == session.MSequences.Count && REPITION_INDEX + 1 <= session.MRepitions)
            {
                Debug.Log("Next Iteration");
                REPITION_INDEX++;
                seqindex = 0;
                BTN_INDEX = 0;
                for (int i = 0; i < session.MSequences.Count; i++)
                {
                    if (session.MSequences[i].MSequenceName.Equals("R") && i < session.MSequences.Count - 1)//It is a random Object in the middle of the list?
                    {
                        session.MSequences[i].MOrderedBTNs = generateRandomObject(session.MSequences[i - 1].MOrderedBTNs[3], session.MSequences[i + 1].MOrderedBTNs[0]);
                    }
                    else if (session.MSequences[i].MSequenceName.Equals("R") && i == session.MSequences.Count - 1)//The random object is the last part of the list, so start from the beginning
                    {
                        session.MSequences[i].MOrderedBTNs = generateRandomObject(session.MSequences[i - 1].MOrderedBTNs[3], session.MSequences[0].MOrderedBTNs[0]);

                    }
                }
                StartCoroutine(Blink(session, dur));
            }
            else if (REPITION_INDEX + 1 > session.MRepitions && seqindex == session.MSequences.Count)//END
            {
                end = true;
                CSVWriter cs = new CSVWriter(mTrueBTN, Sequences, mPushedbtn, mMeasuredTime);
                cs.GenerateCSVFile(0);
                B1.color = Color.green;
                B2.color = Color.green;
                B3.color = Color.green;
                B4.color = Color.green;
                Finish_panel.SetActive(true);
            }
        }
    }
    private int[] generateRandomObject(int beginning = 0, int ending = 0, int startIndex = 0, List<int> remove = null, List<int> result = null)
    {
                
    }
}
