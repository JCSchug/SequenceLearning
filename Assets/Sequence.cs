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
    public float[] endtime = new float[16];
    int index = 0;

    public string ButtonSEQ="";
     public float result = 0;
    public bool end = false;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreateSession();
        }



        if (Input.GetKeyDown(KeyCode.A))
        {
            B1.color = Color.white;
            endtime[index]= Time.time-Timer;
            Debug.Log(result);
            ButtonSEQ += " A";
            index++;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            B2.color = Color.white;
            endtime[index]=Time.time - Timer;
            Debug.Log(result);
            ButtonSEQ += " S";
            index++;
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            B3.color = Color.white;
            endtime[index] = Time.time - Timer;
            Debug.Log(result);
            ButtonSEQ += " K";
            index++;
        }

        
        if (Input.GetKeyDown(KeyCode.L))
        {
            B4.color = Color.white;
            endtime[index] = Time.time - Timer;
            Debug.Log(result);
            ButtonSEQ += " L";
            index++;
        }


    }

    public void CreateSession()
    {
        StartCoroutine(SEQA(2));
        
        

       

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





    public void RandomSequence()
    {



    }
  
}
