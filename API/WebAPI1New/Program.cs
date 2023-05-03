namespace WebAPI1New
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //cors default for all sites
            builder.Services.AddCors(c =>
            {
                c.AddDefaultPolicy(defpolicy => defpolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            //cors for a particular site
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("PolicyNameHere", options => options.WithOrigins("http://localhost:12345").AllowAnyHeader().AllowAnyMethod());
            //})

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #region cors
            //allow cors
            app.UseCors(); //uses def policy
            //app.UseCors("PolicyNameHere"); //uses specific policy
            #endregion
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}