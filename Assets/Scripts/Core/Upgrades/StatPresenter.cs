namespace Core.Upgrades
{
    public class StatPresenter
    {
        private readonly UpgradesConfig _upgradesConfig;
        private readonly StatLevelSaver _statLevelSaver;

        public StatPresenter(UpgradesConfig upgradesConfig, StatLevelSaver statLevelSaver)
        {
            _statLevelSaver = statLevelSaver;
            _upgradesConfig = upgradesConfig;
        }

        public int PowerValue => _upgradesConfig.PowerStatList[_statLevelSaver.PowerLevel].Value;
        public int SpeedValue => _upgradesConfig.SpeedStatList[_statLevelSaver.SpeedLevel].Value;
        public int ArmorValue => _upgradesConfig.ArmorStatList[_statLevelSaver.ArmorLevel].Value;        
        
        public int PowerCost => _upgradesConfig.PowerStatList[_statLevelSaver.PowerLevel].Cost;
        public int SpeedCost => _upgradesConfig.SpeedStatList[_statLevelSaver.SpeedLevel].Cost;
        public int ArmorCost => _upgradesConfig.ArmorStatList[_statLevelSaver.ArmorLevel].Cost;
    }
}