using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sess
{
    private List<Sequence> mSequences; //The list of Sequences
    private int mRepitions; //How often should the session pattern loop trough?

    public Sess(List<Sequence> mSequences, int mRepition)
    {
        this.MSequences = mSequences;
        this.MRepitions = mRepition;
    }

    public List<Sequence> MSequences//public property field for getting and setting the value from mSequences
    {
        get
        {
            return mSequences;
        }

        set
        {
            mSequences = value;
        }
    }

    public int MRepitions//public property field for getting and setting the value from mIterations
    {
        get
        {
            return mRepitions;
        }

        set
        {
            mRepitions = value;
        }
    }
}

