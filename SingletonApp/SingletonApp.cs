using System.Reflection;

namespace Asjc.SingletonApp
{
    /// <summary>
    /// Provides functionality to ensure only one instance of the application is running.
    /// </summary>
    public static class SingletonApp
    {
        private static Mutex? mutex;
        private static bool isNew;

        /// <summary>
        /// Gets a value indicating whether this is the first instance of the application.
        /// </summary>
        public static bool IsNew
        {
            get
            {
                if (!IsInitialized)
                    Initialize();
                return isNew;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the singleton check has been initialized.
        /// </summary>
        public static bool IsInitialized => mutex != null;

        /// <summary>
        /// Initializes the singleton check.
        /// </summary>
        public static void Initialize(bool useGlobal = true)
        {
            string? assemblyName = (Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()).GetName().Name;
            Initialize(assemblyName, useGlobal);
        }


        /// <summary>
        /// Initializes the singleton check.
        /// </summary>
        public static void Initialize(string? identifier, bool useGlobal = true)
        {
            string? name = useGlobal ? $"Global\\{identifier}" : identifier;
            bool createdNew;
            mutex = new(true, name, out createdNew);
            isNew = createdNew;
        }

        /// <summary>
        /// Cleans up the mutex resources used by the singleton check.
        /// </summary>
        public static void Cleanup()
        {
            if (mutex != null)
            {
                if (isNew)
                    mutex.ReleaseMutex();
                mutex.Close();
            }
        }
    }
}
