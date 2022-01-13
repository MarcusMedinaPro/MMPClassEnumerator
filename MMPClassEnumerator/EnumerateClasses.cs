// -----------------------------------------------------------------------------------------------
//  EnumerateClasses.cs by Marcus Medina, Copyright (C) 2021, http://MarcusMedina.Pro.
//  Published under Attribution-ShareAlike 4.0 International (CC BY-SA 4.0)
//  https://creativecommons.org/licenses/by-sa/4.0/
// -----------------------------------------------------------------------------------------------

namespace MarcusMedinaPro.ClassEnumerator;

using System.Reflection;

/// <summary>
/// The worker class that generates the lists
/// </summary>
/// <typeparam name="T"></typeparam>
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

        return instances.Cast<T>().OrderBy(n=>n.GetType().Name);
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

        return instances.Cast<T>().OrderBy(n => n.GetType().Name);
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

        return instances.OrderBy(n => n.GetType().Name);
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

        return instances.OrderBy(n => n.GetType().Name);
    }

    #endregion Public Methods
}