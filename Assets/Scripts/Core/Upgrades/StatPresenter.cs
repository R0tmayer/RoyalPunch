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
        public int HealthValue => _upgradesConfig.HealthStatList[_statLevelSaver.HealthLevel].Value;
        
        public int PowerCost => _upgradesConfig.PowerStatList[_statLevelSaver.PowerLevel].Cost;
        public int HealthCost => _upgradesConfig.HealthStatList[_statLevelSaver.HealthLevel].Cost;
    }
}