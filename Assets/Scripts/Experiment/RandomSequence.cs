using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSequence
{
    private int[] btnindex = new int[6];

    public RandomSequence()
    {

       // generateRandomObject(0);
         createRandomSequence();

    }

    public int[] Btnindex { get => btnindex; set => btnindex = value; }
   
    public int[] generateRandomObject(int index, int lastnumber = 0, int[] totalResult = null, int beginning = 0)
    {
        int[] random = new int[] { 1, 2, 3, 4 };
        int rnd = Random.Range(1, random.Length);
        if (totalResult == null)
            totalResult = new int[6];
        if (random[rnd] == lastnumber)
            return generateRandomObject(index, lastnumber, totalResult, beginning);
        else if (index == totalResult.Length - 1 && random[rnd] == beginning)
            return generateRandomObject(index, lastnumber, totalResult, beginning);
        else
        {
            totalResult[index] = random[rnd];
            if (index + 1 == totalResult.Length)
            {
                Debug.Log(totalResult[0] + ", " + totalResult[1] + ", " + totalResult[2] + ", " + totalResult[3] + ", " + totalResult[4] + ", " + totalResult[5]);
                return totalResult;
            }
            else
            {
                index++;
                lastnumber = random[rnd];
                return generateRandomObject(index, lastnumber, totalResult, beginning);
            }

        }

    }
    //1. RandomSequenz:
    //object.BtnIndex = object.generateRandomObject(0);
    //





    public void createRandomSequence()
    {

        for (int i = 0; i < btnindex.Length; i++)
        {
            btnindex[i] = (int)Random.Range(0, 4) + 1;

        }





    }
}