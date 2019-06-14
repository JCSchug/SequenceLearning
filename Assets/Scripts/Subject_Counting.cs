using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Subject_Counting : MonoBehaviour
{
    private string FilePath;
    private static string persistenceTXTPATH;
    private static int SNR;
    // Start is called before the first frame update
   
    void Start()
    { 
# if UNITY_EDITOR
        FilePath = Application.dataPath + "/NR/";
#else
        FilePath = Application.persistentDataPath+ "/NR/";
#endif
        persistenceTXTPATH = FilePath + "count.txt";
        if (!Directory.Exists(FilePath) || !File.Exists(FilePath+"count.txt"))
        {
            SNR = 0;
            Directory.CreateDirectory(FilePath);
            StreamWriter streamWriter = new StreamWriter(persistenceTXTPATH);
            streamWriter.WriteLine(SNR);
            streamWriter.Flush();
            streamWriter.Close();
        }
        else
        {
            StreamReader streamReader = new StreamReader(persistenceTXTPATH);
            SNR = int.Parse(streamReader.ReadLine())+1;
            streamReader.Close();
            StreamWriter streamWriter = new StreamWriter(persistenceTXTPATH);
            streamWriter.WriteLine(SNR);
            streamWriter.Flush();
            streamWriter.Close();
           
        }
    }
    public static int getSNR()
    {
        return SNR;
    }
    public static void setSNR()
    {
        SNR++;
        StreamWriter streamWriter = new StreamWriter(persistenceTXTPATH);
        streamWriter.WriteLine(SNR);
        streamWriter.Flush();
        streamWriter.Close();
    }
    
    
}
