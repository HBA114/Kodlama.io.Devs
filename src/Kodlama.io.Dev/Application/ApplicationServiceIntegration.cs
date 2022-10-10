using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.Technologies.Rules;
using Application.Features.GithubLinks.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Features.UserOperationClaims.Rules;

namespace Application;

public static class ApplicationServiceIntegration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<TechnologyBusinessRules>();
        services.AddScoped<GithubLinkBusinessRules>();
        services.AddScoped<AuthBusinessRules>();
        services.AddScoped<UserOperationClaimBusinessRules>();

        services.AddScoped<IAuthService, AuthManager>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        return services;
    }
}