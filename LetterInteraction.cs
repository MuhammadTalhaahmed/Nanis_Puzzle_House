using UnityEngine;
using UnityEngine.UI;
public class LetterInteraction: MonoBehaviour
{
    public GameObject letterPanel; // UI Panel reference

    void OnMouseDown()
    {
        Debug.Log("Letter Clicked! Displaying UI...");
        letterPanel.SetActive(true); // Show the letter UI panel
    }

    public void CloseLetter()
    {
        letterPanel.SetActive(false); // Hide the UI panel
    }
}
