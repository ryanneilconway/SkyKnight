using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class BPMain : MonoBehaviour
{


    public bool chase = false;
    public bool flock = false;
    public bool evade = false;
    

    public static double[][] TrainingSet = new double[][] { 
	    //friends Zombiehealth  enemyHealth    range   chase   flock   evade
     new double[] {0,     1,      0,      0.2,    0.9,    0.1,    0.1},  
     new double[] {0,     1,      1,      0.2,    0.9,    0.1,    0.1},
     new double[] {0,     1,      0,      0.8,    0.1,    0.1,    0.1}, 
     new double[] {0.1,   0.5,    0,      0.2,    0.9,    0.1,    0.1}, 
     new double[] {0,     0.25,   1,      0.5,    0.1,    0.9,    0.1}, 
     new double[]{0,     0.2,    1,      0.2,    0.1,    0.1,    0.9}, 
     new double[]{0.3,   0.2,    0,      0.2,    0.9,    0.1,    0.1},
     new double[]{0,     0.2,    0,      0.3,    0.1,    0.9,    0.1},
     new double[]{0,     1,      0,      0.2,    0.1,    0.9,    0.1},
     new double[] {0,     1,      1,      0.6,    0.1,    0.1,    0.1},
     new double[]{0,     1,      0,      0.8,    0.1,    0.9,    0.1},
     new double[]{0.1,   0.2,    0,      0.2,    0.1,    0.1,    0.9},
     new double[]{0,     0.25,   1,      0.5,    0.1,    0.1,    0.9},
     new double[]{0,     0.6,    0,      0.2,    0.1,    0.1,    0.9}
 };


    public NeuralNetwork TheBrain = new NeuralNetwork();

    void Start()

    {
        TheBrain.Initialize(4, 3, 3);
        TheBrain.SetLearningRate(0.2);
        TheBrain.SetMomentum(true, 0.9);
        TrainTheBrain();
    }

    public void TrainTheBrain()
    {

        int i;
        double error = 1;
        int c = 0;

        while ((error > 0.05) && (c < 50000))
        {
            error = 0;
            c++;
            for (i = 0; i < 14; i++)
            {
                TheBrain.SetInput(0, TrainingSet[i][0]);
                TheBrain.SetInput(1, TrainingSet[i][1]);
                TheBrain.SetInput(2, TrainingSet[i][2]);
                TheBrain.SetInput(3, TrainingSet[i][3]);

                TheBrain.SetDesiredOutput(0, TrainingSet[i][4]);
                TheBrain.SetDesiredOutput(1, TrainingSet[i][5]);
                TheBrain.SetDesiredOutput(2, TrainingSet[i][6]);


                TheBrain.FeedForward();
                error += TheBrain.CalculateError();
                TheBrain.BackPropagate();

            }
            error = error / 14.0f;
        }

        //c = c * 1;

        print("Brain Trained");
    }





    public void TestTheBrain(int inputNode, double TestData)
    {
         //TheBrain.SetInput(inputNode, TestData[0]);
        //TheBrain.SetInput(1, TrainingSet[0][0]);
        //TheBrain.SetInput(1, TrainingSet[0][1]);
        //TheBrain.SetInput(2, TrainingSet[0][2]);
        //TheBrain.SetInput(3, TrainingSet[0][3]);

        TheBrain.FeedForward();

        double max = -1000.0;
        int index = -1000;
        for (int j = 0; j < 3; j++)
        {
            if (max < TheBrain.GetOutput(j))
            {
                max = TheBrain.GetOutput(j);
                index = j;
            }
        }
        if (index == 0)
        {
            chase = true;
        }
        else if (index == 1)
        {
            flock = true;
        }
        else if (index == 2)
        {
            evade = true;
        }
    }

}
