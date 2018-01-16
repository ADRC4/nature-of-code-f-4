using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Populationface
{

    float mutationRate;           // Mutation rate
    public Face[] population;            // array to hold the current population
    List<Face> matingPool;   // ArrayList which we will use for our "mating pool"
    int generations;              // Number of generations

    // Create the population
    public Populationface(float m, int num)
    {
        mutationRate = m;
        population = new Face[num];
        matingPool = new List<Face>();
        generations = 0;
        for (int i = 0; i < population.Length; i++)
        {
            population[i] = new Face(new Dnaface(), 50 + i * 75, 60);
        }
    }

    // Display all faces
    public void display(GameObject head, GameObject mouth, GameObject eye1, GameObject eye2, GameObject boundingbox)
    {
        for (int i = 0; i < population.Length; i++)
        {
            population[i].display(head, mouth, eye1, eye2,boundingbox,i);
        }
    }

    // Are we rolling over any of the faces?
    public void rollover(int mx, int my)
    {
        for (int i = 0; i < population.Length; i++)
        {
            population[i].rollover(mx, my,i);
        }
    }

    // Generate a mating pool
    public void selection()
    {
        // Clear the ArrayList
        matingPool.Clear();

        // Calculate total fitness of whole population
        float maxFitness = getMaxFitness();

        // Calculate fitness for each member of the population (scaled to value between 0 and 1)
        // Based on fitness, each member will get added to the mating pool a certain number of times
        // A higher fitness = more entries to mating pool = more likely to be picked as a parent
        // A lower fitness = fewer entries to mating pool = less likely to be picked as a parent
        for (int i = 0; i < population.Length; i++)
        {
            float fitnessNormal = population[i].getFitness() / maxFitness;
            int n = (int)(fitnessNormal * 100);  // Arbitrary multiplier
            for (int j = 0; j < n; j++)
            {
                matingPool.Add(population[i]);
            }
        }
    }

    // Making the next generation
    public void reproduction()
    {
        // Refill the population with children from the mating pool
        for (int i = 0; i < population.Length; i++)
        {
            // Sping the wheel of fortune to pick two parents
            int m = (int)(Random.Range(0,matingPool.Count));
            int d = (int)(Random.Range(0, matingPool.Count));
            // Pick two parents
            Face mom = matingPool[m];
            Face dad = matingPool[d];
            // Get their genes
            Dnaface momgenes = mom.getDNA();
            Dnaface dadgenes = dad.getDNA();
            // Mate their genes
            Dnaface child = momgenes.crossover(dadgenes);
            // Mutate their genes
            child.mutate(mutationRate);
            // Fill the new population with the new child
            population[i] = new Face(child, 50 + i * 75, 60);
        }
        generations++;
    }

    public int getGenerations()
    {
        return generations;
    }

    // Find highest fintess for the population
    public float getMaxFitness()
    {
        float record = 0;
        for (int i = 0; i < population.Length; i++)
        {
            if (population[i].getFitness() > record)
            {
                record = population[i].getFitness();

            }
        }
        return record;

    }
    public float getMaxPopular()
    {
        float record = 0;
        float picnumber = 0;
        for (int i = 0; i < population.Length; i++)
        {
            if (population[i].getFitness() > record)
            {
                record = population[i].getFitness();
                picnumber = i+1;
            }
        }
        return picnumber;

    }
}
