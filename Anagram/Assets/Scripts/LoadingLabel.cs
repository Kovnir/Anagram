using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.UI;

public class LoadingLabel : MonoBehaviour {

    private Text text;

    [UsedImplicitly]
	void Awake ()
    {
        text = GetComponent<Text>();
	    StartCoroutine(UpdateText());
    }
	
	private IEnumerator UpdateText()
	{
	    int starsCount = 0;
	    while (true)
	    {
	        yield return new WaitForSeconds(0.25f);
	        starsCount ++;
	        if (starsCount > 3)
	        {
	            starsCount = 0;
	        }
	        text.text = "LOADING";
	        for (int i = 0; i < starsCount; i++)
	        {
                text.text += ".";
            }
        }
    }
}
