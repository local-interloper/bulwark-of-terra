using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BulwarkOfTerra;

public static class InputSystem
{
    private static MouseState _lastMouseState;

    public delegate void OnClickHandler(Point position);

    public static event OnClickHandler OnClick;

    public static void Update()
    {
        ProcessMouse();
    }

    private static void ProcessMouse()
    {
        var mouseState = Mouse.GetState();

        if (mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released)
        {
            OnClick?.Invoke(mouseState.Position);
        }

        _lastMouseState = mouseState;
    }
}