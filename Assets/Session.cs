using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Session : MonoBehaviour
{
   
    public SpriteRenderer B1;
 
    public SpriteRenderer B2;
   
    public SpriteRenderer B3;
   
    public SpriteRenderer B4;
    
    public float Timer = 0;
    public float endtime = 0;

    public List<string> mSequences = new List<string>();
    public List<string> mPushedbtn = new List<string>();
    public List<float> mMeasuredTime = new List<float>();
    private string SEQSTRING="";


    int index = 0;
    public int seqindex = 0;
   // public string ButtonSEQ="";
    public float result = 0;
    public bool  canPress=false;
    private bool end=false;




 



    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(!end) CreateSession();

            if (end)
            {

                canPress = false;
                CSWriter cs = new CSWriter(mSequences, mPushedbtn, mMeasuredTime);
                cs.GenerateCSVFile();

                B1.color = Color.green;
                B2.color = Color.green;
                B3.color = Color.green;
                B4.color = Color.green;


            }


        }



        if (Input.GetKeyDown(KeyCode.A))
        {

            if (canPress)
            {
                B1.color = Color.white;

                endtime = Time.time - Timer;
                mMeasuredTime.Add(endtime);
                mPushedbtn.Add("A");


                index++;
                canPress = false;

              


            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            if (canPress)
            {
                B2.color = Color.white;

                endtime = Time.time - Timer;
                mMeasuredTime.Add(endtime);
                mPushedbtn.Add("B");

                index++;
                canPress = false;


               

            }
        }


        if (Input.GetKeyDown(KeyCode.K))
        {   if (canPress)
            {
                B3.color = Color.white;

                endtime = Time.time - Timer;
                mMeasuredTime.Add(endtime);
                mPushedbtn.Add("C");

                index++;
                canPress=false;

             

            }
        }

        
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (canPress)
            {
                B4.color = Color.white;

                endtime = Time.time - Timer;
                mMeasuredTime.Add(endtime);
                mPushedbtn.Add("D");

                index++;
                canPress = false;

               

            }
        }


    }

    public void CreateSession()
    {

        //StartCoroutine(SEQA(2));
        SEQSTRING = "ACBDCADBDABCBDCA";
        for (int i = 0; i < SEQSTRING.Length; i++)
        {

            mSequences.Add(""+SEQSTRING[i]);


        }

        
        StartSession(SEQSTRING, 2);





    }

    public  void StartSession( string seq , float dur  )
    {

               StartCoroutine( Blink(seq, dur));
    }

    public IEnumerator Blink(string name, float dur)
    {

        if (name[seqindex] == 'A')
        {
            Debug.Log("A");
            B1.color = Color.red;
            Timer = Time.time;
            canPress = true;
            yield return new WaitForSeconds(dur);
            B1.color = Color.white;
            if(seqindex < name.Length - 1) seqindex++;

            }


        if (name[seqindex] == 'B')
        {

            Debug.Log("B");
            B2.color = Color.red;
            Timer = Time.time;
            canPress = true;
            yield return new WaitForSeconds(dur);
            B2.color = Color.white;
            if (seqindex < name.Length - 1) seqindex++;


            }



        if (name[seqindex] == 'C')
        {

            Debug.Log("C");
            B3.color = Color.red;
            Timer = Time.time;
            canPress = true;
            yield return new WaitForSeconds(dur);
            B3.color = Color.white;
            if (seqindex < name.Length - 1) seqindex++;

            }


        if (name[seqindex] == 'D')
        {

              
            Debug.Log("D");
            B4.color = Color.red;
            Timer = Time.time;
            canPress = true;
            yield return new WaitForSeconds(dur);
            B4.color = Color.white;
            if(seqindex<name.Length-1) seqindex++;


            }
            // Rekursiver Aufruf der Klasse
            if (!end)
            {
                if (seqindex <= name.Length - 1)
                {

                    StartCoroutine(Blink(name, 2));
                

                }


                //ENDE
            if (seqindex == name.Length - 1)
            {
               
                end = true;
               

            }


        }






















    }


    

       
    
  
}
