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
        float startInterval = 0.0005f; // Initial time interval
        float endInterval = 0.0099f; // Final time interval
        int totalSteps = 10; // Total number of steps
        float stepIncrement = (endInterval - startInterval) / (totalSteps - 1); // Calculate the increment

        List<float> timeIntervals = new List<float>();

        // Generate the time intervals
        for (int i = 0; i < totalSteps; i++)
        {
            timeIntervals.Add(startInterval + i * stepIncrement);
        }

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
                transform.localPosition = new Vector2(transform.localPosition.x, -15.41f);

            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - 0.25f);

            // Use the appropriate time interval from the list
            float t = (float)i / randomValue;
            int index = Mathf.Min(Mathf.FloorToInt(t * (totalSteps - 1)), totalSteps - 1);
            timeIntervel = timeIntervals[index];

            yield return new WaitForSeconds(timeIntervel);
        }
        if (transform.localPosition.y == 3.5f)
            stoppedSloat = "Diamond";
        else if (transform.localPosition.y == -2.75)
            stoppedSloat = "Crown";
        else if (transform.localPosition.y == -2)
            stoppedSloat = "Melon";
        else if (transform.localPosition.y == -1.25)
            stoppedSloat = "Bar";
        else if (transform.localPosition.y == -0.5f)
            stoppedSloat = "Seven";
        else if (transform.localPosition.y == 0.25)
            stoppedSloat = "Cherry";
        else if (transform.localPosition.y == 1)
            stoppedSloat = "Lemon";
        else if (transform.localPosition.y == 1.75f)
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
