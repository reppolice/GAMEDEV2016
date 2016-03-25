using UnityEngine;
using System.Collections;

public class PlayerStatusScript  {
    public bool canChannel;
    public bool isBonded;
    public float speed; 
    public int enemiesAttached; 

    public PlayerStatusScript(float speed)
    {
        this.speed = speed;
        this.enemiesAttached = 0; 
        this.canChannel = false;
        this.isBonded = false; 
    }

    public void setSpeed(float speed)
    {
        this.speed = speed; 
    }

    public float getSpeed()
    {
        return this.speed;
    }

    public void setBondStatus(bool b)
    {
        this.isBonded = b; 
    }

    public bool getBondStatus()
    {
        return this.isBonded;
    }

    public void setChannelStatus(bool b)
    {
        this.canChannel = b;
    }

    public bool getChannelStatus()
    {
        return this.isBonded;
    }
}
