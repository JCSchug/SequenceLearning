using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequenz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomSequenz()
    {



    }


    public string Sequenza(string seqname)
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
