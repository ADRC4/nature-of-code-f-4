using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Population
{

  float mutationRate;           // Mutation rate
    DNA [] population;             // Array to hold the current population
    List<DNA> matingPool;    // ArrayList which we will use for our "mating pool"
    string target;                // Target phrase
  int generations;              // Number of generations
    bool finished = true;             // Are we finished evolving?
  int perfectScore;

   public Population(string p, float m, int num) {
        target = p;
        mutationRate = m;
        population = new DNA[num];
        for (int i = 0; i < population.Length; i++)
        {
            population[i] = new DNA(target.Length);
        }
        calcFitness();
        matingPool = new List<DNA>();
        finished = false;
        generations = 0;

        perfectScore = 1;
   }

  // Fill our fitness array with a value for every member of the population
  public void calcFitness()
  {
        for (int i = 0; i < population.Length; i++)
        {
            population[i].Fitness(target);
        }
  }

  // Generate a mating pool
  public void naturalSelection()
  {
        // Clear the ArrayList
        matingPool.Clear();

       /* float maxFitness = 0;
        for (int i = 0; i < population.Length; i++)
        {
            if (population[i].fitness > maxFitness)
            {
                maxFitness = population[i].fitness;
            }
        }

        // Based on fitness, each member will get added to the mating pool a certain number of times
        // a higher fitness = more entries to mating pool = more likely to be picked as a parent
        // a lower fitness = fewer entries to mating pool = less likely to be picked as a parent
        for (int i = 0; i < population.Length; i++)
        {

            // float fitness = map(population[i].fitness, 0, maxFitness, 0, 1);
            float fitness = population[i].fitness / maxFitness;
            int n = (int)(fitness * 100);  // Arbitrary multiplier, we can also use monte carlo method
            for (int j = 0; j < n; j++)
            {              // and pick two random numbers
                matingPool.Add(population[i]);
            }
        }*/

        //list from max to min(1,2,3,4,5,6)
        List<DNA> listfitness1 = new List<DNA>();
        List<DNA> finalfitness = new List<DNA>();
        for (int c = 0; c < population.Length; c++)
        {
            listfitness1.Add(population[c]);
        }
        var newlist = listfitness1.OrderBy(t => t.fitness);
        foreach(DNA pop in newlist)
        {
            finalfitness.Add(pop);
        }
        for (int v = 0; v < population.Length; v++)
        {

            int m =(int) (100*(1 + v)/population.Length);
            for (int b = 0; b < m; b++)
            {
                matingPool.Add(finalfitness[v]);
            }
        }
    }

  // Create a new generation
  public void generate()
  {
        // Refill the population with children from the mating pool
        for (int i = 0; i < population.Length; i++)
        {
            int a = (int)(Random.Range(0, matingPool.Count));
            int b = (int)(Random.Range(0, matingPool.Count));
            DNA partnerA = matingPool[a];
            DNA partnerB = matingPool[b];
            DNA child = partnerA.crossover(partnerB);
            child.mutate(mutationRate);
            population[i] = child;
        }
        generations++;
    }


    // Compute the current "most fit" member of the population
    public string getBest()
    {
        float worldrecord = 0.0f;
        int index = 0;
        for (int i = 0; i < population.Length; i++)
        {
            if (population[i].fitness > worldrecord)
            {
                index = i;
                worldrecord = population[i].fitness;
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

  // Compute average fitness for the population
  public float getAverageFitness()
  {
        float total = 0;
        for (int i = 0; i < population.Length; i++)
        {
            total += population[i].fitness;
        }
        return total / (population.Length);
  }

   public string allPhrases() {
        string everything = "";

        int displayLimit = Mathf.Min(population.Length, 50);


        for (int i = 0; i < displayLimit; i++)
        {
            everything += population[i].getPhrase() + "\n";
        }
        return everything;
    }
}

