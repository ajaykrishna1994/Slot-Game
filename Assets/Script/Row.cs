using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeIntervel;
    public bool isRowStop;
    public string stoppedSloat;
    // Start is called before the first frame update


    void Start()
    {
        isRowStop = true;
        GameController.handlePulled += StartRotating;
        // Do not use parentheses when subscribing to an event,
        // as it calls the method immediately instead of subscribing it.
    }
    private void StartRotating()
    {
        isRowStop = true;
        StartCoroutine(Rotate());
    }
    private IEnumerator Rotate()
    {
        isRowStop = false;
        timeIntervel = 0.0005f;
        for (int i = 0; i < 30; i++)
        {
            //upper

            if (transform.localPosition.y <= -43f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, -15.41f);
            }
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y -0.25f);
            yield return new WaitForSeconds(timeIntervel);

          
            
         }
        //to slow down
        isRowStop = false;
        float startInterval = 0.0005f; // fastest animation star
        float endInterval = 0.0099f; // slowest animation end
       

        randomValue = Random.Range(200, 240);
        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }
        for (int i = 0; i < randomValue; i++)
        {
            if (transform.localPosition.y <= -43f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, -15.41f); // Reset position
            }
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - 0.25f); // Move position

            // Calculate the current time interval based on progress
            float t = (float)i / randomValue; // Calculate the progress from 0 to 1
            timeIntervel = Mathf.Lerp(startInterval, endInterval, t); // Interpolate between startInterval and endInterval

            yield return new WaitForSeconds(timeIntervel); // Wait for the calculated time interval
        }

        float[] stopPosition = { -43.1f, -39.1f, -35.1f, -31.19f, -27.2f, -23.11f, -19f, -15.41f };
       // float mindistance = Mathf.Abs(transform.localPosition.y- stopPosition[0]);
        float closestPosition = Mathf.Abs(transform.localPosition.y - stopPosition[0]);

        IEnumerator enumerator =stopPosition.GetEnumerator();
        while (enumerator.MoveNext())
        {
            
            float distance = Mathf.Abs(transform.localPosition.y -(float)enumerator.Current);
            if(transform.localPosition.y>  (float)enumerator.Current)

            {
                Debug.Log(transform.localPosition.y);
                //  mindistance = (float)enumerator.Current;
                closestPosition = (float)enumerator.Current;
             
            }
        }
        transform.localPosition= new Vector2(transform.localPosition.x, closestPosition);
        if (closestPosition == -43.1f)
            stoppedSloat = "Diamond";
        else if (closestPosition == -39.1f)
            stoppedSloat = "Crown";
        else if (closestPosition == -35.1f)
            stoppedSloat = "Melon";
        else if (closestPosition == -31.19f)
            stoppedSloat = "Bar";
        else if (closestPosition == -27.2f)
            stoppedSloat = "Seven";
        else if (closestPosition == -23.11f)
            stoppedSloat = "Cherry";
        else if (closestPosition == -19f)
            stoppedSloat = "Lemon";
        else if (closestPosition == -15.41f)
            stoppedSloat = "Diamond";
        isRowStop=true;
    }
    private void OnDestroy()
    {
        GameController.handlePulled -= StartRotating;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
