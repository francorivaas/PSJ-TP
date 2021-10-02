using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Texts
{
    firstText, secondText
}

public class TextManager : MonoBehaviour
{
    [SerializeField] private RawImage vignette;
    [SerializeField] private Text firstText;
    [SerializeField] private Text secondText;

    public static TextManager instance;
    public bool canCount;

    private float timeToDisplay = 5.0f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canCount)
        {
            timeToDisplay -= Time.deltaTime;
            if (timeToDisplay <= 0) vignette.gameObject.SetActive(false);
        }
    }

    public void DisplayText(Texts texts)
    {
        switch (texts)
        {
            case Texts.firstText:
                vignette.gameObject.SetActive(true);
                firstText.gameObject.SetActive(true);
                break;
            case Texts.secondText:
                vignette.gameObject.SetActive(true);
                secondText.gameObject.SetActive(true);
                canCount = true;
                break;
            
            default:
                break;
        }
    }
}
