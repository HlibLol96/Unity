public class HpBarPresenter
{
    private readonly IHpBar view;
    public HpBarPresenter(IHpBar view)
    {
        this.view = view;
        this.view.Initialize
            (PlayerInfo.Instance.Hp / 100, 
            PlayerInfo.Instance.Hunger /100, 
            PlayerInfo.Instance.Thirst /100);
        this.view.ChangeBusEvent += ChangeBas;
        this.view.SmallerStuff += SmallerStuf;


    }

    private void SmallerStuf(float hunger,float thirst)
    {
        PlayerInfo.Instance.Hunger -= hunger;
        PlayerInfo.Instance.Thirst -= thirst;

        
    }
    private void ChangeBas()
    {
        view.Initialize(PlayerInfo.Instance.Hp / 100, 
            PlayerInfo.Instance.Hunger /100, 
            PlayerInfo.Instance.Thirst /100);
    }
}
