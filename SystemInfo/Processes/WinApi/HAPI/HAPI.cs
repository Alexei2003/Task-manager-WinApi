namespace SystemInfo.Processes.WinApi.HAPI
{
    public class HAPI : HandleapiDLL
    {
        /// <summary>
        /// Закрывает открытый дескриптор объекта.
        /// </summary>
        public static bool CloseHandle(IntPtr handle)
        {
            return HandleapiDLL.CloseHandle(handle);
        }
    }
}
