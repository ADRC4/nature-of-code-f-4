using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Face 
{

    Dnaface dna;          // Face's DNA
    public float fitness;    // How good is this face?
    float x, y;       // Position on screen
    int wh = 70;      // Size of square enclosing face
    bool rolloverOn; // Are we rolling over this face?

    //public GameObject sphere;
   // public GameObject head;

    //public GameObject cube;
   // public GameObject eye1;
    //public GameObject eye2;
    //public GameObject mouth;
   // public GameObject boundingbox;

    public Text fitnessvalue;
    GameObject words;



    public Rect r;

    // Create a new face
    public Face(Dnaface dna_, float x_, float y_)
    {
        dna = dna_;
        x = x_;
        y = y_;
        fitness = 1;
        
        r = new Rect((int)(x - wh / 2), (int)(y - wh / 2), (int)(wh), (int)(wh));
    }

    // Display the face
   public void display(GameObject head,GameObject mouth,GameObject eye1,GameObject eye2,GameObject boundingbox,int m)
    {
        string h = string.Format("head{0}", m);
        string e1 = string.Format("eye1{0}", m);
        string e2 = string.Format("eye2{0}", m);
       string mou = string.Format("mouth{0}", m);
       string bou = string.Format("boundingbox{0}", m);
        string counts = string.Format("counts{0}", m);
        // We are using the face's DNA to pick properties for this face
        // such as: head size, color, eye position, etc.
        // Now, since every gene is a floating point between 0 and 1, we map the values
        float r = dna.genes[0]* 70;
        Color c = new Color(dna.genes[1], dna.genes[2], dna.genes[3]);
        float eye_y = dna.genes[4]*5;
        float eye_x =dna.genes[5]* 10;
        float eye_size = dna.genes[5]*10;
        Color eyecolor = new Color(dna.genes[4], dna.genes[5], dna.genes[6]);
        Color mouthColor = new Color(dna.genes[7], dna.genes[8], dna.genes[9]);
        float mouth_y =dna.genes[5]*8;
        float mouth_x = -5+dna.genes[5]*15;
        float mouthw = dna.genes[5]* 50;
        float mouthh = dna.genes[5]*10;

        // Once we calculate all the above properties, we use those variables to draw rects, ellipses, etc.
        

        // Draw the head
        //head = Instantiate(sphere, new Vector3(0,0,0), Quaternion.identity);
        head = GameObject.Find(h);
        //head = GameObject.Find("head0");
        head.transform.position = new Vector3(0, 0, 0);
        head.GetComponent<Renderer>().material.color = c;
        head.transform.localScale = new Vector3(r, r, r);

        

        // Draw the eyes
        eye1 = GameObject.Find(e1);
        //eye1 = GameObject.Find("eye10");
        eye1.transform.position =  new Vector3(-eye_x, eye_y, 0);
       
        eye1.GetComponent<Renderer>().material.color = eyecolor;
        eye1.transform.localScale = new Vector3(eye_size, eye_size, eye_size);

        eye2 = GameObject.Find(e2);
        //eye2 = GameObject.Find("eye20");

        eye2.transform.position = new Vector3(eye_x, eye_y, 0);
        eye2.GetComponent<Renderer>().material.color = eyecolor;
        eye2.transform.localScale = new Vector3(eye_size, eye_size, eye_size);

        


        // Draw the mouth
        mouth = GameObject.Find(mou);
        

        mouth.transform.position = new Vector3(mouth_x, mouth_y-8, 0);
        mouth.GetComponent<Renderer>().material.color = mouthColor;
        mouth.transform.localScale = new Vector3(mouthw, mouthh,0);

        

        // Draw the bounding box
        //stroke(0.25);
       
        boundingbox = GameObject.Find(bou);
        
        boundingbox.transform.position = new Vector3(0, 0, 0);

        boundingbox.transform.localScale = new Vector3(wh+5, wh+5, wh+5);
        
        if (rolloverOn)
            boundingbox.GetComponent<Renderer>().material.color =new Color(200,200,200,0.25f);
        
        else
            boundingbox.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

        head.transform.position += Vector3.right * 20 * m;
        eye1.transform.position += Vector3.right * 20 * m;
        eye2.transform.position += Vector3.right * 20 * m;
        mouth.transform.position += Vector3.right * 20 * m;
        boundingbox.transform.position += Vector3.right * 20 * m;




        

        
        words = GameObject.Find(counts);
       fitnessvalue = words.GetComponent<Text>();
        if (rolloverOn)
            
            fitnessvalue.color = Color.black;
        else
            fitnessvalue.color = Color.gray;
        fitnessvalue.transform.position = new Vector2(x+450, y + 55);
        fitnessvalue.text = fitness.ToString("F0");
       
    }

    public float getFitness()
    {
        return fitness;
    }

    public Dnaface getDNA()
    {
        return dna;
    }

    // Increment fitness if mouse is rolling over face
    public void rollover(int mx, int my,int i)
    {
        if (mx > 150 * i + 300 && mx < 150 * i + 350 && my >  250 && my < 350)
        {
            rolloverOn = true;
            fitness += 0.25f;
        }
        else
            rolloverOn = false;
           
        
    }
}
