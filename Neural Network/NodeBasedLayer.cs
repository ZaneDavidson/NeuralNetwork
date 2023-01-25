using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBasedLayer
{
    public int numNodes;
    public int numNodesInNextLayer;
    public Node[] nodes;
    public Cost cost;
    public double[] biasGradients;
    public double[] weightGradients;

    public NodeBasedLayer(int numNodes, int numNodesInNextLayer)
    {
        cost = new Cost();
        nodes = new Node[numNodes];

        this.numNodes = numNodes;
        this.numNodesInNextLayer = numNodesInNextLayer;

        biasGradients = new double[numNodes];
        weightGradients = new double[numNodes];
        
        for(int i = 0; i < numNodes; i++)
        {
            nodes[i] = new Node(initializeNodeWeight(), 1);
        }
    }

    public double[] calculateLayerOutputs(double[] inputs)
    {
        double[] outputs = new double[numNodesInNextLayer];
        for(int numNodesNext = 0; numNodesNext < numNodesInNextLayer; numNodesNext++)
        {
            double output = 0;
            for(int numNodesInLayer = 0; numNodesInLayer < numNodes; numNodesInLayer++)
            {
                output += nodes[numNodesInLayer].transformValue(inputs[numNodesInLayer]);
            }
            outputs[numNodesNext] = output;
        }
        return outputs;
    }

    public void calculateGradients(DataPoint[] data)
    {
        for(int numNodesNext = 0; numNodesNext < numNodesInNextLayer; numNodesNext++)
        {
            for(int numNodesInLayer = 0; numNodesInLayer < numNodes; numNodesInLayer++)
            {

            }
        }
    }

    public void applyGradients(double learnRate)
    {
        for(int numNodesInLayer = 0; numNodesInLayer < numNodes; numNodesInLayer++)
        {
            nodes[numNodesInLayer].bias -= biasGradients[numNodesInLayer] * learnRate;
            nodes[numNodesInLayer].weight -= weightGradients[numNodesInLayer] * learnRate;
        }
    }

    public double calculateLayerCost(double[] inputs, double[] expectedOutputs)
    {
        double layerCost = 0;
        double[] predictedOutputs = calculateLayerOutputs(inputs);
        layerCost = cost.applyCost(predictedOutputs, expectedOutputs);
        return layerCost;
    }
    
    public double initializeNodeWeight()
    {
        System.Random rng = new System.Random();
        double rand = rng.NextDouble() * 2 - 1;
        rand = rand / numNodes;
        return rand;
    }
}
