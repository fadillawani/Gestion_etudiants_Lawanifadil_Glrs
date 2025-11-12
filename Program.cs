using System;
using Microsoft.Extensions.DependencyInjection;
using SRC.Services;
using SRC.Services.Impl;      // <-- pour EtudiantService
using SRC.Repository;         // <-- pour l'interface IEtudiantRepository
using SRC.Repository.Impl;    // <-- pour EtudiantRepository
using View;

class Program
{
    static void Main(string[] args)
    {
        // Création du conteneur
        var serviceCollection = new ServiceCollection();

        // Enregistrement des services et repositories
        serviceCollection.AddSingleton<IEtudiantRepository, EtudiantRepository>();

        serviceCollection.AddSingleton<IEtudiantService, EtudiantsServices>();

        // Enregistrement de MainVue
        serviceCollection.AddTransient<MainVue>(sp =>
        {
            var etudiantsService = sp.GetRequiredService<IEtudiantService>();
            var etudiantRepository = sp.GetRequiredService<IEtudiantRepository>();
            return new MainVue(etudiantsService, etudiantRepository);
        });

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Démarrage du menu
        var mainVue = serviceProvider.GetRequiredService<MainVue>();
        mainVue.Demarrer();
    }
}
