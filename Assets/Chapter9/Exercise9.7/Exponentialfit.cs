using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponentialfit : MonoBehaviour {

    //PFont f;
   // public GUISkin skin;

    string target;
    int popmax;
    float mutationRate;
    Exponentialpopulation population;

    public Text toshow;
    public Text properties;
    public Text allstrings;


    void Start ()
    {
        //size(640, 360);
       // f = createFont("Courier", 32, true);
        target = "To be or not to be.";
        popmax = 150;
        mutationRate = 0.01f;

        // Create a populationation with a target phrase, mutation rate, and populationation max
        population = new Exponentialpopulation(target, mutationRate, popmax);

        // toshow = GetComponent<Text>();
        //StartCoroutine(Count());
    }
	
	// Update is called once per frame
	void Update () {
        if (population.finished != true)
        {
            // Generate mating pool
            population.naturalSelection();
            //Create next generation
            population.generate();
            // Calculate fitness
            population.calcFitness();
            displayInfo();

        }
        else
            print("finish!");
        

    }

   

    void displayInfo()
    {
        //background(255);
        // Display current status of populationation
        string answer = population.getBest();
        //textFont(f);
        //textAlign(LEFT);
        //fill(0);

        //textSize(24);
        toshow.fontSize = 24;
        toshow.text = "Best phrase:" + answer;
        //text("Best phrase:", 20, 30);
        //textSize(40);
        //text(answer, 20, 100);

        //textSize(18);
        properties.fontSize = 18;
        properties.text = "totatl generations:" + population.getGenerations().ToString()+ "\naverage fitness"+ population.getAverageFitness().ToString("F2")+ "\ntotal population: " + popmax.ToString() + "\nmutation rate: " + (mutationRate * 100).ToString() + "%";
        //text("total generations:     " + population.getGenerations(), 20, 160);
        //text("average fitness:       " + nf(population.getAverageFitness(), 0, 2), 20, 180);
        //text("total population: " + popmax, 20, 200);
        //text("mutation rate:         " + int(mutationRate * 100) + "%", 20, 220);

        //textSize(10);
        allstrings.fontSize = 10;
        allstrings.text = "All phrases:\n" + population.allPhrases();
        //text("All phrases:\n" + population.allPhrases(), 500, 10);
    }


    
}
