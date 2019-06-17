using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystematicSequence 
{
    // 1 4 3 1 3 2 
    private int[] btnindex = {1,4,3,1,3,2};
    public SystematicSequence()
    {

    }

    public int[] Btnindex { get => btnindex; set => btnindex = value; }
}
