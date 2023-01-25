using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text costText;
    public Cost cost;

    public DataLoader dataLoader;

    public NodeBasedNetwork network;

    public double learnRate;
    public int batchSize;
    public int[] layerSizes;

    public void loadNetwork()
    {
        dataLoader.loadDataFromTrainingFile(batchSize);
        DataPoint[] data = dataLoader.data;
        trainNetwork(data, layerSizes);
    }

    public void trainNetwork(DataPoint[] data, int[] layerSizes)
    {
        network = new NodeBasedNetwork(layerSizes);
        
        for(int i = 0; i <= 0; i++)
        {
            //Debug.Log(data[i].label);
            Debug.Log(network.totalCost(data));
        }
    }   
}
