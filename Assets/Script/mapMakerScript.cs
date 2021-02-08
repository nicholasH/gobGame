using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utility;


public class mapMakerScript : MonoBehaviour
{
    public GameObject groundObject;
    public uint cameraVeiwX;
    public int cameraVeiwY;

    private GameObject mainCamera;

    public Random mapRand;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Random.InitState(64);
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
            int y = 0;
            while(y < cameraVeiwY)
            {
                genRandomBlock(x,y);





                
                y++;
            }
            x++;
        }

    }

    private void genRandomBlock(int x, int y)
    {

        int test = Random.RandomRange(1, 4);

        groundObject.GetComponent<groundScripts>().Spawn(x, -1 * y, test);
    }

}
