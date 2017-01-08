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
// Copyright (C) 2009-2017 by daxnet.
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

using Apworks.Querying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Apworks.Repositories
{
    /// <summary>
    /// Represents that the implemented classes are aggregate repositories.
    /// </summary>
    /// <typeparam name="TKey">The type of the aggregate root key.</typeparam>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
    public interface IRepository<TKey, TAggregateRoot>
        where TKey : IEquatable<TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        /// <summary>
        /// Gets the context in which the current repository exists.
        /// </summary>
        IRepositoryContext Context { get; }

        /// <summary>
        /// Adds the specified <see cref="IAggregateRoot{TKey}"/> instance to the current repository.
        /// </summary>
        /// <param name="aggregateRoot">The <see cref="IAggregateRoot{TKey}"/> instance to be added.</param>
        void Add(TAggregateRoot aggregateRoot);

        /// <summary>
        /// Adds the specified <see cref="IAggregateRoot{TKey}"/> instance to the current repository asynchronously.
        /// </summary>
        /// <param name="aggregateRoot">The <see cref="IAggregateRoot{TKey}"/> instance to be added.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes the specified aggregate root from the current repository.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        void Remove(TAggregateRoot aggregateRoot);

        /// <summary>
        /// Removes the specified aggregate root from the current repository asynchronously.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        /// <returns></returns>
        Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified aggregate root.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        void Update(TAggregateRoot aggregateRoot);

        /// <summary>
        /// Updates the specified aggregate root asynchronously.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task UpdateAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the <see cref="IAggregateRoot{TKey}"/> instance from current repository by using a specified key.
        /// </summary>
        /// <param name="key">The aggregate root key.</param>
        /// <returns>An instance of <see cref="IAggregateRoot{TKey}"/> that has the specified key.</returns>
        TAggregateRoot FindByKey(TKey key);

        /// <summary>
        /// Gets the <see cref="IAggregateRoot{TKey}"/> instance from current repository by using a specified key asynchronously.
        /// </summary>
        /// <param name="key">The aggregate root key.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        /// <returns>An instance of <see cref="IAggregateRoot{TKey}"/> that has the specified key.</returns>
        Task<TAggregateRoot> FindByKeyAsync(TKey key, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all the <see cref="IAggregateRoot{TKey}"/> instances from current repository.
        /// </summary>
        /// <returns>A <see cref="IQueryable{TAggregateRoot}"/> instance which queries over the collection of the <see cref="IAggregateRoot{TKey}"/> objects.</returns>
        IQueryable<TAggregateRoot> FindAll();

        /// <summary>
        /// Gets all the <see cref="IAggregateRoot{TKey}"/> instances from current repository asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>A <see cref="IQueryable{TAggregateRoot}"/> instance which queries over the collection of the <see cref="IAggregateRoot{TKey}"/> objects.</returns>
        Task<IQueryable<TAggregateRoot>> FindAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all the <see cref="IAggregateRoot{TKey}"/> instances from current repository according to a given query specification.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <returns>A <see cref="IQueryable{TAggregateRoot}"/> instance which queries over the collection of the <see cref="IAggregateRoot{TKey}"/> objects.</returns>
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification);

        /// <summary>
        /// Gets all the <see cref="IAggregateRoot{TKey}"/> instances from current repository according to a given query specification asynchronously.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>A <see cref="IQueryable{TAggregateRoot}"/> instance which queries over the collection of the <see cref="IAggregateRoot{TKey}"/> objects.</returns>
        Task<IQueryable<TAggregateRoot>> FindAllAsync(Expression<Func<TAggregateRoot, bool>> specification, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all the <see cref="IAggregateRoot{TKey}"/> instances from current repository according to a given query specification with the sorting enabled.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <param name="sortSpecification">The specifications which implies the sorting.</param>
        /// <returns>A <see cref="IQueryable{TAggregateRoot}"/> instance which queries over the collection of the <see cref="IAggregateRoot{TKey}"/> objects.</returns>
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification, SortSpecification<TKey, TAggregateRoot> sortSpecification);

        /// <summary>
        /// Gets all the <see cref="IAggregateRoot{TKey}"/> instances from current repository according to a given query specification with the sorting enabled.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <param name="sortSpecification">The specifications which implies the sorting.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>A <see cref="IQueryable{TAggregateRoot}"/> instance which queries over the collection of the <see cref="IAggregateRoot{TKey}"/> objects.</returns>
        Task<IQueryable<TAggregateRoot>> FindAllAsync(Expression<Func<TAggregateRoot, bool>> specification, SortSpecification<TKey, TAggregateRoot> sortSpecification, CancellationToken cancellationToken = default(CancellationToken));
    }
}
