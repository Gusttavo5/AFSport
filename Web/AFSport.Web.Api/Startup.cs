﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFSport.Web.Api.infra;
using AFSport.Web.Core.Interface.Repository;
using AFSport.Web.Core.Interface.Service;
using AFSport.Web.Core.Repository;
using AFSport.Web.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AFSport.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #region Dependencias
            #region Services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IEstadoService, EstadoService>();
            services.AddTransient<ICidadeService, CidadeService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IOperacaoService, OperacaoService>();
            services.AddTransient<IMovimentacaoService, MovimentacaoService>();
            services.AddTransient<IItemPedidoService, ItemPedidoService>();
            services.AddTransient<IEstoqueService, EstoqueService>();
            services.AddTransient<ICaixaService, CaixaService>();
            services.AddTransient<IDashboardService, DashboardService>();
            #endregion
            #region Repositorios
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<ICidadeRepository, CidadeRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IOperacaoRepository, OperacaoRepository>();
            services.AddTransient<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<IEstoqueRepository, EstoqueRepository>();
            services.AddTransient<ICaixaRepository, CaixaRepository>();
            services.AddTransient<IDashboardRepository, DashboardRepository>();
            #endregion
            #endregion
            services.AddAutoMapper();

            #region Autenticação JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("Token:SecurityKey").ToString())),
                    ClockSkew = TimeSpan.FromHours(24),
                    ValidIssuer = "AFSport.Web.Api",
                    ValidAudience = "Service-Mobile"
                };
            });
            #endregion

            #region CORS
            services.AddCors(options =>
            {
                options.AddPolicy("politica",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("politica");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}
