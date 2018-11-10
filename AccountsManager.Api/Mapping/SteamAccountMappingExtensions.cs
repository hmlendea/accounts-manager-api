using System.Collections.Generic;
using System.Linq;

using AccountsManager.Api.Models;
using AccountsManager.DataAccess.DataObjects;

namespace AccountsManager.Api.Mapping
{
    /// <summary>
    /// SteamAccount mapping extensions for converting between entities and API models.
    /// </summary>
    static class SteamAccountMappingExtensions
    {
        /// <summary>
        /// Converts the dataObject into a API model.
        /// </summary>
        /// <returns>The API model.</returns>
        /// <param name="dataObject">Steam account data object.</param>
        internal static SteamAccount ToApiModel(this SteamAccountEntity dataObject)
        {
            SteamAccount apiModel = new SteamAccount();
            apiModel.Username = dataObject.Username;
            apiModel.Password = dataObject.Password;
            apiModel.EmailAddress = dataObject.EmailAddress;
            apiModel.Country = dataObject.Country;

            return apiModel;
        }

        /// <summary>
        /// Converts the API model into a data object.
        /// </summary>
        /// <returns>The data object.</returns>
        /// <param name="apiModel">Steam account API model.</param>
        internal static SteamAccountEntity ToDataObject(this SteamAccount apiModel)
        {
            SteamAccountEntity dataObject = new SteamAccountEntity();
            dataObject.Username = apiModel.Username;
            dataObject.Password = apiModel.Password;
            dataObject.EmailAddress = apiModel.EmailAddress;
            dataObject.Country = apiModel.Country;

            return dataObject;
        }

        /// <summary>
        /// Converts the data objects into API models.
        /// </summary>
        /// <returns>The API models.</returns>
        /// <param name="dataObjects">Steam account data objects.</param>
        internal static IEnumerable<SteamAccount> ToApiModels(this IEnumerable<SteamAccountEntity> dataObjects)
        {
            IEnumerable<SteamAccount> apiModels = dataObjects.Select(steamAccountEntity => steamAccountEntity.ToApiModel());

            return apiModels;
        }

        /// <summary>
        /// Converts the API models into data objects.
        /// </summary>
        /// <returns>The data objects.</returns>
        /// <param name="apiModels">Steam account API models.</param>
        internal static IEnumerable<SteamAccountEntity> ToEntities(this IEnumerable<SteamAccount> apiModels)
        {
            IEnumerable<SteamAccountEntity> dataObjects = apiModels.Select(steamAccount => steamAccount.ToDataObject());

            return dataObjects;
        }
    }
}