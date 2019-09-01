using System;
using SwinGameSDK;

namespace MyGame
{

    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            //SwinGame.ShowSwinGameSplashScreen();
            Drawing myDrawing = new Drawing();

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                myDrawing.Draw();
                SwinGame.DrawFramerate(0, 0);

                //Button Functions
                //spawn new shape
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    Shape s = new Shape();
                    s.X = SwinGame.MouseX();
                    s.Y = SwinGame.MouseY();
                    myDrawing.AddShape(s);
                }
                //randomise background color
                if (SwinGame.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SwinGame.RandomRGBColor(255);

                }
                //select
                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SwinGame.MousePosition());
                }
                //delete selected
                if ((SwinGame.KeyTyped(KeyCode.DeleteKey)) || (SwinGame.KeyTyped(KeyCode.BackspaceKey)))
                {
                    foreach (Shape selectedShape in myDrawing.SelectedShapes())
                    {
                        myDrawing.RemoveShape(selectedShape);
                    }
                }

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}