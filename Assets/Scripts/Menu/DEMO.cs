using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DEMO : MonoBehaviour
{

    public SpriteRenderer B1;

    public SpriteRenderer B2;

    public SpriteRenderer B3;

    public SpriteRenderer B4;

 
    int index = 0;
    private bool canPress = false;
    private bool end = false;
    private  int indexer=3;


    [SerializeField]
    private Text text;


    // Start is called before the first frame update
    void Start()
    {     
        Invoke("START", 1f);

        indexer = PlayerPrefs.GetInt("indexer", indexer);
        if(indexer == 1)
        {
            text.text = "Start des Experiments";
        }
        else
        {
            text.text = "Neustarten(" + indexer + ")";
        }
        
    }
   
    public void onClickRestart()
    {
        if (indexer > 0 )
        {
            indexer--;
            PlayerPrefs.SetInt("indexer", indexer);
            SceneManager.LoadScene(3);
        }

        if (indexer == 0) {
          
            indexer = 3;
            PlayerPrefs.SetInt("indexer", indexer);
            SceneManager.LoadScene(4);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && canPress)
        {
                index++;
                canPress = false;
        }

        if (Input.GetKeyDown(KeyCode.S) && canPress)
        {
                index++;
                canPress = false;
        }

        if (Input.GetKeyDown(KeyCode.K) && canPress)
        {
                index++;
                canPress = false;
        }


        if (Input.GetKeyDown(KeyCode.L) && canPress)
        {
                index++;
                canPress = false;
           
        }
        if (Input.anyKey && canPress)
        {
            if (!end)
            {
                index++;
                canPress = false;
            }

        }
    }

    public void CreateSession()
    {
        RandomSequence randomSequence = new RandomSequence();
        StartSession(randomSequence, 2f);
    }

    public void StartSession(RandomSequence seq, float dur)
    {

        StartCoroutine(Blink(seq, dur));
    }

    public IEnumerator Blink(RandomSequence name, float dur)
    {
        
        if (name.Btnindex[index] == 1)
        {
            yield return new WaitForSeconds(0.25f);
            B1.color = Color.red;
            canPress = true;
            yield return new WaitUntil(() => Input.anyKey);
            B1.color = Color.white;
        }
        if (name.Btnindex[index] == 2)
        {
            yield return new WaitForSeconds(0.25f);
            B2.color = Color.red;
            canPress = true;
            yield return new WaitUntil(() => Input.anyKey);
            B2.color = Color.white;
        }
        if (name.Btnindex[index] == 3)
        {
            yield return new WaitForSeconds(0.25f);
            B3.color = Color.red;
            canPress = true;
            yield return new WaitUntil(() => Input.anyKey);
            B3.color = Color.white;
        }
        if (name.Btnindex[index] == 4)
        {
            yield return new WaitForSeconds(0.25f);
            B4.color = Color.red;
            canPress = true;
            yield return new WaitUntil(() => Input.anyKey);
            B4.color = Color.white;
        }
        // Rekursiver Aufruf der Klasse
        if (!end)
        {
            if (index < 6)
            {
                StartCoroutine(Blink(name, 2));
            }
            //ENDE
            if (index == 6 || index > 5)
            {
                Debug.Log("Ende " + name.Btnindex.Length + " Index " + index);
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

