using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SportScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public BoxCollider2D bxcldr2D;
    public LineRenderer lijnTrekker;
    public float snelheid;
    float xSnelheidBerekening;
    float ySnelheidBerekening;
    public bool magklikken;
    public bool lerpCamera;
    public bool lijnOfNiet;
    public GameObject level;
    public GameObject kamera;
    public Transform cameraPos;
    private Vector3 velocity = Vector3.zero;
    public float dampSpeed;
    public TMP_Text golfText;

    [SerializeField]
    float maximaleSnelheid;
    public float stopDrempelX;
    public float stopDrempelY;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Its sport time!");
        FindObjectOfType<AvocadoAudioManager>().Play("GolfMuziek");
        magklikken = true;
        bxcldr2D = GetComponent<BoxCollider2D>();
        bxcldr2D.enabled = false;
        rb2d = GetComponent<Rigidbody2D>();
        lijnTrekker = GetComponent<LineRenderer>();
        level.SetActive(true);
        lerpCamera = true;
        golfText.enabled = true;
        golfText.color = new Color(golfText.color.r, golfText.color.g, golfText.color.b, 255);
        StartCoroutine(TextFade(golfText));
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

    private void FixedUpdate()
    {
        if (lerpCamera)
        {
            kamera.transform.position = Vector3.SmoothDamp(kamera.transform.position, cameraPos.position, ref velocity, dampSpeed);
        }
    }

    public void Update()
    {
        Vector3 plekMuis = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(plekMuis);

        if (lijnOfNiet && magklikken)
        {
            lijnTrekker.SetPosition(0, transform.position);
            Vector3 lijnpos = -(plekMuis - transform.position);
            lijnpos.z = 0;
            lijnTrekker.SetPosition(1, transform.position + lijnpos);
        }
        else if (!lijnOfNiet)
        {
            lijnTrekker.SetPosition(0, new Vector3(0f, 0f, 0f));
            lijnTrekker.SetPosition(1, new Vector3(0f, 0f, 0f));
        }
    }

    private void OnMouseUp()
    {
        if (magklikken)
        {
            voerSnelHeidUit();
        }
        lijnOfNiet = false;
    }

    private void OnMouseDown()
    {
        lijnOfNiet = true;
    }
    void voerSnelHeidUit()
    {
        xSnelheidBerekening = berekenGolfPitSnelheidX();
        ySnelheidBerekening = berekenGolfPitSnelheidY();
        //stop de snelheid in een vector2, met een maximale snelheid geclampt
        Vector2 NIETSTOERDOEN = new Vector2(Mathf.Clamp(xSnelheidBerekening, -maximaleSnelheid, maximaleSnelheid), Mathf.Clamp(ySnelheidBerekening, -maximaleSnelheid, maximaleSnelheid));
        rb2d.AddForce(NIETSTOERDOEN, ForceMode2D.Impulse);
        magklikken = false;
        StartCoroutine(wachtTotWeerKlikken());
    }

    IEnumerator wachtTotWeerKlikken()
    {
        yield return new WaitUntil(() => Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) <= stopDrempelX &&
                                         Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) <= stopDrempelY);
        magklikken = true;
    }

    float berekenGolfPitSnelheidX() //verschil tussen muis en schaap * snelheidX als je sleept
    {
        Vector3 muisPlek = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float afstandMuisEnSchaapX = muisPlek.x - transform.position.x;

        float schaapSnelheidX = snelheid * -afstandMuisEnSchaapX;
        return schaapSnelheidX;
    }
    float berekenGolfPitSnelheidY() //verschil tussen muis en schaap * snelheidY als je sleept
    {
        Vector3 muisPlek = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float afstandMuisEnSchaapY = muisPlek.y - transform.position.y;
        float schaapSnelheidY = snelheid * -afstandMuisEnSchaapY;
        return schaapSnelheidY;
    }
}