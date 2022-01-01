using UnityEngine;
using System.IO;

public class TestObject : MonoBehaviour, iGazeReceiver
{
    private bool isGazingUpon;
    public float time = 0;
    public bool isDone = true;



    void Start()
    {

    }

    void Update()
    {
        if (isGazingUpon)
        {
            isDone = false;
            time += Time.deltaTime;
            transform.Rotate(0, 3, 0);
        }
        else
        {
            if (!isDone)
            {
                objToJson();
                isDone = true;
            }

        }
    }

    public void GazingUpon()
    {
        isGazingUpon = true;
    }

    public void NotGazingUpon()
    {
        isGazingUpon = false;
    }

    void objToJson()
    {
        string path = @"c:\temp\output.json";
        var outputString = "The user look at the " + gameObject.tag + " for: " + time + "seconds.";

        // This text is added only once to the file.
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hello Admin");
            }
        }

        // This text is always added, making the file longer over time
        // if it is not deleted.
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(outputString);
        }
    }
}
