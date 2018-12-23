
using System.Collections.Generic;
using System.IO;

public class AllElements
{

    List<Element> MendeljevElementen;

    public AllElements()
    {
        MendeljevElementen = new List<Element>();
        SetElementen();
    }

    void SetElementen()
    {
        using (var reader = new StreamReader(@"Assets\MyAssets Jorne\Data\data.csv"))
        {
            //Eerste lijn met benamingen skippen
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Element element = new Element(values[0], values[1], values[2], values[3], values[4], values[9]);
                MendeljevElementen.Add(element);
            }
        }
    }

    public Element GetElement(string element)
    {
        // doet de volgende lijn niet exact hetzelfde maar performanter?
        //return MendeljevElementen.Find(e => e.Abbreviation.Equals(element));
        foreach (Element e in MendeljevElementen)
        {
            if (element.Equals(e.Abbreviation))
            {
                return e;
            }
        }
        return null;
    }
}
