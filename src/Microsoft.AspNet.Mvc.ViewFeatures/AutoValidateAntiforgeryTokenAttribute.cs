// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNet.Mvc.ViewFeatures
{
    /// <summary>
    /// An attribute that causes validation of antiforgery tokens for all unsafe HTTP methods.
    /// </summary>
    /// <remarks>
    /// <see cref="AutoValidateAntiforgeryTokenAttribute"/> can be applied at as a global filter to trigger
    /// validation of antiforgery tokens by default for an application. Use
    /// <see cref="IgnoreAntiforgeryTokenAttribute"/> to suppress validation of the antiforgery token for
    /// a controller or action.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AutoValidateAntiforgeryTokenAttribute : Attribute, IFilterFactory, IOrderedFilter
    {
        /// <inheridoc />
        public int Order { get; set; }

        /// <inheridoc />
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<AutoValidateAntiforgeryTokenAuthorizationFilter>();
        }
    }
}
