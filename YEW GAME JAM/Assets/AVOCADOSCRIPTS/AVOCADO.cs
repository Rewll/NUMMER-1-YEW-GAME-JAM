using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVOCADO : MonoBehaviour
{
    public List<Sprite> avocadoStagesSprites = new List<Sprite>();
    public int amountOfAvocadoClicks;
    public int avocadoIndex;
    public SpriteRenderer avocadoSprite;

    private void OnMouseDown()
    {
        amountOfAvocadoClicks++;
        avocadoCheck();
    }
    void avocadoCheck()
    {
        avocadoSprite = GetComponent<SpriteRenderer>();
        if (amountOfAvocadoClicks == 5)
        {
            avocadoIndex++;
            avocadoSprite.sprite = avocadoStagesSprites[avocadoIndex];
            Debug.Log(avocadoSprite.sprite.name);
            amountOfAvocadoClicks = 0;
        }
    }
}
