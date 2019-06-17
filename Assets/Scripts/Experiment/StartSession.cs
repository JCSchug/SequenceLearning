using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class StartSession : MonoBehaviour
{
    public SpriteRenderer B1; // 1
    public SpriteRenderer B2; // 2
    public SpriteRenderer B3; // 3
    public SpriteRenderer B4; // 4

    [SerializeField]
    private GameObject Finish_panel;

    //Sequenz 0 1 1 1 0 1 0 1 , 0 = random , 1 = systematic 
    //Systematic Sequence  1   4   3   1   3   2
    //All Sequences should have the same lenght!

    // Random       =  20X      X   X   X   X   X   X 
    // Systematic   =  20X      1   4   3   1   3   2
    // Systematic   =  20X      1   4   3   1   3   2
    // Systematic   =  20X      1   4   3   1   3   2
    // Random       =  20X      X   X   X   X   X   X
    // Systematic   =  20X      1   4   3   1   3   2
    // Random       =  20X      X   X   X   X   X   X
    // Systematic   =  20X      1   4   3   1   3   2

    //Data to store
    public int[] Sequences=new int[960];
    public int[] mPushedbtn = new int[960];
    public float[] mMeasuredTime = new float[960];
    public int[] mTrueBTN = new int[960];

    //
    public int repcounter = 0;
    public int seqindex   = 0;
    public int blockindex = 0;


    //
    public List<int> pattern = new List<int>();
    //Timers
    public float Timer = 0;
    public float endtime = 0;
    public bool end = false;
    public int btrcounter = 0;
    private bool canPress = true;


    // counter for sequence
    private int seqcounter=0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("init", 1f);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)&&canPress)
        {
            mMeasuredTime[btrcounter] = Time.time - Timer;
            mPushedbtn[btrcounter] = 1;
            canPress = false;

        }

        if (Input.GetKeyDown(KeyCode.S) && canPress)
        {
            mMeasuredTime[btrcounter] = Time.time - Timer;
            mPushedbtn[btrcounter] = 2;
            canPress = false;
        }

        if (Input.GetKeyDown(KeyCode.K) && canPress)
        {
            mMeasuredTime[btrcounter] = Time.time - Timer;
            mPushedbtn[btrcounter] = 3;
            canPress = false;
        }


        if (Input.GetKeyDown(KeyCode.L) && canPress)
        {
            mMeasuredTime[btrcounter] = Time.time - Timer;
            mPushedbtn[btrcounter] = 4;
            canPress = false;
        }


    }


    private void init()
    {
        for (int i = 0; i < 20; i++)//0
        {
//#1
            if (seqcounter == 0)
            {
                RandomSequence rs = new RandomSequence();
                for (int j = 0; j < 6; j++){
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }
            else if(seqcounter == 119)
            {
                RandomSequence rs = new RandomSequence(pattern[seqcounter - 1], 1);
                for (int j = 0; j < 6; j++){
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }
            else
            {
                RandomSequence rs = new RandomSequence(pattern[seqcounter-1]);
                for (int j = 0; j < 6; j++){
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }

        }


        for (int i = 0; i < 20; i++)//1
        {
            //#2 240
            SystematicSequence ss = new SystematicSequence();
            for (int j = 0; j < 6; j++)
            {
                pattern.Add(ss.Btnindex[j]);
                Sequences[seqcounter] = 1;
                seqcounter++;
            }
        }

        for (int i = 0; i < 20; i++)//1
        {
            //#3 360
            SystematicSequence ss = new SystematicSequence();
            for (int j = 0; j < 6; j++)
            {
                pattern.Add(ss.Btnindex[j]);
                Sequences[seqcounter] = 1;
                seqcounter++;
            }
        }

        for (int i = 0; i < 20; i++)//1
        {
            //#4 480
            SystematicSequence ss = new SystematicSequence();
            for (int j = 0; j < 6; j++)
            {
                pattern.Add(ss.Btnindex[j]);
                Sequences[seqcounter] = 1;
                seqcounter++;
            }
        }

        for (int i = 0; i < 20; i++)//0
        {
            
            if (seqcounter == 479)
            {//#5
                RandomSequence rs = new RandomSequence(pattern[seqcounter]);
                for (int j = 0; j < 6; j++){
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }
            else if (seqcounter == 599)
            {
                RandomSequence rs = new RandomSequence(pattern[seqcounter - 1], 1);
                for (int j = 0; j < 6; j++){
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }
            else
            {
                RandomSequence rs = new RandomSequence(pattern[seqcounter - 1]);
                for (int j = 0; j < 6; j++){
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }
            
            
        }

        for (int i = 0; i < 20; i++)
        {
            //#6
            SystematicSequence ss = new SystematicSequence();
            for (int j = 0; j < 6; j++)
            {
                pattern.Add(ss.Btnindex[j]);
                Sequences[seqcounter] = 1;
                seqcounter++;
            }
        }


        for (int i = 0; i < 20; i++)
        {
            if (seqcounter == 719)
            {//#7
                RandomSequence rs = new RandomSequence(pattern[seqcounter]);
                for (int j = 0; j < 6; j++)
                {
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }
            else if (seqcounter == 839)
            {
                RandomSequence rs = new RandomSequence(pattern[seqcounter - 1], 1);
                for (int j = 0; j < 6; j++)
                {
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }
            else
            {
                RandomSequence rs = new RandomSequence(pattern[seqcounter - 1]);
                for (int j = 0; j < 6; j++)
                {
                pattern.Add(rs.Btnindex[j]);
                Sequences[seqcounter] = 0;
                seqcounter++;
                }
            }
           
        }





        for (int i = 0; i < 20; i++)
        {
            //#8
            SystematicSequence ss = new SystematicSequence();
            for (int j = 0; j < 6; j++)
            {
                pattern.Add(ss.Btnindex[j]);
                if (seqcounter < 960)
                {
                    Sequences[seqcounter] = 1;
                    seqcounter++;
                }
            }
        }
















        /* for (int i = 0; i < pattern.Count; i++)
        {
          Debug.Log(pattern[i]);

        } */



       StartCoroutine(Blink(pattern[0], 2f));




    }

    public IEnumerator Blink(int btnnr, float dur)
    {
        //yield return new WaitForSeconds(0.25f);

        //random 
        /*if (blockindex == 0 || blockindex == 4 || blockindex == 6)
            {
                Sequences[btrcounter] = 0;
            } */

            //static 


            //random 
            /*
            if (blockindex == 1 || blockindex == 2 || blockindex == 3 || blockindex == 5 || blockindex == 7)
            {
                Sequences[btrcounter] = 1;
            }
            */




        if (repcounter == 6)
        {
            seqindex++;
            repcounter = 0;


        }

        if (seqindex == 20)
        {
            blockindex++;
            seqindex = 0;

        }




        



        if (blockindex == 7 && seqindex == 19 && repcounter == 5)
        {
            yield return new WaitForSeconds(0.25f);
            CSVWriter cs = new CSVWriter(mTrueBTN, Sequences, mPushedbtn, mMeasuredTime);
            cs.GenerateCSVFile(0);
            Finish_panel.SetActive(true);



        }

















            if (btnnr == 1)
            {
            Debug.Log("BTN1");
                mTrueBTN[btrcounter] = 1;

                B1.color = Color.red;
                Timer = Time.time;


                //
                canPress = true;
                
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L));
              

                B1.color = Color.white;
                yield return new WaitForSeconds(0.25f);


                btrcounter++;
                repcounter++;
            
                //Debug.Log(pattern[btrcounter]);
                if(btrcounter<960)
                StartCoroutine(Blink(pattern[btrcounter], 2f));

            }


            if (btnnr == 2)
            {
            Debug.Log("BTN2");
            mTrueBTN[btrcounter] = 2;

                B2.color = Color.red;
                Timer = Time.time;

                canPress = true;
             
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L));
                canPress = false;


                B2.color = Color.white;
                yield return new WaitForSeconds(0.25f);

            btrcounter++;

                repcounter++;
            if (btrcounter < 960)
                StartCoroutine(Blink(pattern[btrcounter], 2f));

            }



            if (btnnr == 3)
            {
            Debug.Log("BTN3");
            mTrueBTN[btrcounter] = 3;

                B3.color = Color.red;
                Timer = Time.time;


                //Buttons
                canPress = true;
              
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L));
                canPress = false;

                //
                B3.color = Color.white;
                yield return new WaitForSeconds(0.25f);

               
                btrcounter++;

                //250 ms Delay between every Reaction
                repcounter++;
            if (btrcounter < 960)
                StartCoroutine(Blink(pattern[btrcounter], 2f));

            }


            if (btnnr == 4)
            {
            Debug.Log("BTN4");
            mTrueBTN[btrcounter] = 4;

                B4.color = Color.red;
                Timer = Time.time;

                //Buttonpress
                canPress = true;
            
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L));
                canPress = false;

                B4.color = Color.white;
                yield return new WaitForSeconds(0.25f);


            btrcounter++;

                //250 ms Delay between every Reaction
                repcounter++;
            if (btrcounter < 960)
                StartCoroutine(Blink(pattern[btrcounter], 2f));
            }


            }










        }

    

        
