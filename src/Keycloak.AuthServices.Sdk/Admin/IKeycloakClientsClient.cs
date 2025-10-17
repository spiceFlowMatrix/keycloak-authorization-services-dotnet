namespace Keycloak.AuthServices.Sdk.Admin;

using Keycloak.AuthServices.Sdk.Admin.Models;
using Keycloak.AuthServices.Sdk.Admin.Requests.Clients;

/// <summary>
/// Client management
/// </summary>
public interface IKeycloakClientsClient
{
    /// <summary>
    /// Get a stream of clients on the realm.
    /// </summary>
    /// <param name="realm">Realm name (not ID).</param>
    /// <param name="parameters">Optional query parameters.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A stream of clients, filtered according to query parameters.</returns>
    Task<HttpResponseMessage> GetClientsWithResponseAsync(
        string realm,
        GetClientsRequestParameters? parameters = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get clients.
    /// </summary>
    /// <param name="realm">Realm name (not ID).</param>
    /// <param name="parameters">Optional query parameters.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A stream of clients, filtered according to query parameters.</returns>
    async Task<IEnumerable<ClientRepresentation>> GetClientsAsync(
        string realm,
        GetClientsRequestParameters? parameters = default,
        CancellationToken cancellationToken = default
    )
    {
        var response = await this.GetClientsWithResponseAsync(realm, parameters, cancellationToken);

        return await response.GetResponseAsync<IEnumerable<ClientRepresentation>>(cancellationToken)
            ?? Enumerable.Empty<ClientRepresentation>();
    }
}
