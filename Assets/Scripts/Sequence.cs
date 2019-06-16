using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence
{
    private int[] mOrderedBTNs;//The given button combination, e.g.: A,C,B,D
    private int mSequenceName;//The name of the Sequence, e.g.: A

    public Sequence(int[] mOrderedBTNs, int mSequenceName)
    {
        this.MOrderedBTNs = mOrderedBTNs;
        this.MSequenceName = mSequenceName;
    }

    public int[] MOrderedBTNs //public property field for getting and setting the value from mOrderedBTNs
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

    public int MSequenceName //public property field for getting and setting the value from mSequenceName
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
    public int getspecificBTNElement(int pos)
    {
        return mOrderedBTNs[pos];
    }
    public int getFirstElement()//returns the first element from the sequence, interesting for randomizing objects!
    {
        return mOrderedBTNs[0];
    }
    public int getLastElement()//returns the last element from the sequence, interesting for randomizing objects!
    {
        return mOrderedBTNs[mOrderedBTNs.Length-1];
    }
}
