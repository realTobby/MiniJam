using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Collider[] childColliders;

    public GameObject pickedUPRef;

    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 15.0f;

    private AudioSource myAudio;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(pickedUPRef != null)
        {
            pickedUPRef.GetComponent<Moveable>().isPickedUp = true;

            pickedUPRef.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);

            
        }

    }

    public void DestroyColliders()
    {
        
    }


    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed * Time.deltaTime, vertical * runSpeed * Time.deltaTime);
    }

    public void ReleaseOre()
    {
        Destroy(pickedUPRef);
        pickedUPRef = null;
        myAudio.clip = Resources.Load("Sounds/finish") as AudioClip;
        myAudio.Play();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "ore")
        {
            if (pickedUPRef == null)
            {
                pickedUPRef = col.gameObject;
                Destroy(pickedUPRef.GetComponent<CircleCollider2D>());
                myAudio.clip = Resources.Load("Sounds/collect") as AudioClip;
                myAudio.Play();
            }
        }

        if(col.gameObject.tag.Contains("Crate"))
        {
            if(pickedUPRef != null)
            {
                OreType holdingOreType = pickedUPRef.GetComponent<Moveable>().oreType;

                if (holdingOreType == OreType.Coal && col.gameObject.tag == "coalCrate")
                {
                    ReleaseOre();
                }

                if (holdingOreType == OreType.Gold && col.gameObject.tag == "goldCrate")
                {
                    ReleaseOre();
                }

                if (holdingOreType == OreType.Diamond && col.gameObject.tag == "diamondCrate")
                {
                    ReleaseOre();
                }

                if (holdingOreType == OreType.Ruby && col.gameObject.tag == "rubyCrate")
                {
                    ReleaseOre();
                }

            }
        }
    }

}
