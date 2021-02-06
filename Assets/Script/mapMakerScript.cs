using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mapMakerScript : MonoBehaviour
{
    public GameObject groundObject;
    public uint cameraVeiwX;
    public uint cameraVeiwY;

    private GameObject[,,,] groundArray4D;

    // Start is called before the first frame update
    void Start()
    {
        layBlock();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void layBlock()
    {
        int x = 0;
        while(x < cameraVeiwX)
        {
            groundObject.GetComponent<groundScripts>().Spawn(x, -1);
            x++;
        }

    }
}
