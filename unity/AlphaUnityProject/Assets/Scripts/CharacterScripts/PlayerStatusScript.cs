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

    void setBondStatus(bool b)
    {
        this.isBonded = b; 
    }

    bool getBondStatus(bool b)
    {
        return this.isBonded;
    }

    void setChannelStatus(bool b)
    {
        this.canChannel = b;
    }

    bool getChannelStatus(bool b)
    {
        return this.isBonded;
    }
}
