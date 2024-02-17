
public class PlayerInfo
{
    private static PlayerInfo instance;

    public static PlayerInfo Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerInfo();
            return instance;
        }
    }

    public float Hp { get; set; } = 100;
    public float Hunger { get; set; } = 100;
    public float Thirst { get; set; } = 100;
    private PlayerInfo()
    {
       
    }
}
