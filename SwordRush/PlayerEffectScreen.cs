﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SwordRush;

public class PlayerEffectScreen
{
    private readonly Animation<Color> _animation = new(0.05f);
    private Point _windowSize;
    private Texture2D border;

    public PlayerEffectScreen(Point windowSize)
    {
        _animation.AddFrame(new Color(200, 0, 0, 50));
        _animation.AddFrame(new Color(150, 0, 0, 50));
        _animation.AddFrame(new Color(100, 0, 0, 25));
        _animation.AddFrame(new Color(100, 0, 0, 25));
        _animation.AddFrame(new Color(0, 0, 0, 0));

        _windowSize = windowSize;

        border = GameManager.Get.ContentManager.Load<Texture2D>("BloodEffect");
    }

    public void Start()
    {
        _animation.Reset();
    }

    public void Update(GameTime gt)
    {
        _animation.Update(gt);
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(border, new Rectangle(0, 0, _windowSize.X, _windowSize.Y), _animation.Frame);
        //System.Diagnostics.Debug.WriteLine(_animation.Frame);
    }
}