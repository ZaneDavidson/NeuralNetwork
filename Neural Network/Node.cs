using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public double weight;
    public double bias;

    public Node(double weight, double bias)
    {
        this.weight = weight;
        this.bias = bias;
    }

    public double transformValue(double input)
    {
        double transformedValue = 0;
        transformedValue = Activation(bias + weight * input);
        return transformedValue;
    }

    public double Activation(double input)
    {
        return 1 / (1 + Math.Pow(Math.E, -input));
    }

    public double ActivationDerivative(double input)
    {
        return Activation(input) * (1 - Activation(input));
    }

    public void nodeCost()
    {

    }
}
