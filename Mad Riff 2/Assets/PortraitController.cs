using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitController : MonoBehaviour
{
    public List<Sprite> portraits = new List<Sprite>();
    public List<AudioClip> clips = new List<AudioClip>();
    public AudioSource audio;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show() 
    {
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void Hide() 
    {
        gameObject.GetComponent<Image>().enabled = false;
    }

    public void SetPortrait(string name)
    {
        foreach(var portrait in portraits)
        {
            if (portrait.name == name)
            {
                gameObject.GetComponent<Image>().sprite = portrait;
                audio.PlayOneShot(clips[portraits.IndexOf(portrait)]);
            }
        }
    }
}
