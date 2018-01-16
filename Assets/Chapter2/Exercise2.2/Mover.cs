using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author: Miao Lu
 * @version: 1.0
 * @title: nature of code, chapter 2, exercise 2.2
 * @descrip: The given exercise is about replacing a Processing language method with another method, which
 *           is not proper to be complete in C#. So the task of this exercise in C# should be implementation.
 */

public class Mover : MonoBehaviour {

    //Declearion of class attributes
    protected Vector3 position;
    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected float mass;

    protected Vector3 wind;
    protected Vector3 gravity;

    //Constructor, accpets mass and position scale
    public Mover(float x, float y, float m)
    {
        mass = m;
        position = new Vector3(x, y);
        velocity = new Vector3(0, 0);
        acceleration = new Vector3(0, 0);
    }

    // Apply force into sphere
    void ApplyForce(Vector3 force)
    {
        Vector3 f = force / mass;
        acceleration += f;
    }

    void Refresh()
    {
        velocity += acceleration;
        position += velocity;
        acceleration *= 0;
    }

    void Display()
    {
        Debug.Log("position:" + position.ToString());
    }
}
