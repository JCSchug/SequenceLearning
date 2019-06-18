using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class onCreateQuestionaire_FINAL : MonoBehaviour
{
   
    [SerializeField]
    private Text HeaderText;
    [SerializeField]
    private GameObject mDrawingSpot;
    [SerializeField]
    private Button mFinishBTN;
    [SerializeField]
    private ToggleGroup[] mToggleGroups;

    private bool TryDrawHasChoose = false;

    //Data for Serialization
    private bool mSomethingHappend = false;
    private bool mRandomOrNot = false;
    private bool mTryToDraw = false;
    private int[] ChoosenSequences = new int[20]; // The drawed Array of the chossen Sequence of the Subject
   
    // Start is called before the first frame update
    void Start()
    {
        for(int i= 0; i < ChoosenSequences.Length; i++)
        {
            ChoosenSequences[i] = 0;
        }
        HeaderText.text = "Proband - " + Subject_Counting.getSNR(); 
    }

    public void onClickSomethingHappendRB(int index)
    {
        switch (index)
        {
            case 0://Pushed NO
                mSomethingHappend = false;
                break;
            case 1://Pushed YES
                mSomethingHappend = true;
                break;
        }
    }
    public void onClickRandomOrNotRB(int index)
    {
        switch (index)
        {
            case 0://Pushed NO
                mRandomOrNot = false;
                break;
            case 1://Pushed YES
                mRandomOrNot = true;
                break;
        }
    }
    public void OnClickTryToDrawRB(int index)
    {
        switch (index)
        {
            case 0://Pushed NO
                TryDrawHasChoose = true;
                mTryToDraw = false;
                mDrawingSpot.SetActive(false);
                break;
            case 1://Pushed YES
                TryDrawHasChoose = true;
                mTryToDraw = true;
                mDrawingSpot.SetActive(true);
                break;
        }
    }
    
    public void onClickFinish()
    {
        
        Debug.Log("Serializing");
        for(int i = 0; i < mToggleGroups.Length; i++)
        {
            Toggle toggle = mToggleGroups[i].ActiveToggles().FirstOrDefault();
            if(toggle != null)
            {
                ChoosenSequences[i] = int.Parse(toggle.gameObject.name);                
            }
            else
            {
                ChoosenSequences[i] = 0;
            }
        }
        CSVWriter cSVWriter = new CSVWriter(mSomethingHappend, mRandomOrNot, mTryToDraw, ChoosenSequences);
        cSVWriter.GenerateCSVFile(2);
        Debug.Log("writing csv");
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (TryDrawHasChoose && !mTryToDraw || TryDrawHasChoose && mTryToDraw)
            mFinishBTN.interactable = true;
    }
}
