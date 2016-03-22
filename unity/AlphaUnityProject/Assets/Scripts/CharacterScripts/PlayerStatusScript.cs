using UnityEngine;
using System.Collections;

public class PlayerStatusScript  {
    public bool canChannel;
    public bool isBonded; 

    public PlayerStatusScript()
    {
        this.canChannel = false;
        this.isBonded = false; 
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
