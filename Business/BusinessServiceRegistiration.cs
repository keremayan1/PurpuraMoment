using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class BusinessServiceRegistiration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {



            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);



            services.AddScoped<IEtkinlikIzinService, EtkinlikIzinManager>();
            services.AddScoped<IEtkinlikService, EtkinlikManager>();
            services.AddScoped<IKullaniciService, KullaniciManager>();
            services.AddScoped<IMedyaService, MedyaManager>();
            services.AddScoped<IQRKodService, QRKodManager>();
            services.AddScoped<ISalonBolumService, SalonBolumManager>();
            services.AddScoped<ISalonPlanService, SalonPlanManager>();
            services.AddScoped<ISalonService, SalonManager>();
            //services.AddScoped<ITokenHelper, JwtHelper>();

            return services;
        }
    }
}
