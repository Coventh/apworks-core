﻿// ==================================================================================================================                                                                                          
//        ,::i                                                           BBB                
//       BBBBBi                                                         EBBB                
//      MBBNBBU                                                         BBB,                
//     BBB. BBB     BBB,BBBBM   BBB   UBBB   MBB,  LBBBBBO,   :BBG,BBB :BBB  .BBBU  kBBBBBF 
//    BBB,  BBB    7BBBBS2BBBO  BBB  iBBBB  YBBJ :BBBMYNBBB:  FBBBBBB: OBB: 5BBB,  BBBi ,M, 
//   MBBY   BBB.   8BBB   :BBB  BBB .BBUBB  BB1  BBBi   kBBB  BBBM     BBBjBBBr    BBB1     
//  BBBBBBBBBBBu   BBB    FBBP  MBM BB. BB BBM  7BBB    MBBY .BBB     7BBGkBB1      JBBBBi  
// PBBBFE0GkBBBB  7BBX   uBBB   MBBMBu .BBOBB   rBBB   kBBB  ZBBq     BBB: BBBJ   .   iBBB  
//BBBB      iBBB  BBBBBBBBBE    EBBBB  ,BBBB     MBBBBBBBM   BBB,    iBBB  .BBB2 :BBBBBBB7  
//vr7        777  BBBu8O5:      .77r    Lr7       .7EZk;     L77     .Y7r   irLY  JNMMF:    
//               LBBj
//
// Apworks Application Development Framework
// Copyright (C) 2009-2018 by daxnet.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ==================================================================================================================

using System;
using Microsoft.Extensions.DependencyInjection;
using Apworks.Integration.AspNetCore.Hal;

namespace Apworks.Integration.AspNetCore.Configuration
{
    /// <summary>
    /// Represents that the implemented classes are the configurators that can register
    /// an <see cref="IHalBuildConfiguration"/> instance to the <see cref="IServiceCollection"/> object.
    /// </summary>
    /// <seealso cref="Apworks.Integration.AspNetCore.Configuration.IConfigurator" />
    public interface IHalSupportConfigurator : IConfigurator
    {
    }

    /// <summary>
    /// Represents the default implementation of <see cref="IHalSupportConfigurator"/> interface.
    /// </summary>
    /// <typeparam name="THalBuildConfiguration">The type of the HAL build configuration.</typeparam>
    /// <seealso cref="Apworks.Integration.AspNetCore.Configuration.ServiceRegisterConfigurator{Apworks.Integration.AspNetCore.Hal.IHalBuildConfiguration, THalBuildConfiguration}" />
    /// <seealso cref="Apworks.Integration.AspNetCore.Configuration.IHalSupportConfigurator" />
    internal sealed class HalSupportConfigurator<THalBuildConfiguration> : ServiceRegisterConfigurator<IHalBuildConfiguration, THalBuildConfiguration>, IHalSupportConfigurator
        where THalBuildConfiguration : class, IHalBuildConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HalSupportConfigurator{THalBuildConfiguration}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="halBuildConfiguration">The HAL build configuration.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        public HalSupportConfigurator(IConfigurator context, THalBuildConfiguration halBuildConfiguration, ServiceLifetime serviceLifetime)
            : base(context, halBuildConfiguration, serviceLifetime)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HalSupportConfigurator{THalBuildConfiguration}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="halBuildConfigurationFactory">The HAL build configuration factory.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        public HalSupportConfigurator(IConfigurator context, Func<IServiceProvider, THalBuildConfiguration> halBuildConfigurationFactory, ServiceLifetime serviceLifetime)
            : base(context, halBuildConfigurationFactory, serviceLifetime)
        { }
    }
}
