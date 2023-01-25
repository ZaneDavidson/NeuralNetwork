using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public double[,] weights;
    public double[] biases;
    int numNodesIn, numNodesOut;

    public Layer(int numNodesIn, int numNodesOut)
    {
        this.numNodesIn = numNodesIn;
        this.numNodesOut = numNodesOut;
        biases = new double[numNodesOut];
        weights = new double[numNodesIn, numNodesOut];
    }

    public double[] calculateLayerOutputs(double[] inputs)
    {
        double[] outputs = new double[numNodesOut];
        for(int currentNodeOut = 0; currentNodeOut < numNodesOut; currentNodeOut++)
        {
            double outputBias = biases[currentNodeOut];
            for(int currentNodeIn = 0; currentNodeIn < numNodesIn; currentNodeIn++)
            {
                outputBias += inputs[currentNodeIn] + weights[currentNodeIn, currentNodeOut];
            }
            outputs[currentNodeOut] += Activation(outputBias);
        }
        return outputs;
    }

    public void weightInit()
    {
        Random rng = new Random;
        for(int currentNodeIn = 0; currentNodeIn < numNodesIn; currentNodeIn++)
        {
            for(int currentNodeOut = 0; currentNodeOut < numNodesOut; currentNodeOut++)
            {
                double rand = rng.NextDouble() * 2 - 1;
                weights[currentNodeIn, currentNodeOut] = rand / Math.Sqrt(numNodesIn)
            }
        }
    }

    public double Activation(double input)
    {
        //tanh
        return (Math.Pow(Math.E, input) - Math.Pow(Math.E, -input)) / (Math.Pow(Math.E, input) + Math.Pow(Math.E, -input);
}
