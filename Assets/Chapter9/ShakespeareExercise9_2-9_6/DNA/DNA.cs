using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA 
{
    
    // The genetic sequence
    char[] genes;

    public float fitness;
    public float fitness1;

    // Constructor (makes a random DNA)
    public DNA(int num)
    {
        genes = new char[num];
        for (int i = 0; i < genes.Length; i++)
        {
            genes[i] = (char)Random.Range(32, 128);  // Pick from range of chars
        }
    }

    // Converts character array to a String
    public string getPhrase()
    {
        return new string(genes);
    }

    // Fitness function (returns floating point % of "correct" characters)
    public void Fitness(string target)
    {
        int score = 0;
        for (int i = 0; i < genes.Length; i++)
        {
            if (genes[i] == target[i])
            {
                score++;
            }
        }


        fitness = (float)score / (float)target.Length;
    }
    public void Exponentialfitness(string target)
    {
        int score = 0;
        for (int i = 0; i < genes.Length; i++)
        {
            if (genes[i] == target[i])
            {
                score++;
            }
        }
        //fitness1 = (float)score / (float)target.Length;
        fitness1 = Mathf.Pow(2, score)/Mathf.Pow(2,target.Length);
        //fitness1 = Mathf.Pow(2, score);
        //fitness1 = Mathf.Pow(score, 2);

    }

    // Crossover
    public DNA crossover(DNA partner)
    {
        // A new child
        DNA child = new DNA(genes.Length);

        int midpoint = (int)(Random.Range(0,genes.Length)); // Pick a midpoint

        // Half from one, half from the other
        for (int i = 0; i < genes.Length; i++)
        {
            if (i > midpoint) child.genes[i] = genes[i];
            else child.genes[i] = partner.genes[i];
        }
        return child;
    }
    // Based on a mutation probability, picks a new random character
    public void mutate(float mutationRate)
    {
        for (int i = 0; i < genes.Length; i++)
        {
            if (Random.value < mutationRate)
            {
                genes[i] = (char)Random.Range(32, 128);
            }
        }
    }
   
}
