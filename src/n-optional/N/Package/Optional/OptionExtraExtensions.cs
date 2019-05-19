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

        /// <summary>
        /// Return a value property on the option internal or defaultValue
        /// </summary>
        public static TRtn WithValue<T, TRtn>(this Option<T> option, Func<T, TRtn> action, TRtn defaultValue)
        {
            if (!option) return defaultValue;
            try
            {
                return action(option.Unwrap(() => default(T)));
            }
            catch (Exception error)
            {
                Debug.LogError(error);
                return defaultValue;
            }
        }

        /// <summary>
        /// Return a value property on the option internal or defaultValue
        /// </summary>
        public static Task<TRtn> WithValue<T, TRtn>(this Option<T> option, Func<T, Task<TRtn>> action, TRtn defaultValue)
        {
            if (!option) return Task.FromResult(defaultValue);
            try
            {
                return action(option.Unwrap(() => default(T)));
            }
            catch (Exception error)
            {
                Debug.LogError(error);
                return Task.FromResult(defaultValue);
            }
        }
    }
}