using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MeanSquaredError
public class Cost
{

	public double applyCost(double expectedOutputs[], double predictedOutputs[])
	{
		public double cost;
		for(int i = 0; i < expectedOutputs.Length; i++)
		{
			cost += (predictedOutputs[i] - expectedOutputs[i]) * (predictedOutputs[i] - expectedOutputs[i])
		}

		return 0.5 * cost;
	}

	public double costGradient(double expectedOutput, double predictedOutput)
	{
		return predictedOutput - expectedOutput;
	}

	public double layerCost()
	{
		
	}
}
