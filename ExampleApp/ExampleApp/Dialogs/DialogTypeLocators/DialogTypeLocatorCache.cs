﻿using System;
using System.Collections.Generic;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// A cache holding the known mappings between view model types and dialogView types.
    /// </summary>
    internal class DialogTypeLocatorCache
    {
        private readonly Dictionary<Type, Type> cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogTypeLocatorCache"/> class.
        /// </summary>
        internal DialogTypeLocatorCache()
        {
            cache = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Adds the specified view model type with its corresponding dialogView type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="dialogType">Type of the dialogView.</param>
        internal void Add(Type viewModelType, Type dialogType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException(nameof(viewModelType));
            if (dialogType == null)
                throw new ArgumentNullException(nameof(dialogType));
            if (cache.ContainsKey(viewModelType))
                throw new ArgumentException($"View model of type '{viewModelType}' is already added.", nameof(viewModelType));

            cache.Add(viewModelType, dialogType);
        }

        /// <summary>
        /// Gets the dialogView type for specified view model type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns>The dialogView type if found; otherwise null.</returns>
        internal Type Get(Type viewModelType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException(nameof(viewModelType));

            Type dialogType;
            cache.TryGetValue(viewModelType, out dialogType);
            return dialogType;
        }

        /// <summary>
        /// Removes all view model types with its corresponding dialogView types.
        /// </summary>
        internal void Clear() => cache.Clear();

        /// <summary>
        /// Gets the number of dialogView type/view model type pairs contained in the cache.
        /// </summary>
        internal int Count => cache.Count;
    }
}