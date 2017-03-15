
namespace JareelUnity
{
    /// <summary>
    /// Interface which specifies that the item is able to make deep copies of
    /// type T
    /// </summary>
    /// <typeparam name="T">The type to create copies of</typeparam>
    public interface ICopyable<T>
    {
        /// <summary>
        /// Returns a deep copy of the given item
        /// </summary>
        /// <returns>The deep copy</returns>
        T Copy();
    }
}
