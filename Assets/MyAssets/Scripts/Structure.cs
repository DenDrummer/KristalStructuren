using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure{
    public Transform atom;
    private List<Atom> atoms = new List<Atom>();
    private const int maxRadius= 240;
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

   
    
    public void drawAlongXAxis(float zOffset,float yOffset) {
       int count = 0;
        while (count < SIZE)
        {
          foreach (Atom a in atoms)
            {
                Vector3 positie= new Vector3((float)a.x + (maxX * count), (float)a.y+yOffset, (float)a.z+zOffset);
                if (!Physics.CheckSphere(positie,(float)0.001))
                {                  
                    GameObject gameObject=GameObject.Instantiate(atom.gameObject,positie,Quaternion.identity);
                    gameObject.name = a.element.abbreviation;
                    gameObject.transform.localScale = (gameObject.transform.localScale * a.element.atomicRadius)/100;
                    Renderer renderer = gameObject.GetComponent<Renderer>();
                    renderer.material.color = new Color(a.element.color.r/255, a.element.color.g/255, a.element.color.b/255);
                }
            }
            count++;
        }
    }
    
   public void drawHorizontalLayer(float yOffset) {
       int zCount = 0;
       while (zCount < SIZE)
       {
           drawAlongXAxis(zCount * maxZ,yOffset);
           zCount++; 
       }

   }

   public void drawEveryLayer() {
       int yCount = 0;
       while (yCount < SIZE) {
           drawHorizontalLayer(yCount*maxY);
           yCount++;
       }
   }

   

}
