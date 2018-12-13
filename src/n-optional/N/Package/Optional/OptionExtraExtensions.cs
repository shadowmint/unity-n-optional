using System;
using System.Threading.Tasks;
using UnityEngine;

namespace N.Package.Optional
{
  public static class OptionExtraExtensions
  {
    /// <summary>
    /// Execute 'action' only if option is Some(T).
    /// </summary>
    public static bool With<T>(this Option<T> option, Action<T> action)
    {
      if (!option) return false;
      try
      {
        action(option.Unwrap(() => default(T)));
      }
      catch (Exception error)
      {
        Debug.LogError(error);
        return false;
      }

      return true;
    }
    
    /// <summary>
    /// Execute 'action' only if option is Some(T).
    /// </summary>
    public static async Task<bool> WithAsync<T>(this Option<T> option, Func<T, Task> action)
    {
      if (!option) return false;
      try
      {
        await action(option.Unwrap(() => default(T)));
      }
      catch (Exception error)
      {
        Debug.LogError(error);
        return false;
      }

      return true;
    }
  }
}