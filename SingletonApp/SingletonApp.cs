using System.Reflection;

namespace AS
{
    namespace SingletonApp
    {
        public enum MutexScope
        {
            Local,
            Global
        }

        public static class SingletonApp
        {
            private static Mutex? mutex;

            public static bool IsNew { get; private set; }

            public static bool Check()
            {
                return Check(MutexScope.Local);
            }

            public static bool Check(MutexScope scope)
            {
                return Check($"{scope}\\{Assembly.GetEntryAssembly()?.GetName().Name}");
            }

            public static bool Check(string name)
            {
                bool createdNew;
                mutex = new(true, name, out createdNew);
                IsNew = createdNew;
                return createdNew;
            }

            public static void Cleanup()
            {
                mutex?.Close();
            }
        }
    }
}
