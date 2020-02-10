﻿#region license
// 
//     homer - The complete home automation for Homer Simpson.
//     Copyright (C) 2020, Hüseyin Uslu - shalafiraistlin at gmail dot com
//     https://github.com/bonesoul/homer
// 
//      “Commons Clause” License Condition v1.0
//
//      The Software is provided to you by the Licensor under the License, as defined below, subject to the following condition.
//  
//      Without limiting other conditions in the License, the grant of rights under the License will not include, and the License
//      does not grant to you, the right to Sell the Software.
//
//      For purposes of the foregoing, “Sell” means practicing any or all of the rights granted to you under the License to provide
//      to third parties, for a fee or other consideration (including without limitation fees for hosting or consulting/ support
//      services related to the Software), a product or service whose value derives, entirely or substantially, from the functionality
//      of the Software.Any license notice or attribution required by the License must also include this Commons Clause License
//      Condition notice.
//
//      License: MIT License
//      Licensor: Hüseyin Uslu
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Homer.Platform.HomeKit.Accessories;

namespace Homer.Platform.HomeKit.Bridges
{
    public class Bridge : AccessoryBase, IBridge
    {
        const int MaxAccessories = 149; // Maximum number of bridged accessories per bridge.

        /// <inheritdoc />
        public IReadOnlyList<IAccessoryBase> Accessories { get; }

        /// <summary>
        /// internal list of accessories.
        /// </summary>
        private readonly List<IAccessoryBase> _accessories;

        protected Bridge(string uuid, string displayName, bool isReachable = true) 
            : base(uuid, displayName, false, isReachable, AccessoryCategory.Bridge)
        {
            _accessories = new List<IAccessoryBase>();

            Accessories = new ReadOnlyCollection<IAccessoryBase>(_accessories);
        }
    }
}
