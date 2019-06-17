// Press space to change between added GUI skins.

using UnityEngine;
using System.Collections;

public class Questionnaire1 : MonoBehaviour
{
    private GUIStyle guiStyle = new GUIStyle();

    private float hSliderValue = 0.0F;
    private float vSliderValue = 0.0F;
    private float hSValue = 0.0F;
    private float vSValue = 0.0F;
    private int cont = 0;

    void Update()
    {

    }

    void OnGUI()
    {
        guiStyle.fontSize = 20;
        guiStyle.alignment = TextAnchor.UpperCenter;

        GUI.color = Color.black;
        GUI.Label(new Rect(Screen.width / 2 - 100, 20, 100, 20), "Herzlich Willkommen zum Experiment!", guiStyle);
        GUI.Label(new Rect(Screen.width / 2 - 100, 100, 100, 20), "In diesem Experiment interessieren wir uns für die menschliche Reaktionsfähigkeit.", guiStyle);
        GUI.Label(new Rect(Screen.width / 2 - 100, 160, 100, 20), "Ablauf : ", guiStyle);
        GUI.Label(new Rect(Screen.width / 2 - 100, 190, 100, 20), " 1. Fragebogen1    (  2 Minuten)", guiStyle);
        GUI.Label(new Rect(Screen.width / 2 - 100, 220, 100, 20), "  2. Reaktionstest   ( 10 Minuten)", guiStyle);
        GUI.Label(new Rect(Screen.width / 2 - 100, 250, 100, 20), " 3. Fragebogen 2   (  2 Minuten)", guiStyle);




        // hSliderValue = GUI.HorizontalSlider(new Rect(10, 150, 100, 30), hSliderValue, 0.0F, 10.0F);
        //vSliderValue = GUI.VerticalSlider(new Rect(10, 170, 100, 30), vSliderValue, 10.0F, 0.0F);
        //hSValue = GUI.HorizontalScrollbar(new Rect(10, 210, 100, 30), hSValue, 1.0F, 0.0F, 10.0F);
        //vSValue = GUI.VerticalScrollbar(new Rect(10, 230, 100, 30), vSValue, 1.0F, 10.0F, 0.0F);
    }
}