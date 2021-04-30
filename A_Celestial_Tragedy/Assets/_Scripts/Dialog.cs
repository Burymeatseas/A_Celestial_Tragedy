using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    AudioSource alertSFX;
    public GameObject continueButton;
    public int audioIndex;
    public AudioClip clip;
    [SerializeField] Animator connorAnimator;
    [SerializeField] Animator char2Anim;

    void Start()
    {
        alertSFX = GetComponent<AudioSource>();
        StartCoroutine(Type());
    }


    void Update(){

        if(textDisplay.text == sentences[index]){
             continueButton.SetActive(true);
        }
        if (index == audioIndex)
        {
            if (alertSFX != null )
            {
                if (!alertSFX.isPlaying)
                {
                    alertSFX.clip = clip;
                    alertSFX.Play();

                }
                
            }
        }
        connorAnimator.SetInteger("seqNumber", index);
    }

    IEnumerator Type()
    {

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){

        continueButton.SetActive(false);

        if(index < sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

}