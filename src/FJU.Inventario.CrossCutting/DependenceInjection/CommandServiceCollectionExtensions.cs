using FJU.Inventario.Application.Commands.CreateProduct;
using FJU.Inventario.Application.Commands.CreateProject;
using FJU.Inventario.Application.Commands.CreateUser;
using FJU.Inventario.Application.Commands.ForgotPassword;
using FJU.Inventario.Application.Commands.Login;
using FJU.Inventario.Application.Commands.MoveInventory;
using FJU.Inventario.Application.Commands.RemoveProduct;
using FJU.Inventario.Application.Commands.RemoveProject;
using FJU.Inventario.Application.Commands.RemoveUser;
using FJU.Inventario.Application.Commands.ReturnedInventory;
using FJU.Inventario.Application.Commands.UpdateProduct;
using FJU.Inventario.Application.Commands.UpdateProject;
using FJU.Inventario.Application.Commands.UpdateUser;
using FJU.Inventario.Application.Common.EncriptedPassword;
using FJU.Inventario.Application.Common.ValidateCoordenate;
using FJU.Inventario.Application.Query.GetClosedMovimentInventory;
using FJU.Inventario.Application.Query.GetOpenedMovimentInventory;
using FJU.Inventario.Application.Query.GetProductById;
using FJU.Inventario.Application.Query.GetProducts;
using FJU.Inventario.Application.Query.GetProjectById;
using FJU.Inventario.Application.Query.GetProjects;
using FJU.Inventario.Application.Query.GetUserById;
using FJU.Inventario.Application.Query.GetUsers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FJU.Inventario.CrossCutting.DependenceInjection
{
    public static class CommandServiceCollectionExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddSingleton<IRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse>, ForgotPasswordCommand>();
            services.AddSingleton<IRequestHandler<LoginRequest, LoginResponse>, LoginCommand>();
            services.AddSingleton<IRequestHandler<CreateUserRequest, CreateUserResponse>, CreateUserCommand>();
            services.AddSingleton<IRequestHandler<UpdateUserRequest, UpdateUserResponse>, UpdateUserCommand>();
            services.AddSingleton<IRequestHandler<RemoveUserParams, RemoveUserResponse>, RemoveUserCommand>();
            services.AddSingleton<IRequestHandler<GetUserByIdParams, GetUserByIdResponse>, GetUserByIdQuery>();
            services.AddSingleton<IRequestHandler<GetUsersRequest, GetUsersResponse>, GetUsersQuery>();
            services.AddSingleton<IRequestHandler<CreateProjectRequest, CreateProjectResponse>, CreateProjectCommand>();
            services.AddSingleton<IRequestHandler<UpdateProjectRequest, UpdateProjectResponse>, UpdateProjectCommand>();
            services.AddSingleton<IRequestHandler<RemoveProjectParams, RemoveProjectResponse>, RemoveProjectCommand>();
            services.AddSingleton<IRequestHandler<GetProjectByIdParams, GetProjectByIdResponse>, GetProjectByIdQuery>();
            services.AddSingleton<IRequestHandler<GetProjectsRequest, GetProjectsResponse>, GetProjectsQuery>();
            services.AddSingleton<IRequestHandler<CreateProductRequest, CreateProductResponse>, CreateProductCommand>();
            services.AddSingleton<IRequestHandler<UpdateProductRequest, UpdateProductResponse>, UpdateProductCommand>();
            services.AddSingleton<IRequestHandler<RemoveProductParams, RemoveProductResponse>, RemoveProductCommand>();
            services.AddSingleton<IRequestHandler<GetProductByIdParams, GetProductByIdResponse>, GetProductByIdQuery>();
            services.AddSingleton<IRequestHandler<GetProductsRequest, GetProductsResponse>, GetProductsQuery>();
            services.AddSingleton<IRequestHandler<MoveInventoryRequest, MoveInventoryResponse>, MoveInventoryCommand>();
            services.AddSingleton<IRequestHandler<ReturnedInventoryRequest, ReturnedInventoryResponse>, ReturnedInventoryCommand>();
            services.AddSingleton<IRequestHandler<GetOpenedMovimentInventoryRequest, GetOpenedMovimentInventoryResponse>, GetOpenedMovimentInventoryQuery>();
            services.AddSingleton<IRequestHandler<GetClosedMovimentInventoryRequest, GetClosedMovimentInventoryResponse>, GetClosedMovimentInventoryQuery>();

            services.AddSingleton<IEncryptionPassword, EncryptionPassword>();
            services.AddSingleton<IVerifyUserCoordenate, VerifyUserCoordenate>();
            return services;
        }
    }
}
