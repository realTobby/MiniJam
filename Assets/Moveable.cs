using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OreType
{
    Gold,
    Coal,
    Diamond,
    Ruby
}


public class Moveable : MonoBehaviour
{
    public OreType oreType;

    public bool isPickedUp = false;

    public float speed = 5f;

    public Vector2 target = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        int oreIndex = Random.Range(0, 4);

        Sprite mySprite = null;

        switch(oreIndex)
        {
            case 0:
                mySprite = Resources.Load<Sprite>("Sprites/gold");
                oreType = OreType.Gold;
                break;
            case 1:
                mySprite = Resources.Load<Sprite>("Sprites/coal");
                oreType = OreType.Coal;
                break;
            case 2:
                mySprite = Resources.Load<Sprite>("Sprites/diamond");
                oreType = OreType.Diamond;
                break;
            case 3:
                mySprite = Resources.Load<Sprite>("Sprites/ruby");
                oreType = OreType.Ruby;
                break;
        }

        this.GetComponent<SpriteRenderer>().sprite = mySprite;


        target = new Vector2(4.79f, -0.49f);

    }

    // Update is called once per frame
    void Update()
    {


        if(isPickedUp == false)
        {
            if((Vector2)this.transform.position != target)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(this.transform.position, target, step);
            }
            
        }
        



    }
}
