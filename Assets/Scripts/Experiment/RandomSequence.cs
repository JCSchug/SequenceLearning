using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSequence
{
    private int[] btnindex = new int[6];

    public RandomSequence(int lastnumber = 0, int beginning = 0)
    {
        if(lastnumber != 0)
        {
            Btnindex = generateRandomObject(0, lastnumber);
        }
        else if(lastnumber != 0 && beginning != 0)
        {
            Btnindex = generateRandomObject(0, lastnumber, new int[6],beginning);
        }
        else
        {
            Btnindex = generateRandomObject(0);
        }
        

    }

    public int[] Btnindex {
        get
        {
            return btnindex;
        }
        set
        {
            btnindex = value;
        }
    }
   
    
    public int[] generateRandomObject(int index, int lastnumber = 0, int[] totalResult = null, int beginning = 0)
    {
        int[] random = new int[] { 1, 2, 3, 4 };
        int rnd = Random.Range(0, random.Length); // Random. Range ( 0, 4)
        if (totalResult == null)
            totalResult = new int[6];
        if (random[rnd] == lastnumber)//z.B.: 3.Durchgang
            return generateRandomObject(index, lastnumber, totalResult, beginning);
        else if (index == totalResult.Length - 1 && random[rnd] == 1)
        {
            //Die letzte Zahl
            //Debug.Log("Kritische Stelle");
            return generateRandomObject(index, lastnumber, totalResult, beginning);
        }   
        else
        {
            totalResult[index] = random[rnd];
            if (index + 1 == totalResult.Length)
            {
                //Debug.Log(totalResult[0] + ", " + totalResult[1] + ", " + totalResult[2] + ", " + totalResult[3] + ", " + totalResult[4] + ", " + totalResult[5]);
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
  
}