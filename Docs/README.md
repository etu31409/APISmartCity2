# Comment lancer notre API une fois que vous avez cloné le projet sur votre machine ?

Nous avons utilisé la version 2.1.500 de dotnet Core (dotnet -version), si vous ne l'avez pas, vous pouvez la télécharger à cette [adresse](https://dotnet.microsoft.com/download)

Nous vous conseillons d'utiliser l'environement Visual Studio Code.

Une fois visual studio code lancé, visual studio code vous proposera d'effetuer un *restore*
accepter (si il ne vous le propose pas vous pouver lancer manuellement la commande dans le terminal *dotnet restore*(deplacez-vous dans le dossier Src))

Cette commande permet de mettre à jour les références notamment.

Pour compiler le projet utiliser la commande dotnet *dotnet build*

Pour lancer le projet utiliser la commande dotnet *dotnet run*

## Comment cryptons nous les mots de passe ?
 Nous utilisons BCrypt [https://github.com/BcryptNet/bcrypt.net](https://github.com/BcryptNet/bcrypt.net)