using System;
using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityModel;
using System.Security.Claims;
using IdentityServer4;

namespace Tracker.Identity
{
  public class Config
  {
    public static List<TestUser> TestUsers()
    {
      return new List<TestUser>
        {
            new TestUser{SubjectId = "818727", Username = "alice", Password = "alice",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser{SubjectId = "88421113", Username = "bob", Password = "bob",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "somewhere")
                }
            }
        };
    }

    public static IEnumerable<Client> Clients()
    {
      return new List<Client>
      {

        // OpenIdConnect Client - Mvc UI
        new Client
        {
          ClientId = "openIdConnectClientMvcUI",
          ClientName = "MvcUI",
          AllowedGrantTypes = GrantTypes.Hybrid,
          ClientSecrets = { new Secret("secret".Sha256())},
          AllowedScopes =
          {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
          },
          RedirectUris = { "https://localhost:44368/signin-oidc"},
          PostLogoutRedirectUris = { "https://localhost:44368/signout-callback-oidc" },

        }
      };
    }

    public static IEnumerable<IdentityResource> IdentityResources()
    {
      return new List<IdentityResource>
      {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
      };
    }

    public static IEnumerable<ApiResource> ApiResources()
    {
      return new List<ApiResource>
      {

      };
    }
  }
}