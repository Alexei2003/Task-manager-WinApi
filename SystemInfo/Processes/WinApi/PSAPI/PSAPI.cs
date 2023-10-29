namespace SystemInfo.Processes.WinApi.PSAPI
{
    public class PSAPI : PsapiDLL
    {
        /// <summary>
        /// Извлекает идентификатор процесса для каждого объекта процесса в системе.
        /// </summary>
        public static uint[] EnumProcesses()
        {
            const uint COUNT_PROCESS = 10000;

            var result = new uint[COUNT_PROCESS];

            if (!EnumProcesses(result, COUNT_PROCESS, out uint realCountProcess))
            {
                return null;
            }
            realCountProcess /= sizeof(uint);

            if (COUNT_PROCESS == realCountProcess)
            {
                return null;
            }

            Array.Resize<uint>(ref result, Convert.ToInt32(realCountProcess));

            return result;
        }
    }
}
