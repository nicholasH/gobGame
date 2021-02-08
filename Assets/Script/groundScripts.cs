using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utility;


public class groundScripts : MonoBehaviour {

    private Collider2D groundColleder;

    public float health;
    private int x;
    private int y;

    //TODO: add this as a list 
    public Material dirtMaterial;
    public Material rockMaterial;
    public Material copperMaterial;
    public Material gobemMaterial;

    public utility.utility.groundTypeEnum groundType;

    public float healthModifider;
    private float totalHealth;

    private ParticleSystem particalSys;
    private SpriteRenderer SpriteRen;

    private int blockResist;



    // Use this for initialization
    void Start () {
        totalHealth = health * healthModifider;

        groundColleder = GetComponent<Collider2D>();

        particalSys = gameObject.GetComponentInChildren<ParticleSystem>();

        SpriteRen = gameObject.GetComponentInChildren<SpriteRenderer>();

        blockResist = 10; 

    }

    public void Spawn(int x, int y, int ground )
    {
        this.x = x;
        this.y = y;
        Instantiate(this, new Vector2(x, y), transform.rotation);
        this.groundType = (utility.utility.groundTypeEnum) ground;

        updateColor(groundType);

    }

    public void Digging()
    {
        if(totalHealth <= 0)
        {
            Destroy(gameObject);
        }
        else if (totalHealth > 0){

            totalHealth = totalHealth - 1;

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

    private void updateColor(utility.utility.groundTypeEnum type)
    {
        SpriteRenderer groundSpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        ParticleSystemRenderer groundParticleSystemRenderer = gameObject.GetComponentInChildren<ParticleSystemRenderer>();


        switch (type)
        {
            case utility.utility.groundTypeEnum.dirt:
                groundSpriteRenderer.material = dirtMaterial;
                groundParticleSystemRenderer.material = dirtMaterial;
                break;
            case utility.utility.groundTypeEnum.rock:
                groundSpriteRenderer.material = rockMaterial;
                groundParticleSystemRenderer.material = rockMaterial;
                break;
            case utility.utility.groundTypeEnum.copper:
                groundSpriteRenderer.material = copperMaterial;
                groundParticleSystemRenderer.material = copperMaterial;
                break;
            case utility.utility.groundTypeEnum.golbum:
                groundSpriteRenderer.material = gobemMaterial;
                groundParticleSystemRenderer.material = gobemMaterial;
                break;


        }
    }
}
