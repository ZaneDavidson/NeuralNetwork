using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NodeBasedNetwork
{
    public NodeBasedLayer[] layers;

    public NodeBasedNetwork(int[] layerSizes) 
    {
        layers = new NodeBasedLayer[layerSizes.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            if(i == layers.Length - 1)
            {
                layers[i] = new NodeBasedLayer(layerSizes[i], layerSizes[i]);
            }
            else
            {
                layers[i] = new NodeBasedLayer(layerSizes[i], layerSizes[i + 1]);
            }
        }
    }

    public void Learn(DataPoint[] data, double learnRate)
    {
        const double init = 0.00001;
        double initCost = totalCost(data);

        foreach(NodeBasedLayer layer in layers)
        {
            layer.calculateGradients(data);
        }
    }

    double[] calculateNetworkOutputs(double[] inputs)
    {
        foreach(NodeBasedLayer layer in layers)
        {
            inputs = layer.calculateLayerOutputs(inputs);
        }
        return inputs;
    }

    public double returnProbableOutput(double[] inputs)
    {
        double[] probableOutput = calculateNetworkOutputs(inputs);
        return findMaxIndex(probableOutput);
    }


    public double Cost(DataPoint dataPoint)
    {
        double[] outputs = calculateNetworkOutputs(dataPoint.inputs);
        double cost = 0;
        NodeBasedLayer outputLayer = layers[layers.Length - 1];
        cost += outputLayer.calculateLayerCost(outputs, dataPoint.expectedOutputs);
        return cost;
    } 

    public double totalCost(DataPoint[] data)
    {
        double cost = 0;
        foreach(DataPoint dataPoint in data)
        {
            cost += Cost(dataPoint);
        }
        return cost / data.Length;
    }

    double findMaxIndex(double[] inputs)
    {
        double maxValue = double.MinValue;
        int index = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i] > maxValue)
            {
                maxValue = inputs[i];
                index = i;
            }
        }
        return index;
    }
}
