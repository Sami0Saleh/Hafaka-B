using System.Collections;
using UnityEngine;

public static class TextMeshProExtentions
{
    public static IEnumerator TypeText(this TMPro.TMP_Text tmp, string fullText, float typingSpeed, float displayTime)
    {
        foreach (char c in fullText)
        {
            tmp.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(displayTime);
    }
}
