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


    private string[] Sequences;
    private string[] mPushedbtn;
    private float[] mMeasuredTime;
    private string[] mTrueBTN;
    int index = 0;
    public int seqindex = 0;
    private int ITERARTION_INDEX = 1;
    private string ButtonSEQ = "";
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
                mPushedbtn[index] = "A";

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
                mPushedbtn[index] = "B";

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
                mPushedbtn[index] = "C";

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
                mPushedbtn[index] = "D";

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
                    mPushedbtn[index] = Input.inputString.ToUpper();

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
        Sequence A = new Sequence(new string[] { "A", "C", "B", "D" }, "A");//1324
        Sequence B = new Sequence(new string[] { "C", "A", "D", "B" }, "B");//3142
        Sequence C = new Sequence(new string[] { "D", "A", "B", "C" }, "C");//4123
        Sequence D = new Sequence(new string[] { "B", "D", "C", "A" }, "D");//2431
        Sequence R = new Sequence(new string[4], "R");//Random
        //List<Sequence> mSequences = new List<Sequence> { A, B, C, D, E, R, B, C, A, E, D, R, B, A, D, C, E, R, D, B, A, E, C, R, E, D, B, C, A, R };/*ACBDCADBDABCBDCA*///Initializing: 1200 Units of Information
        List<Sequence> mSequences = new List<Sequence> { A, B, R, C, D, R };
        //After initializing, creating Randoms in for loop.
        for (int i = 0; i < mSequences.Count; i++)
        {
            if (mSequences[i].MSequenceName.Equals("R") && i < mSequences.Count - 1)//It is a random Object in the middle of the list?
            {
                mSequences[i].MOrderedBTNs = generateRandomObject(mSequences[i - 1].MOrderedBTNs[3], mSequences[i + 1].MOrderedBTNs[0]);
            }
            else if (mSequences[i].MSequenceName.Equals("R") && i == mSequences.Count - 1)//The random object is the last part of the list, so start from the beginning
            {
                mSequences[i].MOrderedBTNs = generateRandomObject(mSequences[i - 1].MOrderedBTNs[3], mSequences[0].MOrderedBTNs[0]);

            }
        }
        session = new Sess(mSequences, 20);
        Sequences = new string[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MIterations];//e.g.: Session has eight Sequences, multiply with four (because of the four buttons) and then the sum of Iterations.
        mPushedbtn = new string[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MIterations];
        mTrueBTN = new string[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MIterations];
        mMeasuredTime = new float[session.MSequences.Count * session.MSequences[0].MOrderedBTNs.Length * session.MIterations];
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
                case "A":
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
                        mPushedbtn[index] = "N";
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
                case "B":
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
                        mPushedbtn[index] = "N";
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
                case "C":
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
                        mPushedbtn[index] = "N";
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
                case "D":
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
                        mPushedbtn[index] = "N";
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
            if (ITERARTION_INDEX <= session.MIterations && seqindex < session.MSequences.Count)
            {
                StartCoroutine(Blink(session, dur));
            }
            else if (seqindex == session.MSequences.Count && ITERARTION_INDEX + 1 <= session.MIterations)
            {
                Debug.Log("Next Iteration");
                ITERARTION_INDEX++;
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
            else if (ITERARTION_INDEX + 1 > session.MIterations && seqindex == session.MSequences.Count)//END
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
    private string[] generateRandomObject(string beginning, string ending, int startIndex = 0, List<string> remove = null, List<string> result = null)
    {
        List<string> sample = new List<string>() { "A", "B", "C", "D" };
        List<string> removeable = new List<string>();
        List<string> results = new List<string>();
        string[] TotalResult = new string[4];
        int rnd = 0;
        switch (startIndex)
        {
            case 0:
                sample.Remove(beginning);
                sample.Add(ending);
                rnd = Random.Range(0, sample.Count);
                removeable.Add(sample[rnd]);
                results.Add(sample[rnd]);
                return generateRandomObject(beginning, ending, 1, removeable, results);

            case 1:
                removeable = new List<string>(remove);
                sample.Remove(removeable[0]);//Remove the first randomly choosen Character, from the random List!
                results = new List<string>(result);
                rnd = Random.Range(0, sample.Count);
                removeable.Add(sample[rnd]);
                results.Add(sample[rnd]);
                return generateRandomObject(beginning, ending, 2, removeable, results);
            case 2:
                removeable = new List<string>(remove);
                sample.Remove(removeable[0]);
                sample.Remove(removeable[1]);
                results = new List<string>(result);
                if (sample.Contains(ending))
                {
                    results.Add(ending);
                    removeable.Add(ending);
                    sample.Remove(ending);
                    results.Add(sample[0]);
                    TotalResult[0] = results[0];
                    TotalResult[1] = results[1];
                    TotalResult[2] = results[2];
                    TotalResult[3] = results[3];
                    return TotalResult;
                }
                else
                {
                    rnd = Random.Range(0, sample.Count);
                    results.Add(sample[rnd]);
                    List<string> copy = new List<string>(results);
                    sample.Remove(sample[rnd]);
                    copy.Add(sample[0]);
                    TotalResult[0] = copy[0];
                    TotalResult[1] = copy[1];
                    TotalResult[2] = copy[2];
                    TotalResult[3] = copy[3];
                    return TotalResult;
                }

            default:
                return TotalResult;

        }
    }
}
