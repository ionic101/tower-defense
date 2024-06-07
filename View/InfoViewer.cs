
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class InfoViewer
{
    private SpriteBatch spriteBatch;
    private SpriteFont font;
    private GameSessionData sessionData;

    private Texture2D slotTexture;

    public InfoViewer(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        this.spriteBatch = spriteBatch;
        this.sessionData = sessionData;
    }

    public void LoadTexture(SpriteFont font)
    {
        this.font = font;
    }

    public void Display()
    {
        spriteBatch.DrawString(font, sessionData.Money.ToString() + "$",
            new Vector2(0, 0), Color.White);
    }
}
