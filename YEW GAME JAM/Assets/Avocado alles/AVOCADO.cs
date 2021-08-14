using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVOCADO : MonoBehaviour
{
    public List<Sprite> avocadoStagesSprites = new List<Sprite>();
    public int amountOfClicks;
    public int neededClicks;
    public int avocadoIndex;
    public SpriteRenderer avocadoSprite;
    public bool avocadoEat = true;

    private void Update()
    {
        if (avocadoEat && avocadoIndex == avocadoStagesSprites.Count - 1)
        {
            StartCoroutine(sportsTime());
        }
    }

    IEnumerator sportsTime()
    {
        yield return new WaitForSeconds(.2f);
        gameObject.GetComponent<SportScript>().enabled = true;
        avocadoEat = false;
    }

    private void OnMouseDown()
    {
        if (avocadoEat)
        {
            amountOfClicks++;
            avocadoCheck();
        }
    }
    void avocadoCheck()
    {
        if (avocadoEat)
        {
            avocadoSprite = GetComponent<SpriteRenderer>();
            if (amountOfClicks == neededClicks)
            {
                avocadoIndex++;
                avocadoSprite.sprite = avocadoStagesSprites[avocadoIndex];
                Debug.Log(avocadoSprite.sprite.name);
                amountOfClicks = 0;
            }
        }
    }
}