using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TMP_InputField autoFocusInputField;
    public GameObject scoreInputContainer;
    public Button continueButton;
    public TMP_Text continueText;

    private void Start()
    {
        // Cursor ins Input Field setzen, wenn Container active ist:
        if (scoreInputContainer.activeSelf)
        {
            autoFocusInputField.Select();
            autoFocusInputField.ActivateInputField();
        }
    }

    public void CheckInput()
    {
        if (autoFocusInputField.text.Length > 0)
        {
            continueButton.interactable = true;
            continueText.color = new Color(1, 1, 1, 1);
        }
        else
        {
            continueButton.interactable = false;
            continueText.color = new Color(0.196f, 0.196f, 0.196f, 1);
        }
    }
}
