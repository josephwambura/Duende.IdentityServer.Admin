using System;
using System.Linq;
using Duende.IdentityServer.Hosting.DynamicProviders;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Skoruba.Duende.IdentityServer.STS.Identity.Helpers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

namespace Skoruba.Duende.IdentityServer.STS.Identity.Services;

public class OpenIdClaimsMappingConfig(IHttpContextAccessor httpContextAccessor, ILogger<OpenIdClaimsMappingConfig> logger) : ConfigureAuthenticationOptions<OpenIdConnectOptions, OidcProvider>(httpContextAccessor, logger)
{
    protected override void Configure(ConfigureAuthenticationContext<OpenIdConnectOptions, OidcProvider> context)
    {
        var oidcProvider = context.IdentityProvider;

        context.IdentityProvider.Properties.TryGetValue("MapInboundClaims", out var resultMapInboundClaims);

        var mapInboundClaims = resultMapInboundClaims == null || "true".Equals(resultMapInboundClaims);

        context.AuthenticationOptions.MapInboundClaims = mapInboundClaims;
    }
}