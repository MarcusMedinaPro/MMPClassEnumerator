namespace MMPClassEnumerator;

using System.Reflection;

public static class EnumerateClasses<T>
{
    #region Public Methods

    /// <summary>
    /// Gets instances of classes that match the given parent class
    /// </summary>
    /// <returns><seealso cref="IEnumerable"/> with instances of the matching classes</returns>
    public static IEnumerable<T> GetClassesByInheritance ()
    {
        // Inspired from https://stackoverflow.com/a/699871
        var instances = from t in Assembly.GetCallingAssembly().GetTypes()
                        where t.BaseType == typeof(T) && t.GetConstructor(Type.EmptyTypes) != null
                        select Activator.CreateInstance(t) ?? default;

        return instances.Cast<T>();
    }

    /// <summary>
    /// Gets instances of classes that match the given Interface
    /// </summary>
    /// <returns><seealso cref="IEnumerable"/> with instances of the matching classes</returns>
    public static IEnumerable<T> GetClassesByInterface ()
    {
        // Inspired from https://stackoverflow.com/a/699871
        var instances = from t in Assembly.GetCallingAssembly().GetTypes()
                        where t.GetInterfaces().Contains(typeof(T)) && t.GetConstructor(Type.EmptyTypes) != null
                        select Activator.CreateInstance(t) ?? default;

        return instances.Cast<T>();
    }

    /// <summary>
    /// Gets definitons of classes that match the given parent class
    /// </summary>
    /// <returns><seealso cref="IEnumerable"/> with types of the matching classes</returns>
    public static IEnumerable<Type> ListClassesByInheritance ()
    {
        // Inspired from https://stackoverflow.com/a/699871
        var instances = from t in Assembly.GetCallingAssembly().GetTypes()
                        where t.BaseType == typeof(T)
                                 && t.GetConstructor(Type.EmptyTypes) != null
                        select t ?? default;

        return instances.ToList();
    }

    /// <summary>
    /// Gets definitons of classes that match the given Interface
    /// </summary>
    /// <returns><seealso cref="IEnumerable"/> with types of the matching classes</returns>
    public static IEnumerable<Type> ListClassesByInterface ()
    {
        // Inspired from https://stackoverflow.com/a/699871
        var instances = from t in Assembly.GetCallingAssembly().GetTypes()
                        where t.GetInterfaces().Contains(typeof(T))
                                 && t.GetConstructor(Type.EmptyTypes) != null
                        select t ?? default;

        return instances.ToList();
    }

    #endregion Public Methods
}