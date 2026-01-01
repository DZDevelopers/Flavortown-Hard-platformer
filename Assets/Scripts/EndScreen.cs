using UnityEngine;
using TMPro;
using System.Collections;

public class EndScreen : MonoBehaviour
{
    [Header("Typewriter Text")]
    public TMP_Text uiText;
    public float typeDelay = 0.05f;

    [Header("Credits")]
    public TMP_Text creditText;
    public float scrollSpeed = 50f;

    [Header("Thank You Text")]
    public TMP_Text thankYouText;

    [Header("Buttons")]
    public GameObject B1;
    public GameObject B2;

    private RectTransform creditRect;

    private void Start()
    {
        GameTimer.Instance.StopTimer();
        TimeDisplay.Instance.StopTimer();
        // Hide buttons and credits at start
        B1.SetActive(false);
        B2.SetActive(false);
        creditText.gameObject.SetActive(false);
        thankYouText.gameObject.SetActive(false);

        creditRect = creditText.GetComponent<RectTransform>();
        float timeTaken = GameTimer.Instance.elapsedTime;
    int minutes = Mathf.FloorToInt(timeTaken / 60f);
    int seconds = Mathf.FloorToInt(timeTaken % 60f);
        // Start the full sequence
        string message = "You Won!\nThanks for playing my mediocre game. If you enjoyed it, I really appreciate it. If not, you’re probably just bad.\n" + $"Time Taken: {minutes:D2}:{seconds:D2}";
        StartCoroutine(ShowTextThenCredits(message));
    }

    IEnumerator ShowTextThenCredits(string message)
    {
        // --- TYPEWRITER TEXT ---
        uiText.text = "";
        foreach (char letter in message)
        {
            uiText.text += letter;
            yield return new WaitForSeconds(typeDelay);
        }

        // Short pause before credits
        yield return new WaitForSeconds(1.5f);
        uiText.text = "";
        // --- CREDITS ---
        creditText.gameObject.SetActive(true);

        // Start off-screen
        creditRect.anchoredPosition = new Vector2(0, -Screen.height-700);

        // Fill credits (joke version)
        creditText.text = 
"Credits\n\n" +
"Programming: Aymen\n" +
"Lead Programmer: Aymen\n" +
"Gameplay Programmer: Aymen\n" +
"AI Programmer: Aymen\n" +
"Art: Aymen\n" +
"Character Artist: Aymen\n" +
"Environment Artist: Aymen\n" +
"Pixel Artist: Aymen\n" +
"Animation: Aymen\n" +
"Design: Aymen\n" +
"Level Designer: Aymen\n" +
"UX Designer: Aymen\n" +
"Sound & Music: Aymen\n" +
"Composer: Aymen\n" +
"Sound Effects: Aymen\n" +
"QA Testing: Aymen\n" +
"Lead QA: Aymen\n" +
"Bug Finder: Aymen\n" +
"Coffee & Snacks: Aymen\n" +
"Office Pet: Aymen\n" +
"World Savior: Aymen\n" +
"Special Thanks: Aymen\n" +
"Snack Taster: Aymen\n" +
"Stunt Double: Aymen\n" +
"Backup Developer: Aymen\n" +
"Pixel Pusher: Aymen\n" +
"Chief Meme Officer: Aymen\n" +
"Janitor: Aymen\n" +
"Intern: Aymen\n" +
"Everything Else: Aymen\n\n\n" +
"The End";


        while (creditRect.anchoredPosition.y < Screen.height + creditRect.rect.height+480)
        {
            creditRect.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            yield return null; // wait for next frame
        }
        // --- THANK YOU ---
        thankYouText.gameObject.SetActive(true);
        thankYouText.text = "Thank you!";

        // Show buttons
        B1.SetActive(true);
        B2.SetActive(true);
    }
}
