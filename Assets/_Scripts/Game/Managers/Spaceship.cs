using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : ISingleton<Spaceship> 
{
    protected Spaceship(){}

    public float food;
    public float energy;


}
