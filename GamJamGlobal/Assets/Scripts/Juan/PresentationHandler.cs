using System.Collections;
using UnityEngine;

public class PresentationHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] slides;

    public static bool Shown = false;
    IEnumerator Start()
    {
        foreach (var slide in slides)
        {
            slide.SetActive(true);
            yield return new WaitForSeconds(5f);
            slide.SetActive(false);
        }

        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        Shown = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) 
        {
            gameObject.SetActive(false);
        }
    }
}
