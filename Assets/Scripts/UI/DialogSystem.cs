using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public TextAsset dialogDataFile;
    public TMP_Text dialogText;
    public int dialogIndex;
    private string[] dialogRows;


    [SerializeField] private float textSpeed = 0.05f; // 字符显示间隔，默认为0.05秒
    [SerializeField]private float fadeSpeed = 2.0f;
    void Start()
    {
        ReadText(dialogDataFile);
        ShowDiaLogRow();
    }
    public void UpdateText(string _text)
    {
        dialogText.text = _text;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnClickNext();
        }
    }
    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
    }
    public void ShowDiaLogRow()
    {
        for (int i = 0; i < dialogRows.Length; i++)
        {
            string[] cells = dialogRows[i].Split(',');

            if (cells.Length < 6)
                continue; // Ensure we have enough data

            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
            {
                StartCoroutine(ShowText(cells[4], textSpeed)); 
                break;
            }
            else if (cells[0] == "End" && int.Parse(cells[1]) == dialogIndex)
            {
                dialogText.text = "";
                Debug.Log("The End");
            }
        }
    }

    private void HandleStandardDialog(string[] cells)
    {
        UpdateText(cells[4]); 
        dialogIndex = int.Parse(cells[5]);
    }

    public void OnClickNext()
    {
        StopAllCoroutines(); 
        ShowDiaLogRow();
    }
    private IEnumerator ShowText(string text, float delay)
    {
        dialogText.text = "";
        foreach (char c in text)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(delay);
        }
        StartCoroutine(FadeText(fadeSpeed)); 
    }

    private IEnumerator FadeText(float duration)
    {
        Color originalColor = dialogText.color;
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            dialogText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - t);
            yield return null;
        }
        dialogText.color = originalColor; 
        dialogIndex++; 
        if (dialogIndex < dialogRows.Length)
        {
            ShowDiaLogRow(); 
        }
    }


}
