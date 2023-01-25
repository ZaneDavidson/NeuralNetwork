using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class DataLoader : MonoBehaviour
{
    public DataPoint[] data;
    public TextAsset trainingFile;
    [SerializeField]
    public int numLabels;
    int label;


    public void loadDataFromTrainingFile(int batchSize)
    {
        string filePath = AssetDatabase.GetAssetPath(trainingFile);
        if(!File.Exists(filePath))
        {
            Debug.Log("No training file at this path!");
            return;
        }      

        string[] textFromFile = File.ReadAllLines(filePath);
        data = new DataPoint[batchSize];
        for(int line = 0; line < batchSize; line++)
        {
            string[] temp = textFromFile[line].Split(',');
            label = Int32.Parse(temp[0]);
            temp = temp.Skip(1).ToArray();
            int length = temp.Length;

            double[] outputs = new double[length];

            for(int item = 0; item < length; item++)
            {
                outputs[item] = (double)Int32.Parse(temp[item]);
            }

            data[line] = createDataPoint(outputs, label, numLabels);
        }
    }

    DataPoint createDataPoint(double[] inputs, int label, int numLabels)
    {
        return new DataPoint(inputs, label, numLabels);
    }
}
