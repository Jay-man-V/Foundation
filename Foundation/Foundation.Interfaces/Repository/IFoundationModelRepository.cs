//-----------------------------------------------------------------------
// <copyright file="IFoundationModelRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the IFoundationModelRepository behaviours
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IFoundationModelRepository<TModel> : IDisposable where TModel : IFoundationModel
    {
        /// <summary>
        /// Gets a value indicating whether this instance has static data columns.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has static data columns; otherwise, <c>false</c>.
        /// </value>
        Boolean HasValidityPeriodColumns { get; }

        /// <summary>
        /// Gets all active.
        /// </summary>
        /// <returns>List of all active entities</returns>
        List<TModel> GetAllActive();

        /// <summary>
        /// Gets all active.
        /// </summary>
        /// <param name="excludeDeleted">Whether to include deleted entities</param>
        /// <param name="useValidityPeriod">Whether to check an entities validity period for inclusion</param>
        /// <returns>List of all active entities</returns>
        List<TModel> GetAll(Boolean excludeDeleted, Boolean useValidityPeriod);

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns>Loaded entity</returns>
        TModel Get(EntityId entityId);

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entityIds">The entity identifiers.</param>
        /// <returns>Loaded entity</returns>
        List<TModel> Get(List<EntityId> entityIds);

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entityKey">The entity identifier.</param>
        /// <returns>Loaded entity</returns>
        TModel Get(String entityKey);

        /// <summary>
        /// Deletes the entity with the <paramref name="entityId"/>
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entityId"/> is null</exception>
        void Delete(EntityId entityId);

        /// <summary>
        /// Deletes the <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        TModel Delete(TModel entity);

        /// <summary>
        /// Saves the <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        TModel Save(TModel entity);

        /// <summary>
        /// Deletes the provided list of <paramref name="entities"/>
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entities"/> is null</exception>
        List<TModel> Delete(List<TModel> entities);

        /// <summary>
        /// Saves the provided list of <paramref name="entities"/>
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entities"/> is null</exception>
        List<TModel> Save(List<TModel> entities);

#if(DEBUG)
        /// <summary>
        /// Deletes all records. Only available in Debug builds
        /// </summary>
        void DeleteAll();
#endif
    }
}
