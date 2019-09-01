using System;
using SwinGameSDK;
using System.Collections.Generic;

public class Shape
{
    private Color _color;
    private float _x;
    private float _y;
    private int _width;
    private int _height;
    private bool _selected;


    public bool Selected { get => _selected; set => _selected = value; }
    public float X { get => _x; set => _x = value; }
    public float Y { get => _y; set => _y = value; }
    public Color Color { get => _color; set => _color = value; }

    public Shape()
	{
        _color = Color.Green;
        _x = 0;
        _y = 0;
        _width = 100;
        _height = 100;
        _selected = false;
    }
    public bool IsAt(Point2D pt)
    {
        if (SwinGame.PointInRect(pt, _x, _y, _width, _height))
        {
            return true;
        }
        else return false;
    }
    public void DrawOutline()
    {
        SwinGame.FillRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
    }
    public void Draw()
    {
        if (_selected == true)
        {
            DrawOutline();
        }
        SwinGame.FillRectangle(_color, _x, _y, _width, _height);
    }


}
