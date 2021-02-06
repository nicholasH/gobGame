using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundScripts : MonoBehaviour {

    private Collider2D groundColleder;

    public float health;
    private int x;
    private int y;

    public string groundType;

    public float healthModifider;
    private float totalHealth;

    private ParticleSystem particalSys;
    private SpriteRenderer SpriteRen;

    private int blockResist;

    private

	// Use this for initialization
	void Start () {
        totalHealth = health * healthModifider;

        groundColleder = GetComponent<Collider2D>();

        particalSys = gameObject.GetComponentInChildren<ParticleSystem>();

        SpriteRen = gameObject.GetComponentInChildren<SpriteRenderer>();

        blockResist = 10; 

    }

    public void Spawn(int x, int y)
    {
        this.x = x;
        this.y = y;
        Instantiate(this, new Vector2(x, y), transform.rotation);
    }

    public void Digging()
    {
        if(totalHealth <= 0)
        {
            Destroy(gameObject);
            blockResist = 10;
        }
        else if (totalHealth > 0){
            if(blockResist <= 0)
            {
                totalHealth = totalHealth - 1;
            }
            else
            {
                blockResist--;
            }

            if (!particalSys.isPlaying)
            {
                print("totalHealth: " + totalHealth);
                SpriteRen.color = new Color(1f, 1f, 1f, totalHealth/100); 

                particalSys.Play();
            }
                


        }

    }
    void DestroySelf(){
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        

    }
}
