﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

//Converts .cif files to Structures 
public class CifConverter
{
    private float a;
    private float b;
    private float c;
    private float alpha;
    private float beta;
    private float gamma;
    private Dictionary<string, List<string>> atoms = new Dictionary<string, List<string>>();
    private Dictionary<string, List<string>> symmetry = new Dictionary<string, List<string>>();

    public Transform atom;

    public Structure getStructure(string pathName)
    {
        string path = pathName;
        Structure returnStructuur;
        Convert(path);
        List<Atom> atomen = new List<Atom>();
        List<Element> elements = new List<Element>();
        List<string> XValues = null;
        List<string> YValues = null;
        List<string> ZValues = null;

        //Initializing X,Y,Z and Elements
        foreach (KeyValuePair<string, List<string>> entry in atoms)
        {

            if (entry.Key.Equals("_atom_site_fract_x"))
            {
                XValues = entry.Value;
            }


            if (entry.Key.Equals("_atom_site_fract_y"))
            {
                YValues = entry.Value;
            }

            if (entry.Key.Equals("_atom_site_fract_z"))
            {
                ZValues = entry.Value;
            }

            if (entry.Key.Equals("_atom_site_label"))
            {
                foreach (string item in entry.Value)
                {
                    elements.Add(AllElements.getElement(item.Substring(0, 2)));
                }
            }

        }
        
        //Setting initial Atoms
        for (int i = 0; i < XValues.Count; i++)
        {
            Atom atoom = new Atom(double.Parse(XValues[i]) * a, double.Parse(YValues[i]) * b, double.Parse(ZValues[i]) * c, elements[i].abbreviation);
           
            atomen.Add(atoom);
        }
        //No use of symmetry so instead there is this,
        //Copying cornerpoints of atoms, for cubic structures
        for (int i = 0; i < atomen.Count; i++) {
            if (atomen[i].x == 0) {
                atomen.Add(new Atom(a, atomen[i].y, atomen[i].z,atomen[i].element.abbreviation));
            }
            if (atomen[i].y == 0)
            {
                atomen.Add(new Atom(atomen[i].x, b, atomen[i].z, atomen[i].element.abbreviation));
            }
            if (atomen[i].z == 0)
            {
                atomen.Add(new Atom(atomen[i].x, atomen[i].y, c, atomen[i].element.abbreviation));
            }
        }
        returnStructuur = new Structure(atomen, a, atom);
       

        return returnStructuur;
    }

    //Converts cif file to Symmetry and Atoms Dictioniaries
    private void Convert(string path)
    {
        atoms.Clear();
        symmetry.Clear();
        RegexOptions options = RegexOptions.None;
        Regex regex = new Regex("[ ]{2,}", options);


        using (StreamReader sr = File.OpenText(path))
        {
            string line = "";
            while (sr.Peek() >= 0)
            {
                if (line.Contains("loop_"))
                {
                    line = sr.ReadLine();
                    if (line.StartsWith("_atom_site_label"))
                    {
                        while (line.StartsWith("_"))
                        {
                            atoms.Add(line.Trim(), new List<string>());
                            line = sr.ReadLine();
                        }
                        while (line != null && (!line.Trim().Equals("") && !line.Contains("loop_") && !line.Contains("#End of data") && !line.StartsWith("_")))
                        {
                            string[] values = line.Split(" ".ToCharArray(), atoms.Count);
                            int i = 0;
                            foreach (var keyValuePair in atoms)
                            {
                                keyValuePair.Value.Add(values[i]);
                                i++;
                            }
                            line = sr.ReadLine();
                        }
                    }
                    else if (line.StartsWith("_symmetry_equiv_pos") || line.StartsWith("_space_group_symop_operation"))
                    {
                        while (line.StartsWith("_"))
                        {
                            symmetry.Add(line.Trim(), new List<string>());
                            line = sr.ReadLine();
                        }
                        while (line != null && (!line.Trim().Equals("") && !line.Contains("loop_") && !line.Contains("#End of data") && !line.StartsWith("_")))
                        {
                            string[] values = line.Split(" ".ToCharArray(), symmetry.Count);
                            int i = 0;
                            foreach (var keyValuePair in symmetry)
                            {
                                keyValuePair.Value.Add(values[i]);
                                i++;
                            }
                            line = sr.ReadLine();
                        }
                    }
                }
                else
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
                    line = sr.ReadLine();
                    line = regex.Replace(line, " ");
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