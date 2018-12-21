using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CifConverter : MonoBehaviour {

    private float a;
    private float b;
    private float c;
    private float alpha;
    private float beta;
    private float gamma;
    private Dictionary<string, List<string>> atoms = new Dictionary<string, List<string>>();
    private Dictionary<string, List<string>> symmetry = new Dictionary<string, List<string>>();

    private void Start()
    {
        string path = @"C:\Users\Marnick\Downloads\B19%27 (COD 1522310 Kudoh).cif";
        Convert(path);
        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(c);
        Debug.Log(alpha);
        Debug.Log(beta);
        Debug.Log(gamma);
        Debug.Log(atoms.Count);
        Debug.Log(symmetry.Count);
        List<string> list = new List<string>(Directory.GetFiles(@"C:\Users\Marnick\Downloads"));
        list.ForEach(i => {
            if (i.EndsWith(".cif"))
            {
                Debug.Log(i);
            }
        });
    }

    public void Convert(string path)
    {
        atoms.Clear();
        symmetry.Clear();
        using (StreamReader sr = File.OpenText(path))
        {
            string line = "";
            while (sr.Peek() >= 0)
            {
                Debug.Log(line);
                if (line.Contains("loop_"))
                {
                    line = LoopProcessor(sr);
                }
                else
                {
                    ValueGetter(line);
                    line = sr.ReadLine();
                }
            }
        }
    }

    private string LoopProcessor(StreamReader sr) {
        string line = sr.ReadLine();
        if (line.StartsWith("_atom_site_label"))
        {
            line = DictionaryCreator(atoms, sr, line);
        }
        else if (line.StartsWith("_symmetry_equiv_pos"))
        {
            line = DictionaryCreator(symmetry, sr, line);
        }
        return line;
    }

    private string DictionaryCreator(Dictionary<string, List<string>> dictionary,StreamReader sr, string input)
    {
        string line = input;
        while (line.StartsWith("_"))
        {
            Debug.Log(line);
            dictionary.Add(line.Trim(), new List<string>());
            Debug.Log("Key added");
            line = sr.ReadLine();
        }
        while (line != null && (!line.Trim().Equals("") && !line.Contains("loop_") && !line.Contains("#End of data") && !line.StartsWith("_")))
        {
            Debug.Log(line);
            string[] values = line.Split(" ".ToCharArray(), dictionary.Count);
            int i = 0;
            foreach (var keyValuePair in dictionary)
            {
                keyValuePair.Value.Add(values[i]);
                i++;
            }
            line = sr.ReadLine();
        }
        return line;
    }

    private void ValueGetter(string line)
    {
        if (line.StartsWith("_"))
        {
            if (line.StartsWith("_cell_length"))
            {
                if (line.StartsWith("_cell_length_a"))
                {
                    a = GetValue(line, "_cell_length_a");
                }
                else if (line.StartsWith("_cell_length_b"))
                {
                    b = GetValue(line, "_cell_length_b");
                }
                else if (line.StartsWith("_cell_length_c"))
                {
                    c = GetValue(line, "_cell_length_c");
                }
            }
            else if (line.StartsWith("_cell_angle"))
            {
                if (line.StartsWith("_cell_angle_alpha"))
                {
                    alpha = GetValue(line, "_cell_angle_alpha");
                }
                else if (line.StartsWith("_cell_angle_beta"))
                {
                    beta = GetValue(line, "_cell_angle_beta");
                }
                else if (line.StartsWith("_cell_angle_gamma"))
                {
                    gamma = GetValue(line, "_cell_angle_gamma");
                }
            }
        }
    }

    private float GetValue(string line, string tag)
    {
        int index = line.IndexOf(tag);
        return float.Parse(line.Remove(index, tag.Length).Trim().Split("(".ToCharArray())[0]);
    }
}
