using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost
{
    public double applyCost(double[] expectedOutputs, double[] predictedOutputs)
    {
        double squareCost = 0;
        for(int i = 0; i < predictedOutputs.Length; i++)
        {
            double cost = predictedOutputs[i] - expectedOutputs[i];
            squareCost = cost * cost;
        }
        return 0.5 * squareCost;
    }


    public double costDerivative(double expectedOutput, double predictedOutput)
    {
        return predictedOutput - expectedOutput;
    }
}
