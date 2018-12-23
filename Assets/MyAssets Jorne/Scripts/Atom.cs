
public class Atom
{
    public Element Element { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    private AllElements mendelJev;

    public Atom(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Atom(double x, double y, double z, string elementAbb)
    {
        X = x;
        Y = y;
        Z = z;
        mendelJev = new AllElements();
        Element = mendelJev.GetElement(elementAbb);
    }
}
