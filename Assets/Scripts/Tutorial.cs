using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{
    public string[] tutorialText;
    public TMP_Text dialogBox;
    public float charDelay;

    public int tutorialIndex;
    public char[] button;
    // Start is called before the first frame update
    void Start()
    {
        //ShowDialog(tutorialText[0]);
        StartCoroutine(ShowDialogText(tutorialText[tutorialIndex],charDelay,tutorialIndex));
        //tutorialIndex++;
        
        // StartCoroutine(ShowDialogText(tutorialText[1], charDelay));
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(button[tutorialIndex].ToString()))
        //    {
        //    switch (tutorialIndex)
        //{
        //    case 0:
        //        dialogBox.text = "";

        //            tutorialIndex++;
        //             StartCoroutine(ShowDialogText(tutorialText[tutorialIndex], charDelay, tutorialIndex)); 
        //        break;
        //    case 1:
        //        dialogBox.text = "";

        //            tutorialIndex++;


        //        StartCoroutine(ShowDialogText(tutorialText[tutorialIndex], charDelay, tutorialIndex)); 
        //        break;
        //    case 2:
        //        dialogBox.text = "";

        //            tutorialIndex++;


        //        StartCoroutine(ShowDialogText(tutorialText[tutorialIndex], charDelay, tutorialIndex)); 
        //        break;
        //    case 3:
        //        dialogBox.text = "";

        //            tutorialIndex++;


        //    StartCoroutine(ShowDialogText(tutorialText[tutorialIndex], charDelay, tutorialIndex));
        //        break;
        //    default:
        //        break;
        //}
        //    }
        
        if (Input.GetKeyDown(button[tutorialIndex].ToString()))
        {
            dialogBox.text = "";

            if (tutorialIndex <= tutorialText.Length  && tutorialIndex <= button.Length )
            {
                tutorialIndex = Mathf.Clamp(tutorialIndex, 0, tutorialText.Length - 1);
                tutorialIndex++;
                tutorialIndex = Mathf.Clamp(tutorialIndex, 0, tutorialText.Length - 1);
                StartCoroutine(ShowDialogText(tutorialText[tutorialIndex], charDelay, tutorialIndex));
            }

            Debug.Log("tutorialIndex Update" + tutorialIndex);
            Debug.Log("tutorialText.Length " + tutorialText.Length);




        }
    }

    public void ShowDialog(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {

            dialogBox.text = tutorialText[i];
        }
    }

    IEnumerator ShowDialogText(string text,float delay,int tutorialindex)
    {
        char[] letter;
        for (int i = 0; i < text.Length; i++)
        {

            Debug.Log("tutorialIndex Update" + tutorialindex);
            Debug.Log("tutorialText.Length " + tutorialText.Length);


            letter = tutorialText[tutorialindex].ToCharArray();
            dialogBox.text += letter[i].ToString();
            yield return new WaitForSeconds(delay);
            
        }
        

    }
}
