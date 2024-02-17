using HellaHotel.Scripts.Main_Game.MVP.Models.Data.Interfaces;

namespace HellaHotel.Scripts.Main_Game.MVP.Models
{
    public class FoodInfo : IRecoveryHp , IRecoveryHunger, IRecoveryThirst
    {
        public float RecoveryHp { get; set; }
        public float RecoveryHunger { get; set; }
        public float RecoveryThirst { get; set; }
    }
}