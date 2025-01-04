using System.Collections;
using TMPro;
using UnityEngine;

public class TextBlinking : MonoBehaviour
{
    private float timer;
    private void Awake()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0 && timer < 0.5f)
        {
            GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else if (timer >= 0.5f && timer < 1f)
        {
            GetComponent<TextMeshProUGUI>().enabled = false;
        }
        else
        {
            timer = 0f;
        }
    }
}
