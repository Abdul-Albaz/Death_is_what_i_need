using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : SINGLITON<GameManger>
{
    public enum gameMode { normal, reverse }
    [SerializeField]public static gameMode currentGameMode;

    private void Awake()
    {
        currentGameMode = gameMode.reverse;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
