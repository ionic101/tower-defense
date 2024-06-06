using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class HealthBarViewer
{
    private SpriteBatch spriteBatch;
    private Texture2D healthBarTexture;
    public readonly Vector2 HealthBarSize = new Vector2(40, 5);

    public HealthBarViewer(SpriteBatch spriteBatch)
    {
        this.spriteBatch = spriteBatch;
    }

    public void LoadTexture(Texture2D texture)
    {
        healthBarTexture = texture;
    }

    public void Display(Enemy enemy)
    {
        spriteBatch.Draw(healthBarTexture,
            enemy.Location * Settings.CellSize + new Vector2(1, 1) * (Settings.CellSize - HealthBarSize.X) / 2,
            null,
            Color.White,
            0f,
            Vector2.Zero,
            new Vector2((float)enemy.Health / enemy.MaxHealth * HealthBarSize.X, HealthBarSize.Y),
            SpriteEffects.None,
            0f);
    }
}
