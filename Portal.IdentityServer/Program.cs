using Portal.IdentityServer.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer()
    .AddClientStore<OrganizationClientStore>()
    .AddResourceStore<ResourceStore>()
    .AddDeveloperSigningCredential()
    .AddResourceOwnerValidator<UserValidator>()
    .AddProfileService<UserProfileService>()
    .AddJwtBearerClientAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseIdentityServer();

app.Run();
