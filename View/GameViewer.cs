using Microsoft.Xna.Framework.Graphics;

class GameViewer
{
    public MapViewer MapViewer { get; private set; }
    public TowersViewer TowersViewer { get; private set; }
    public EnemysViewer EnemysViewer { get; private set; }
    public SelecterViewer SelecterViewer { get; private set; }
    public TowerStoreViewer TowerStoreViewer { get; private set; }

    public void Init(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        TowersViewer = new TowersViewer(spriteBatch, sessionData);
        EnemysViewer = new EnemysViewer(spriteBatch, sessionData);
        MapViewer = new MapViewer(spriteBatch, sessionData);
        SelecterViewer = new SelecterViewer(spriteBatch, sessionData);
        TowerStoreViewer = new TowerStoreViewer(spriteBatch, sessionData);
    }

    public void Display()
    {
        MapViewer.Display();
        TowersViewer.Display();
        EnemysViewer.Display();
        SelecterViewer.Display();
        TowerStoreViewer.Display();
    }
}
