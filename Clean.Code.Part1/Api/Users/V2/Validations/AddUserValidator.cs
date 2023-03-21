using AspNetCore.Simple.Sdk.Mediator;
using Clean.Code.Part1.Api.Users.V2.Commands;
using Extensions.Pack;

namespace Clean.Code.Part1.Api.Users.V2.Validations
{
    public static class AddAddUserValidatorExtension
    {
        public static void AddAddUserValidator(this IServiceCollection services)
        {
            services.AddSingletonIfNotExists<IRequestValidator<AddUser>, AddUserValidator>();
        }
    }

    // Sample: Very simple and serated validaton from the request it self
    //         Most use https://www.nuget.org/packages/FluentValidation to validate their data or requests
    // 
    // - Here you can validate the requested data - BUT NOT business relevant validation
    // - This is like an abstraction to IValidateObject from Asp.Net where all the data objects have validation attributes
    // - Your data objects did  not know about validation, makes them even more flexible about scope where they are used.
    internal sealed class AddUserValidator : IRequestValidator<AddUser>
    {
        public Task ValidateAsync(AddUser request)
        {
            // Check any necessary stuff here

            return Task.CompletedTask;
        }
    }
}
