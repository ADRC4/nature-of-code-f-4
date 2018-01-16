using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Faceinteraction : MonoBehaviour {

    Populationface population;
    //Button button;
    public Text infgeneration;
    public GameObject head;
    public GameObject mouth;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject boundingbox;
    

    

    public Text wordsbased;
    public Text fitnessvalue;
    void Start () {
       
        int popmax = 4;
        float mutationRate = 0.05f;  // A pretty high mutation rate here, our population is rather small we need to enforce variety
                                    // Create a population with a target phrase, mutation rate, and population max
        population = new Populationface(mutationRate, popmax);
       
        
    }
	
	// Update is called once per frame
	void Update () {
        //background(1.0);
        // Display the faces
        population.display( head,  mouth,  eye1, eye2,  boundingbox);
        population.rollover((int)Input.mousePosition.x, (int)Input.mousePosition.y);

        
        infgeneration.color = Color.black;
        
        infgeneration.text = "Generation #:" + population.getGenerations()+"\nMost popular:"+population.getMaxPopular().ToString();
        

        
        
        if (Input.GetMouseButtonDown(0))
        {
            population.selection();
            population.reproduction();
        }
           
               
           
      

    }
    
    
}
