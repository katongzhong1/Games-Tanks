using System;

namespace GS {
    public static class ClassExtention {
        public static bool IsNull<T>(this T selfObj) where T : class {
            return null == selfObj;
        }

        public static bool IsNotNull<T>(this T selfObj) where T : class {
            return null != selfObj;
        }

        public static string GetTypeName<T>() {
            return typeof(T).ToString();
        }
    }
}
