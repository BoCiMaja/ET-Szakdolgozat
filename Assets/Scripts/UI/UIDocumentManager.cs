using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDocumentManager : MonoBehaviour
{
    private RectTransform defaultRectTr;
    //private Note note;

    public Image image;
    public TMP_Text labelText;

    void Start()
    {
        defaultRectTr = image.GetComponent<RectTransform>();
    }

    private void OnImageChanged()
    {
        //Ha van c�mke akkor label visible, am�gy nem.
        /* if(note.hasLabel && labelText != null)
         *      labelText.text = note.Label
         */

        // Ha a new image aspect ratio-ja kisebb mint a defaultRect-� akkor t�mzsibb �gy a kisebb oldalt
        // kell hozz� igaz�tanunk
        // Am�gy meg a nagyobbat
    }
}
