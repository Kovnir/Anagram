using UnityEngine;
using System.Collections;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Controller : Singleton<Controller>
{
    public static Controller Instance
    {
        get
        {
            return ((Controller)mInstance);
        }
        set
        {
            mInstance = value;
        }
    }

    [SerializeField] private Fader startPanel;
    [SerializeField] private NamesFinder namesFinder;

    [UsedImplicitly]
    void Start()
    {
        startPanel.FadeIn();
    }


    public void OnUserDataEntered(string username, bool male, bool female)
    {
        Debug.Log("OnUserDataEntered");
        startPanel.FadeOut();
        namesFinder.Find(username, male, female);
    }

	
	// Update is called once per frame
	void Update () {
	
	}


}
