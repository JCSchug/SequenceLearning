using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnCreateQuestionaire_DATA : MonoBehaviour
{
    [SerializeField]
    private Text mHeader;
    [SerializeField]
    private InputField mInstrumentField;
    [SerializeField]
    private ToggleGroup mSexChoosen;
    [SerializeField]
    private ToggleGroup mPlayingGamesYESNO;
    [SerializeField]
    private ToggleGroup mHowManyHoursGroup;
    [SerializeField]
    private ToggleGroup mInstrumentYESNO;
    [SerializeField]
    private Toggle nullfive;
    [SerializeField]
    private Toggle fiveten;
    [SerializeField]
    private Toggle tenfifteen;
    [SerializeField]
    private Toggle morethanfifteen;
    [SerializeField]
    private Button mFinishBTN;

    //Data for Serialization 
    private CSVWriter cSVWriter;
    private string mSex;
    private int mAge;
    private bool mPlayingGames;
    private string mHowManyHours;
    private bool mPlayingInstrument;
    private string mInstrument;

    //Data for Acitivation of "Finish" Button
    private bool enteredText = false;
    private bool chooseAge = false;

    void Start()
    {
        mHeader.text = "Proband - " + Subject_Counting.getSNR();
    }

    void Update()
    {
        if (mSexChoosen.AnyTogglesOn() && chooseAge && mPlayingGames && mHowManyHoursGroup.AnyTogglesOn() && mInstrumentYESNO.AnyTogglesOn() && enteredText
         || mSexChoosen.AnyTogglesOn() && chooseAge && !mPlayingGames && !mHowManyHoursGroup.AnyTogglesOn() && mInstrumentYESNO.AnyTogglesOn() && !enteredText)
            mFinishBTN.interactable = true;
        else
            mFinishBTN.interactable = false;
    }

    public void onClickSex(string mSex)
    {
        this.mSex = mSex;
    }
    public void onAgeValueClick(Text mAge)
    {
        chooseAge = true;
        this.mAge = int.Parse(mAge.text);
    }
    public void onPlayingGamesClick(int toggle)
    {
        if (toggle == 0)
        {
            mPlayingGames = false;
            nullfive.interactable = false;
            fiveten.interactable = false;
            tenfifteen.interactable = false;
            morethanfifteen.interactable = false;
        }
        else if (toggle == 1)
        {
            mPlayingGames = true;
            nullfive.interactable = true;
            fiveten.interactable = true;
            tenfifteen.interactable = true;
            morethanfifteen.interactable = true;
        }
        
    }
    public void onClickHowManyHours(string mHowManyHours)
    {
        this.mHowManyHours = mHowManyHours;
    }
    public void onClickPlayingInstrument(int PlayingInstrument)
    {
        if (PlayingInstrument == 0)
        {
            mInstrumentField.text = "";
            mInstrumentField.interactable = false;
            mPlayingGames = false;
        }
        else if(PlayingInstrument == 1)
        {
            mPlayingInstrument = true;
            mInstrumentField.interactable = true;
        }
       
    }
    public void onValueEnteredInstrument()
    {
        if (mInstrumentField.text.Length > 5 && mPlayingInstrument)
            enteredText = true;
        else if(!mPlayingGames)
        {
            enteredText = true;
        }
        else
        {
            enteredText = false;
        }
    }
    public void onClickFinish()
    {
        if (mInstrument.Equals("") || mInstrument == null && mHowManyHours == null)
        {
            mInstrument = "None";
            mHowManyHours = "None";
            cSVWriter = new CSVWriter(mSex, mAge, mPlayingGames, mHowManyHours, mPlayingInstrument, mInstrument);
            cSVWriter.GenerateCSVFile(1);
            SceneManager.LoadScene(2);
        }
        else
        {
            cSVWriter = new CSVWriter(mSex, mAge, mPlayingGames, mHowManyHours, mPlayingInstrument, mInstrument);
            cSVWriter.GenerateCSVFile(1);
            SceneManager.LoadScene(2);
        }
        
    }
}
