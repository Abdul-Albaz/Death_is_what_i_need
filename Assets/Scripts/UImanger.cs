using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanger : SINGLITON<UImanger>
{
    public Image infoIndicator;
    public Image modeIndicator;
    public Image[] healthIndicator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void changeHealthbar()
    //{

    //}


    public void healthInc(int index)
    {
        Debug.LogWarning("healthInc");
        healthIndicator[index].gameObject.SetActive(true);
    }

    public void healthDec(int index)
    {

        healthIndicator[index].gameObject.SetActive(false);
    }


    public void changeMode(){

        modeIndicator.gameObject.SetActive(true);
    }
}
