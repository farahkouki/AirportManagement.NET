✈️ AirportManagement.NET
.NET
License

Une application moderne de gestion aéroportuaire développée avec .NET 6+, offrant des interfaces console et web pour administrer efficacement les opérations aéroportuaires.

🚀 Fonctionnalités clés
Gestion complète des vols (création, modification, suppression)

Gestion des passagers et réservations

Suivi des avions et ressources

Double interface: Console (CLI) et Web (ASP.NET Core)

Architecture modulaire (Domain, Application, Infrastructure, UI)

📦 Prérequis
.NET 6+ SDK

Visual Studio 2022 (avec workloads ASP.NET et .NET Desktop)

SQL Server (ou autre SGBD compatible)

⚡ Installation rapide
bash
git clone https://github.com/farahkouki/AirportManagement.NET.git
cd AirportManagement.NET
dotnet restore
Configurer la chaîne de connexion dans appsettings.json puis:

bash
dotnet ef database update
🖥️ Exécution
Interface Console:

bash
dotnet run --project AM.UI.Console
Interface Web:

bash
dotnet run --project AM.UI.Web
Ouvrez ensuite https://localhost:5001 dans votre navigateur.

🤝 Contribution
Les contributions sont les bienvenues!

Forkez le projet

Créez une branche (git checkout -b feature/amazing-feature)

Commitez vos changements (git commit -m 'Add amazing feature')

Poussez la branche (git push origin feature/amazing-feature)

Ouvrez une Pull Request

📄 Licence
Distribué sous licence MIT. Voir LICENSE pour plus d'informations.

📧 Contact
Farah Kouki - @farahkouki

💻 Projet développé avec passion | 🌍 Optimisez votre gestion aéroportuaire
