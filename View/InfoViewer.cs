
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
            new Vector2(10, 10), Color.White);

        if (!sessionData.StartGame)
            spriteBatch.DrawString(font, "For starting game press Enter",
            new Vector2(10, 65), Color.White);

        if (sessionData.IsLose)
            spriteBatch.DrawString(font, "You lose!",
            new Vector2(10, 65), Color.White);

        if (sessionData.IsWin)
            spriteBatch.DrawString(font, "You win!",
            new Vector2(10, 65), Color.White);
    }
}
