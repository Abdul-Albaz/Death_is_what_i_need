using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINGLITON<T> : MonoBehaviour where T: MonoBehaviour
{
    public bool DestroyOnLoad;
    public static T instance;

    private void Awake()
    {
        Registersingilton();
    }

    protected void Registersingilton()
    {
        Debug.Log("register instance");
        if (instance == null)
        {
            instance = this as T;

            if (DestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            
        }
        else
        {
            Destroy(gameObject);
        }


    }
}
