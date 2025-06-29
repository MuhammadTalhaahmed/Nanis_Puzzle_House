using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class KeyCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI warningText; // Assign in Inspector

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            StartCoroutine(ShowWarning());
        }
        if(collision.gameObject.name == "Cabinet2-D1")
        {
            OpenDrawer(collision.gameObject);
        }
    }

    IEnumerator ShowWarning()
    {
        if (warningText == null) yield break;

        warningText.text = "This key cannot open the door";
        warningText.gameObject.SetActive(true);

        // Show for 1 second
        yield return new WaitForSeconds(2f);

        warningText.text = ""; // Clear the message but keep text active

        // After 5 total seconds, hide the text object
        yield return new WaitForSeconds(2f);
        warningText.gameObject.SetActive(false);
    }
    void OpenDrawer(GameObject drawer)
    {
        Vector3 currentPos = drawer.transform.localPosition;

        if (Mathf.Approximately(currentPos.z, 0f))
        {
            // Move it outward on the Z axis
            drawer.transform.localPosition = new Vector3(currentPos.x, currentPos.y, 0.38f);
        }
    }
}

