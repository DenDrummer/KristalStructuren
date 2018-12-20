using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class AllElements{

    static List<Element> MendeljevElementen;

    static AllElements() {
        MendeljevElementen = new List<Element>();
        setElementen();
    }

    static void setElementenHardCoded() {

    }
    static void setElementen()
    {
        string hardCoded="";
        using (var reader = new StreamReader(@".\Assets\Resources\data.csv"))
        {
            //Eerste lijn met benamingen skippen
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                hardCoded=hardCoded+'\n'+"MendeljevElementen.Add(new Element(" +'\"' +values[0] + '\"' + ',' + '\"' + values[1] + '\"' + ',' + '\"' + values[2] + '\"' + ',' + '\"' + values[3] + '\"' + ',' + '\"' 
                    + values[4] + '\"' + ',' + '\"' + values[9] + "\",\"" +values[8]+ "\""+",\"" + values[7] + "\"));";
                Element element = new Element(values[0],values[1],values[2],values[3],values[4],values[9],values[7]);
                MendeljevElementen.Add(element);
            }
        }
        Debug.Log(hardCoded);
    }

    public static Element getElement(string element) {
        foreach (Element e in MendeljevElementen) {
            if (element.Equals(e.abbreviation)){
                return e;
            }
        }       
        return null;
    }


}
