using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class DEMO : MonoBehaviour
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
    private string SEQSTRING = "";



    int index = 0;
    public int seqindex = 0;
    // public string ButtonSEQ="";
    public float result = 0;
    public bool canPress = false;
    private bool end = false;
    private  int indexer=5;

    [SerializeField]
    private Text text;


    // Start is called before the first frame update
    void Start()
    {
        
        //if(!Directory.Exists(Application.dataPath+"/DEMO_COUNT/") || !Directory.Exists(Application.persistentDataPath+"/DEMO/"))
        Invoke("START", 1f);

        indexer = PlayerPrefs.GetInt("indexer", indexer);
        
        text.text = "Neustarten(" +indexer + ")";
    }
   
    public void onClickRestart()
    {
        if (indexer >0 )
        {
            //text.text = "Neustarten(" + indexer + ")";
            indexer--;
            PlayerPrefs.SetInt("indexer", indexer);


            SceneManager.LoadScene(1);
        }

        if (indexer == 0) {

            indexer = 5;
            PlayerPrefs.SetInt("indexer", indexer);
            SceneManager.LoadScene(2);
        }

       
        
    }
    public void onClickMenu()
    {
        indexer = 0;
        SceneManager.LoadScene(0);
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
        {
            if (canPress)
            {
                B3.color = Color.white;

                endtime = Time.time - Timer;
                mMeasuredTime.Add(endtime);
                mPushedbtn.Add("C");

                index++;
                canPress = false;



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
        SEQSTRING = "ACBD";
        for (int i = 0; i < SEQSTRING.Length; i++)
        {

            mSequences.Add("" + SEQSTRING[i]);


        }


        StartSession(SEQSTRING, 2f);





    }

    public void StartSession(string seq, float dur)
    {

        StartCoroutine(Blink(seq, dur));
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
            if (seqindex < name.Length - 1) seqindex++;
            yield return new WaitForSeconds(0.25f);
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
            yield return new WaitForSeconds(0.25f);

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
            yield return new WaitForSeconds(0.25f);
        }


        if (name[seqindex] == 'D')
        {


            Debug.Log("D");
            B4.color = Color.red;
            Timer = Time.time;
            canPress = true;
            yield return new WaitForSeconds(dur);
            B4.color = Color.white;
            if (seqindex < name.Length - 1) seqindex++;
            yield return new WaitForSeconds(0.25f);

        }

      



        // Rekursiver Aufruf der Klasse
        if (!end)
        {
            if (seqindex < name.Length - 1)
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

    private void START()
    {
        StartCoroutine(StartBlink(1f));
    }

    private IEnumerator StartBlink(float dur)
    {


       
        B1.color = Color.green;
        yield return new WaitForSeconds(dur);

        yield return new WaitForSeconds(0.25f);


        B2.color = Color.green;
        yield return new WaitForSeconds(dur);

        yield return new WaitForSeconds(0.25f);


        B3.color = Color.green;
        yield return new WaitForSeconds(dur);

        yield return new WaitForSeconds(0.25f);

        B4.color = Color.green;
        yield return new WaitForSeconds(dur);
        B1.color = Color.white;
        B2.color = Color.white;
        B3.color = Color.white;
        B4.color = Color.white;
        yield return new WaitForSeconds(0.25f);
        yield return new WaitForSeconds(1f);

        CreateSession();
    }






}

