using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DataPoint
{
    public readonly double[] inputs;
    public readonly double[] expectedOutputs;
    public readonly int label;

    public DataPoint(double[] inputs, int label, int numLabels)
    {
        this.inputs = inputs;
        this.label = label;
        expectedOutputs = OneHot(label, numLabels);
    }

    public static double[] OneHot(int index, int num)
    {
        double[] oneHot = new double[num];
        oneHot[index] = 1;
        return oneHot;
    }
}
