using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NamesPage : MonoBehaviour
{
    [SerializeField]
    private List<NamePanel> namePanels;

    public void Init(List<NamesFinder.NameSernamePare> pages)
    {
        Disable();
        for (int i = 0; i < pages.Count; i++)
        {
            namePanels[i].gameObject.SetActive(true);
            namePanels[i].Init(pages[i]);
            namePanels[i].OnNameClick += OnNameSelected;
        }
    }

    private void OnNameSelected(string name)
    {
        Controller.Instance.OnNameSelected(name);
    }

    private void Disable()
    {
        foreach (var x in namePanels)
        {
            x.gameObject.SetActive(false);
            x.OnNameClick -= OnNameSelected;
        }
    }
}
