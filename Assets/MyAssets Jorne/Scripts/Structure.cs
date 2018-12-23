
using System.Collections.Generic;
using UnityEngine;

public class Structure{
    public Transform atom;
    private List<Atom> atoms = new List<Atom>();
    private float maxX;
    private float maxY;
    private float maxZ;
    private const int SIZE = 3;

    public Structure(List<Atom> atoms,float maxKubus,Transform atom) {
        this.atom=atom;
        this.atoms = atoms;
        maxX = maxKubus;
        maxY = maxKubus;
        maxZ = maxKubus;
    }
    //Draws the structure in prime position
    /*public void drawSingleStruct() {
        foreach (Atom a in atoms)
        {
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3((float)a.x, (float)a.y, (float)a.z);
        }
    }*/

   
    
    public void DrawAlongXAxis(float zOffset,float yOffset) {
       int count = 0;
        while (count < SIZE)
        {
          foreach (Atom a in atoms)
            {
                Vector3 positie= new Vector3((float)a.X + (maxX * count), (float)a.Y+yOffset, (float)a.Z+zOffset);
                if (!Physics.CheckSphere(positie,(float)0.001))
                {
                    //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    //cube.transform.position = positie;
                    
                    
                    GameObject gameObject=GameObject.Instantiate(atom.gameObject,positie,Quaternion.identity);
                    Renderer renderer = gameObject.GetComponent<Renderer>();
                    renderer.material.color = new Color(a.Element.Color.r/255, a.Element.Color.g/255, a.Element.Color.b/255);

                }
            }
            count++;
        }
    }
    
   public void DrawHorizontalLayer(float yOffset) {
       int zCount = 0;
       while (zCount < SIZE)
       {
           DrawAlongXAxis(zCount * maxZ,yOffset);
           zCount++; 
       }

   }

   public void DrawEveryLayer() {
       int yCount = 0;
       while (yCount < SIZE) {
           DrawHorizontalLayer(yCount*maxY);
           yCount++;
       }
   }

   

}
