using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour
{
    public Layer[] layers;

    public Network(params int[] layerSizes) 
    {
        layers = new Layer[layerSizes.Length];
        foreach(int i in layerSizes)
        {
            layers[i] = new Layer(layerSizes[i], layerSizes[i + 1]);
        }
    }

    public double[] loopThroughNetwork(double[] inputs)
    {
        foreach(Layer layer in layers)
        {
            inputs = layer.calculateLayerOutputs(inputs);
        }
        return inputs;
    }

    public double[] returnProbableOutput(double[] inputs)
    {
        double[] probableOutput = loopThroughNetwork(inputs);
        return probableOutput;
    }
}
