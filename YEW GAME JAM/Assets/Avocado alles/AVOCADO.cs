using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AVOCADO : MonoBehaviour
{
    public List<Sprite> avocadoStagesSprites = new List<Sprite>();
    public int amountOfClicks;
    public int neededClicks;
    public int avocadoIndex;
    public SpriteRenderer avocadoSprite;
    public bool avocadoEat = true;
    public TMP_Text welcomeText;
    [Space]
    float shakeTimingRemaining, shakePowder;
    public GameObject kamkamera;


    private void Start()
    {
        StartCoroutine(TextFade(welcomeText));
        FindObjectOfType<AvocadoAudioManager>().Play("AvocadoMuziek");
    }

    IEnumerator TextFade(TMP_Text text)
    {
        float duration = 4f; 
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    private void Update()
    {
        if (avocadoEat && avocadoIndex == avocadoStagesSprites.Count - 1)
        {
            StartCoroutine(sportsTime());
        }

        if (shakeTimingRemaining > 0)
        {
            shakeTimingRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePowder;
            float yAmount = Random.Range(-1f, 1f) * shakePowder;
            kamkamera.transform.position += new Vector3(xAmount, yAmount, 0f);

        }
    }

    IEnumerator sportsTime()
    {
        FindObjectOfType<AvocadoAudioManager>().StopPlaying("AvocadoMuziek");
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
                FindObjectOfType<AvocadoAudioManager>().Play("EetGeluid");
                startShake(.5f, .3f);
                avocadoSprite.sprite = avocadoStagesSprites[avocadoIndex];
                Debug.Log(avocadoSprite.sprite.name);
                amountOfClicks = 0;
            }
        }
    }

    void startShake(float length, float power)
    {
        shakeTimingRemaining = length;
        shakePowder = power;
    }

}