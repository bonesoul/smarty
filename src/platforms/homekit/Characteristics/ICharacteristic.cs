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

using DaanV2.UUID;

namespace Homer.Platform.HomeKit.Characteristics
{
    /// <summary>
    /// A characteristic is a feature that represents data or an associated behavior of a service. The characteristic is defined
    /// by a universally unique type, and has additional properties that determine how the value of the characteristic can be
    /// accessed.
    /// <remarks>
    /// <summary>
    /// After an accessory has a pairing, only the values of the Value (”value”) and Event Notifications (”ev”) properties are
    /// allowed to change.
    /// </summary>
    /// </remarks>
    /// </summary>
    public interface ICharacteristic
    {
        /// <summary>
        /// UUID of the characteristic.
        /// </summary>
        public UUID Uuid { get; }

        /// <summary>
        /// Display name of the characteristic.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// The value of the characteristic, which must conform to the ”format” property.The literal value null may also be used
        /// if the characteristic has no value.This property must be present if and only if the characteristic contains the
        /// Paired Read permission, see Table 6-4 (page 56).
        /// </summary>
        public dynamic Value { get; }

        public void SetValue(dynamic value);
    }
}
