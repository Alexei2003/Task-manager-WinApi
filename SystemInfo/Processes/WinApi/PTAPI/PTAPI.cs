namespace SystemInfo.Processes.WinApi.PTAPI
{
    public class PTAPI : ProcessthreadsapiDLL
    {
        // Определение констант доступа к процессу
        public enum DesiredAccess : long
        {
            DELETE = 0x00010000L,
            READ_CONTROL = 0x00020000L,
            SYNCHRONIZE = 0x00100000L,
            WRITE_DAC = 0x00040000L,
            WRITE_OWNER = 0x00080000L,
            PROCESS_ALL_ACCESS = 0x001F0FFF,
            PROCESS_CREATE_PROCESS = 0x0080,
            PROCESS_CREATE_THREAD = 0x0002,
            PROCESS_DUP_HANDLE = 0x0040,
            PROCESS_QUERY_INFORMATION = 0x0400,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            PROCESS_SET_INFORMATION = 0x0200,
            PROCESS_SET_QUOTA = 0x0100,
            PROCESS_SUSPEND_RESUME = 0x0800,
            PROCESS_TERMINATE = 0x0001,
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ = 0x0010,
            PROCESS_VM_WRITE = 0x0020,
        }

        /// <summary>
        /// Открывает существующий локальный объект процесса.(Возвращает Handle)
        /// </summary>
        public static IntPtr OpenProcess(DesiredAccess desiredAccess, bool inheritHandle, uint processId)
        {
            var result = ProcessthreadsapiDLL.OpenProcess(Convert.ToInt64(desiredAccess), inheritHandle, processId);

            return result;
        }

    }
}
