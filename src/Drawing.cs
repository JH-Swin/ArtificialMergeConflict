using System;
using SwinGameSDK;
using System.Collections.Generic;

public class Drawing
{
    private readonly List<Shape> _shapes;
    private Color _background;



    //constructors
    public Drawing(Color background)
    {
        _shapes = new List<Shape>();
        _background = background;
    }
    public Drawing() : this(Color.White)
    {
        // If no Parameters are entered, sets background to white
    }



    //public variables
    public List<Shape> SelectedShapes()
    {
        List<Shape> result = new List<Shape>();
        foreach (Shape s in _shapes)
        {
            if (s.Selected == true)
            {
                result.Add(s);
            }
        }
        return result;
    }
    public int ShapeCount
    {
        get { return _shapes.Count; }
    }
    public Color Background { get => _background; set => _background = value; }




    //methods
    public void Draw()
    {
        SwinGame.ClearScreen(_background);
        foreach (Shape s in _shapes)
        {
            s.Draw();
        }
    }
    public void SelectShapesAt(Point2D pt)
    {
        foreach (Shape s in _shapes)
        {
            if (s.IsAt(pt)){
                s.Selected = true;
            } else
            {
                s.Selected = false;
            }
        }
    }




    //_shapes list commands
    public void AddShape(Shape s)
    {
        _shapes.Add(s);
    }
    public void RemoveShape(Shape s)
    {
        _shapes.Remove(s);
    }
}
