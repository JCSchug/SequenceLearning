using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sess
{
    private List<Sequence> mSequences; //The list of Sequences
    private int mIterations; //How often should the session pattern loop trough?

    public Sess(List<Sequence> mSequences, int mIterations)
    {
        this.MSequences = mSequences;
        this.MIterations = mIterations;
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

    public int MIterations//public property field for getting and setting the value from mIterations
    {
        get
        {
            return mIterations;
        }

        set
        {
            mIterations = value;
        }
    }
}

