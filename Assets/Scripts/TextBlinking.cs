using System.Collections;
using TMPro;
using UnityEngine;

public class TextBlinking : MonoBehaviour
{
    private bool isActive;
    private void Awake()
    {
        isActive = true;
    }
    private void Start()
    {
        StartCoroutine(Blinking());
    }

    private void Update()
    {
    }

    private IEnumerator Blinking()
    {
        while (enabled)
        {
            if (!isActive)
            {
                GetComponent<TextMeshProUGUI>().enabled = false;
                isActive = true;
            }
            else
            {
                GetComponent<TextMeshProUGUI>().enabled = true;
                isActive = false;
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }
}
