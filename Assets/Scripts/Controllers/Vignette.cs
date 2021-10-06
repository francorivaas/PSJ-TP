using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vignette : MonoBehaviour
{
    [SerializeField] private RawImage vignette;
    [SerializeField] private Text text;

    private float timeToStopRendering = 8.0f;
    private float timeToDisplay = 3.0f;
    private float currentTimeToDisplay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        vignette.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        print(currentTimeToDisplay);

        currentTimeToDisplay += Time.deltaTime;
        if (currentTimeToDisplay >= timeToDisplay)
        {
            vignette.gameObject.SetActive(true);
            TextManager.instance.DisplayText(Texts.secondText);

            if (currentTimeToDisplay >= timeToStopRendering)
            {
                vignette.gameObject.SetActive(false);
                gameObject.SetActive(false);
                Destroy(text);
            }
        }

    }
}
