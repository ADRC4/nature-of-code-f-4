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
    //public Button button;

    //Rect but;

    public Text wordsbased;
    public Text fitnessvalue;
    void Start () {
       // size(800, 200);
       // colorMode(RGB, 1.0);
        int popmax = 4;
        float mutationRate = 0.05f;  // A pretty high mutation rate here, our population is rather small we need to enforce variety
                                    // Create a population with a target phrase, mutation rate, and population max
        population = new Populationface(mutationRate, popmax);
        // A simple button class
        //button = new Button(15, 150, 160, 20, "evolve new generation");
        // but = new Rect(15, 150, 160, 20);
        // button.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        
    }
	
	// Update is called once per frame
	void Update () {
        //background(1.0);
        // Display the faces
        population.display( head,  mouth,  eye1, eye2,  boundingbox);
        population.rollover((int)Input.mousePosition.x, (int)Input.mousePosition.y);

        // Display some text
        // textAlign(LEFT);
        infgeneration.color = Color.black;
        //infgeneration.rectTransform.position = new Vector3(15, 190, 0);
        //infgeneration.transform.position = new Vector2(15, 190);
        infgeneration.text = "Generation #:" + population.getGenerations()+"\nMost popular:"+population.getMaxPopular().ToString();
        //fill(0);
        //text("Generation #:" + population.getGenerations(), 15, 190);

        
        // Display the button
        //button.display();
       // button.rollover((int)Input.mousePosition.x, (int)Input.mousePosition.y);
        if (Input.GetButtonDown("Fire1"))
        {
            population.selection();
            population.reproduction();
        }
           
               
           
       // if (Input.GetMouseButtonUp(0))
         //   button.released();

    }
    /*void TaskOnClick()
    {
        population.selection();
        population.reproduction();
    }*/
   

    // If the button is clicked, evolve next generation
    /* void mousePressed()
     {
         if (button.clicked((int)Input.mousePosition.x, (int)Input.mousePosition.y))
         {
             population.selection();
             population.reproduction();
         }
     }
     void mouseReleased()
     {
         button.released();
     }*/
    
}
