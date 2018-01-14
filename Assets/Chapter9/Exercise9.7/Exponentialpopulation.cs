using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Exponentialpopulation
{
    float mutationRate;           // Mutation rate
    DNAchar[] population;             // Array to hold the current population
    List<DNAchar> matingPool;    // ArrayList which we will use for our "mating pool"
    string target;                // Target phrase
    int generations;              // Number of generations
    public bool finished ;             // Are we finished evolving?
    int perfectScore;

    public Exponentialpopulation(string p, float m, int num)
    {
        target = p;
        mutationRate = m;
        population = new DNAchar[num];
        for (int i = 0; i < population.Length; i++)
        {
            population[i] = new DNAchar(target.Length);
        }
        calcFitness();
        matingPool = new List<DNAchar>();
        finished = false;
        generations = 0;

        perfectScore = 1;
        //perfectScore = (int)(Mathf.Pow(2, target.Length));
    }
    public void calcFitness()
    {
        for (int i = 0; i < population.Length; i++)
        {
            population[i].Exponentialfitness(target);
        }
    }
    public void naturalSelection()
    {
        // Clear the ArrayList
        matingPool.Clear();

        float maxFitness = 0;
        for (int i = 0; i < population.Length; i++)
        {
            if (population[i].fitness1 > maxFitness)
            {
                maxFitness = population[i].fitness1;
            }
        }

        for (int i = 0; i < population.Length; i++)
        {

            // float fitness = map(population[i].fitness, 0, maxFitness, 0, 1);
            float fitness = population[i].fitness1 / maxFitness;
            int n = (int)(fitness * 100);  
            // Arbitrary multiplier, we can also use monte carlo method
            for (int j = 0; j < n; j++)
            {           
                // and pick two random numbers
                matingPool.Add(population[i]);
            }
            
        }
        
    }
    public void generate()
    {
        // Refill the population with children from the mating pool
        for (int i = 0; i < population.Length; i++)
        {
            int a = (int)(Random.Range(0, matingPool.Count));
            int b = (int)(Random.Range(0, matingPool.Count));

            //exercise9.4 two unique 'parents'
            if (a == b)
                b = b + (b > 0.5 * matingPool.Count ? -1 : 1);


            DNAchar partnerA = matingPool[a];
            DNAchar partnerB = matingPool[b];
            DNAchar child = partnerA.crossover(partnerB);
            child.mutate(mutationRate);
            population[i] = child;
        }
        generations++;
    }

    public string getBest()
    {
        float worldrecord = 0.0f;
        int index = 0;
        for (int i = 0; i < population.Length; i++)
        {
            if (population[i].fitness1 > worldrecord)
            {
                index = i;
                worldrecord = population[i].fitness1;
            }
        }

        if (worldrecord == perfectScore)
            finished = true;
        return population[index].getPhrase();
    }

    public bool Finished()
    {
        return finished;
    }

    public int getGenerations()
    {
        return generations;
    }

    public float getAverageFitness()
    {
        float total = 0;
        for (int i = 0; i < population.Length; i++)
        {
            total += population[i].fitness1;
        }
        return total / (population.Length);
    }
    public string allPhrases()
    {
        string everything = "";

        int displayLimit = Mathf.Min(population.Length, 50);


        for (int i = 0; i < displayLimit; i++)
        {
            everything += population[i].getPhrase() + "\n";
        }
        return everything;
    }
}
