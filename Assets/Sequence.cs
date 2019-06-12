using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sequence : MonoBehaviour
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
    public bool canPress=false;
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
                CSWriter cs = new CSWriter(mSequences, mPushedbtn, mMeasuredTime);
                cs.GenerateCSVFile();
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

        
        Session(SEQSTRING, 2);





    }

   public IEnumerator SEQA( float dur)
    {

        Debug.Log("Sequenz A Start ");
        yield return new WaitForSeconds(dur);
        B1.color = Color.red;
        Timer= Time.time;
        yield  return new WaitForSeconds(dur);
        B1.color = Color.white;

        B3.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B3.color = Color.white;

        B2.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B2.color = Color.white;

        B4.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B4.color = Color.white;


        Debug.Log("Sequenz A Ende  ");

        StartCoroutine(SEQB(2));


    }


    public IEnumerator SEQB(float dur)
    {

        Debug.Log("Sequenz B  Start ");
        B3.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B3.color = Color.white;

        B1.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B1.color = Color.white;

        B4.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B4.color = Color.white;

        B2.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B2.color = Color.white;


        Debug.Log("Sequenz B Ende  ");

        StartCoroutine(SEQC(2));

     
    }
    public IEnumerator SEQC(float dur)
    {

        Debug.Log("Sequenz C Start ");
        B4.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B4.color = Color.white;

        B1.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B1.color = Color.white;

        B2.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B2.color = Color.white;

        B3.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B3.color = Color.white;

        Debug.Log("Sequenz C Ende  ");
        StartCoroutine(SEQD(2));

    }

    public IEnumerator SEQD(float dur)
    {
        Debug.Log("Sequenz D Ende  ");
        B2.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B2.color = Color.white;

        B4.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B4.color = Color.white;

        B3.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B3.color = Color.white;

        B1.color = Color.red;
        Timer = Time.time;
        yield return new WaitForSeconds(dur);
        B1.color = Color.white;
        Debug.Log("Sequenz D Ende  ");
    }



    public   void Session( string seq , float dur  )
    {

               StartCoroutine( Blink(seq, dur));



           



    }

    public IEnumerator Blink(string name, float dur)
    {


        // Debug.Log("Start");

        



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


    public void RandomSequenz()
    {



    }


    public string  Sequenz(string seqname)
    {
        seqname.ToUpper();
        switch (seqname)
        {

            //1324
            
            case "A": return "ACBD";

            //3142
            case "B": return "CADB";
            //4123
            case "C": return "DABC";
            //2431
            case "D": return "BDCA";
            //2341
            case "E": return "BCDA";

            default: return "A";
             



        }


       
    }
  
}
