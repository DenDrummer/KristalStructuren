﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AllElements{

    List<Element> MendeljevElementen;

    public AllElements() {
        MendeljevElementen = new List<Element>();
        setElementen();
    }

    void setElementen()
    {
        using (var reader = new StreamReader(@"D:\School\VR\VRKristalStructuur\Assets\MyAssets\Data\data.csv"))
        {
            //Eerste lijn met benamingen skippen
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Element element = new Element(values[0],values[1],values[2],values[3],values[4],values[9]);
                MendeljevElementen.Add(element);
            }
        }
    }

    public Element getElement(string element) {
        foreach (Element e in MendeljevElementen) {
            if (element.Equals(e.abbreviation)){
                return e;
            }
        }       
        return null;
    }


}
