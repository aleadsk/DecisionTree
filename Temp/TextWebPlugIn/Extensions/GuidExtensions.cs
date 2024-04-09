namespace TextWebPlugIn.Extensions;

public static class GuidExtensions {
    public static bool IsEmpty(this Guid guid) { 
        return guid == Guid.Empty;
    }

    public static bool IsEmpty(this Guid? guid) {
        return !guid.HasValue || guid == Guid.Empty;
    }

    public static bool IsEmpty(this string guid) { 
        return string.IsNullOrEmpty(guid) || guid == Guid.Empty.ToString();
    }
}