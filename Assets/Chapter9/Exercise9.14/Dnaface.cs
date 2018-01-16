using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dnaface
{
    
        // The genetic sequence
        public float[] genes;
        int len = 20;  // Arbitrary length

        //Constructor (makes a random DNA)
        public Dnaface()
        {
            // DNA is random floating point values between 0 and 1 (!!)
            genes = new float[len];
            for (int i = 0; i < genes.Length; i++)
            {
                genes[i] = Random.value;
            }
        }

        Dnaface(float[] newgenes)
        {
            genes = newgenes;
        }


        // Crossover
        // Creates new DNA sequence from two (this & 
        public Dnaface crossover(Dnaface partner)
        {
            float[] child = new float[genes.Length];
            int crossover = (int)(Random.Range(0,genes.Length));
            for (int i = 0; i < genes.Length; i++)
            {
                if (i > crossover) child[i] = genes[i];
                else child[i] = partner.genes[i];
            }
        Dnaface newgenes = new Dnaface(child);
            return newgenes;
        }

        // Based on a mutation probability, picks a new random character in array spots
        public void mutate(float m)
        {
            for (int i = 0; i < genes.Length; i++)
            {
                if (Random.value < m)
                {
                    genes[i] = Random.value;
                }
            }
        }
}
