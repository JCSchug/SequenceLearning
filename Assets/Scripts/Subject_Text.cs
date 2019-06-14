using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subject_Text : MonoBehaviour
{
    private Text text;
    private int snr;
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        text.text = "Herzlich Willkommen, Proband "+Subject_Counting.getSNR().ToString();
        snr = Subject_Counting.getSNR();
    }
    private void Update()
    {
        if(snr != Subject_Counting.getSNR())
        {
            text.text = "Herzlich Willkommen, Proband " + Subject_Counting.getSNR().ToString();
        }
    }

}
