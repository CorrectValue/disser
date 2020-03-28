using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataStorageScript : MonoBehaviour
{
    //this script is needed to store data obtained from UI in the start menu and pass it to the next scene
    public float foodValue, waterValue, pointCountValue, spawnRateValue, simTimeValue;

    public float getFoodvalue()
    {
        //returns food value
        return foodValue;
    }
    public float getWatervalue()
    {
        //returns water value 
        return waterValue;
    }
    public float getPointCountvalue()
    {
        //returns point count value
        return pointCountValue;
    }
    public float getSpawnRatevalue()
    {
        //returns spawn rate value
        return spawnRateValue;
    }
    public float getSimTimevalue()
    {
        //returns simulation time value
        return simTimeValue;
    }

    public void setFoodvalue(float val)
    {
        //sets food value
        foodValue = val;
    }
    public void setWatervalue(float val)
    {
        //sets water value 
        waterValue = val;
    }
    public void setPointCountvalue(float val)
    {
        //sets point count value
        pointCountValue = val;
    }
    public void setSpawnRatevalue(float val)
    {
        //sets spawn rate value
        spawnRateValue = val;
    }
    public void setSimTimevalue(float val)
    {
        //sets simulation time value
        simTimeValue = val;
    }
}
