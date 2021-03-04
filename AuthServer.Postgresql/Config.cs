using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using static IdentityServer4.IdentityServerConstants;

namespace AuthServer.Postgresql
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("api1.ticket.read", "WebApiSample"),
                new ApiScope("api1.ticket.write", "WebApiSample"),
                new ApiScope("api1.ticket.delete", "WebApiSample"),
                new ApiScope("api1.ticket.manage", "WebApiSample"),
                new ApiScope("api2.file.read", "WebApiSampleCasbin"),
                new ApiScope("api2.file.write", "WebApiSampleCasbin"),
                new ApiScope("api2.file.delete", "WebApiSampleCasbin"),
                new ApiScope("api2.file.manage", "WebApiSampleCasbin")
            };
        }

        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "API sample")
                {
                    Scopes =
                    {
                        "api1.ticket.read",
                        "api1.ticket.write",
                        "api1.ticket.delete",
                        "api1.ticket.manage"
                    }
                },
                new ApiResource("api2")
                {
                    Scopes =
                    {
                        "api2.file.read",
                        "api2.file.write",
                        "api2.file.delete",
                        "api2.file.manage"
                    }
                }
            };
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                // resource owner password grant client
                new Client
                {
                    ClientId = "clientApi1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "api1",
                        "api1.ticket.read",
                        StandardScopes.OfflineAccess,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        },
                },
                new Client
                {
                    ClientId = "clientApi2",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "api1.ticket.write",
                        "api2.file.read",
                        "api2.file.manage",
                        StandardScopes.OfflineAccess,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        },
                },
                new Client
                {
                    ClientId = "password",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        },
                }
            };
        }
    }
}
