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
            action(option.Unwrap(() => default(T)));
            return true;
        }

        /// <summary>
        /// Execute 'action' only if option is Some(T).
        /// </summary>
        public static async Task<bool> WithAsync<T>(this Option<T> option, Func<T, Task> action)
        {
            if (!option) return false;
            await action(option.Unwrap(() => default(T)));
            return true;
        }

        /// <summary>
        /// Return a value property on the option internal or defaultValue
        /// </summary>
        public static TRtn WithValue<T, TRtn>(this Option<T> option, Func<T, TRtn> action, TRtn defaultValue)
        {
            return !option ? defaultValue : action(option.Unwrap(() => default(T)));
        }

        /// <summary>
        /// Return a value property on the option internal or defaultValue
        /// </summary>
        public static Task<TRtn> WithValueAsync<T, TRtn>(this Option<T> option, Func<T, Task<TRtn>> action, TRtn defaultValue)
        {
            return !option ? Task.FromResult(defaultValue) : action(option.Unwrap(() => default(T)));
        }
    }
}