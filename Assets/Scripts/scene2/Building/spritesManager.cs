using UnityEngine;

public class spritesManager : MonoBehaviour
{    
    [SerializeField] Sprites spriteslvl1;
    [SerializeField] Sprites spriteslvl2;
    [SerializeField] Sprites spriteslvl3;
    [SerializeField] Sprites spriteslvl4;
    [SerializeField] Sprites spriteslvl5;

    SpriteRenderer spriteCurrent;

    [System.NonSerialized] public Sprites spritesCurrent;

    void Start()
    {
        spritesCurrent = spriteslvl1;
        spriteCurrent = gameObject.GetComponent<SpriteRenderer>();
    }

    public void changeSprite(int lvl)
    {
        switch (lvl)
        {
            case 1: spritesCurrent = spriteslvl1; break;
            case 2: spritesCurrent = spriteslvl2; break;
            case 3: spritesCurrent = spriteslvl3; break;
            case 4: spritesCurrent = spriteslvl4; break;
            case 5: spritesCurrent = spriteslvl5; break;
            default: spritesCurrent = spriteslvl1; break;
        }
    }

    public void changeSpriteColor(Color color)
    {
        //if (color == Color.white)
        //    spriteCurrent = sprites.spriteDef; else
        if (color == Color.blue)
            spriteCurrent.sprite = spritesCurrent.spriteBlue;
        else if (color == Color.green)
            spriteCurrent.sprite = spritesCurrent.spriteGreen;
        else if (color.g == 0f && color.b == 1f)
            spriteCurrent.sprite = spritesCurrent.spritePurple;
    }
}
