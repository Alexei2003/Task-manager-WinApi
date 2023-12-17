using SystemInfo.Processes.WinApi.PTAPI;
using SystemInfo.SystemDate.WinApi.SIAPI;

namespace SystemInfo.SystemDate.GlobalStatistics
{
    public class GlobalStatistics
    {
        public const int COUNT_TIME = 60;
        public const int MAX_PERCENT = 100;

        public enum StatisticsType
        {
            Cpu, Ram
        }

        public Queue<int> CpuUsePercent { get; private set; } = new Queue<int>();
        public Queue<int> RamUsePercent { get; private set; } = new Queue<int>();

        private UInt64 timeAllPred = 0;
        private UInt64 timeUsePred = 0;

        public GlobalStatistics()
        {

        }

        public void Update()
        {
            ChangeCpuUsePercent();
            ChangeRamUsePercent();
        }

        private void ChangeCpuUsePercent()
        {
            var timeAll = PTAPI.GetSystemTimesAll();
            var timeUse = PTAPI.GetSystemTimesUse();

            var delta = ((timeUse - timeUsePred) * 1.0) / (timeAll - timeAllPred) * MAX_PERCENT;

            timeAllPred = timeAll;
            timeUsePred = timeUse;

            if (delta > MAX_PERCENT)
            {
                return;
            }
            CpuUsePercent.Enqueue(Convert.ToInt32(delta));

            if (CpuUsePercent.Count > COUNT_TIME)
            {
                CpuUsePercent.Dequeue();
            }
        }

        private void ChangeRamUsePercent()
        {
            var res = SIAPI.GlobalMemoryStatusEx();

            RamUsePercent.Enqueue(Convert.ToInt32(res.dwMemoryLoad));

            if (RamUsePercent.Count > COUNT_TIME)
            {
                RamUsePercent.Dequeue();
            }
        }

    }
}
