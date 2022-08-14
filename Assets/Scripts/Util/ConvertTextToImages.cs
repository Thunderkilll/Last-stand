using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class ConvertTextToImages : MonoBehaviour
{

    public string text;
    public GameObject canvasUI;
    public GameObject[] lettres;
    private string str;
    

    void Start()
    {
        str = text;
        string[] spearator = {"." };
       
        string[] strlist = str.Split(spearator,
            StringSplitOptions.RemoveEmptyEntries);
        foreach (String s in strlist)
        {
            CreateLettre(s,"a", 0);
            CreateLettre(s,"b", 1);
            CreateLettre(s,"c", 2);
            CreateLettre(s,"d", 3);
            CreateLettre(s,"e", 4);
            CreateLettre(s,"f", 5);
            CreateLettre(s,"g", 6);
            CreateLettre(s,"h", 7);
            CreateLettre(s,"i", 8);
            CreateLettre(s,"j", 9);
            CreateLettre(s,"k", 10);
            CreateLettre(s,"l", 11);
            CreateLettre(s,"m", 12);
            CreateLettre(s,"n", 13);
            CreateLettre(s,"o", 14);
            CreateLettre(s, "p", 15);
            CreateLettre(s, "q", 16);
            CreateLettre(s, "r", 17);
            CreateLettre(s, "s", 18);
            CreateLettre(s, "t", 19); 
            CreateLettre(s, "u", 20);
            CreateLettre(s, "v", 21);
            CreateLettre(s, "w", 22);
            CreateLettre(s, "x", 23);
            CreateLettre(s, "y", 24);
            CreateLettre(s, "z", 25);
            CreateLettre(s, "space", 26);
            CreateLettre(s, ",", 27);  
            CreateLettre(s, "!", 28);

        }
    }

    private void CreateLettre(string s,string p, int i)
    {
        if (s.Equals(p))
        {
            GameObject createImage = Instantiate(lettres[i]);
            createImage.transform.SetParent(canvasUI.transform, false);
        }
    }
}
