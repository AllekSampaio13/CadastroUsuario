using Cadastro.Infra.Data.EF.Extensions;
using Cadastro.Infra.IoC;

namespace CadastroUsuario;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        //  services.AddSwaggerConfiguration();
        
        services
            .AddEFConfiguration(Configuration.GetConnectionString("connection"))
            .ConfigureDependencies()
            .ConfigureApplicationServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


    }
}
