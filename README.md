The Great **MIC Cookbook** for Modern Applications!
===================

Vous vous lancez dans le vaste monde des technologies Microsoft mais ne savez pas par où commencer ? Ce projet pédagogique a pour objectif de vous montrer quelques pistes quant à la manière d'organiser votre code et assembler les pièces du puzzle que sont le BotFramework, Xamarin, ASP.NET MVC et les WebAPI, les Cognitive Services, et autres...

C'est en cuisinant qu'on devient cuisinier ! Alors plongez vos petits doigts encore propres dans ce code, piochez dans les ingrédients pour prendre ce qui vous intéresse, et sortez-nous du four votre premier projet fait main. :cake: :ok_hand:

[![](/doc/assets/the-great-mic-cookook.jpg)]()

> **Note:**

> - Projet en cours de développement. 
> - Clonez le dépôt et allez sur la branche develop pour tester les dernières fonctionnalités.
> - Les contributions et suggestions sont les bienvenues.
> - Vous pouvez [contacter les développeurs par mail](mailto:cookbook@mic-belgique.be).

----------

Technologies utilisées
-------------
- ASP.NET MVC5
- BotFramework
- Xamarin.Forms + PCL
- ...

Structure de la solution
-------------
Le projet vise à augmenter la quantité de code partagé. Dans la solution, vous trouverez les projets suivants (cliquez sur les liens pour obtenir plus d'informations sur chaque projet) :

- **MICCookBook.Web** : divisé en plusieurs couches allant de l'accès aux données à une couche plus business, qui est finalement exposée par des contrôleurs MVC pour l'interaction humaine et par des contrôleurs WebAPI pour l'interaction machine-to-machine. 
- **MICCookBook.SDK** : une librairie facilitant la communication avec la WebAPI en gérant les aspects d'identification et de sérialisation/désérialisation.
- **MICCookBook.Bot** : un client de type Bot pour permettre d'interagir avec notre application web depuis différents channels tels que Facebook ou Skype. 
- **MICCookBook.XFCore** : le coeur de nos applications Xamarin.Forms, contenant les interfaces et la logique réutilisable sur chaque plateforme.
- **MICCookBook.Droid** : le projet Android.
- **MICCookBook.iOS** : le projet iOS.
- **MICCookBook.UWP** : le projet Windows.

Roadmap
-------------
Dans l'optique de montrer toute une série de chouettes fonctionnalités à implémenter dans vos projets, nous pensons intégrer les points suivants dans un délai indéterminé :

* :white_check_mark: Identification OAuth
* :white_check_mark: BotFramework Carousel
* :white_check_mark: Behaviors en Xamarin.Forms
* Éditeur Markdown pour la description des recettes
* Identification Facebook
* ...

Auteurs
-------------
* [Renaud Dumont](http://twitter.com/dumontrenaud)
* [Fred Carbonnelle](http://twitter.com/fcarbonnelle)
* [Thomas D'Hollander](http://twitter.com/tdhollander)
