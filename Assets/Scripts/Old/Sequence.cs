using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence
{
    private string[] mOrderedBTNs;//The given button combination, e.g.: A,C,B,D
    private string mSequenceName;//The name of the Sequence, e.g.: A

    public Sequence(string[] mOrderedBTNs, string mSequenceName)
    {
        this.MOrderedBTNs = mOrderedBTNs;
        this.MSequenceName = mSequenceName;
    }

    public string[] MOrderedBTNs //public property field for getting and setting the value from mOrderedBTNs
    {
        get
        {
            return mOrderedBTNs;
        }

        set
        {
            mOrderedBTNs = value;
        }
    }

    public string MSequenceName //public property field for getting and setting the value from mSequenceName
    {
        get
        {
            return mSequenceName;
        }

        set
        {
            mSequenceName = value;
        }
    }
    public string getspecificBTNElement(int pos)
    {
        return mOrderedBTNs[pos];
    }
    public string getFirstElement()//returns the first element from the sequence, interesting for randomizing objects!
    {
        return mOrderedBTNs[0];
    }
    public string getLastElement()//returns the last element from the sequence, interesting for randomizing objects!
    {
        return mOrderedBTNs[mOrderedBTNs.Length-1];
    }
}
