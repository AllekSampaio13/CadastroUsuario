using CadastroUsuario;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
builder.Services.AddSwaggerGen();
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();