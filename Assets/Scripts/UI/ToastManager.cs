using TMPro;

public class ToastManager : MonoBehaviourUI
{
	public TextMeshProUGUI text0;
	public TextMeshProUGUI text1;
	public float timeToDissapear;

	public static ToastManager Instance;

	// Start is called before the first frame update

	private void Start()
	{
		Instance = this;
	}

	public void SetText(string newText, float timeToGo)
	{

		print(newText);
		if (timeToGo == 0)
			timeToGo = timeToDissapear;

		text0.text = newText;
		text1.text = newText;
		Show(() => Hide(), timeToGo);
	}
}
