# URLValidation

Objectif:

L'objectif de cette application est de vérifier la disponibilité de l'url fournie sur le rèseau internet, en sécurisant la page par Recaptcha (Un plugin de google) afin de limiter l'utilisation par des robots.

Prérequis:

Installation de visual studio afin d'ouvrir les deux applications.

Mode d'utilisation:

1 étape :

Télécharger les deux applications URL.Validation.API et URL.Validation.Client

2 étape :

Ouvrir les deux applications.

3 étape :

Accéder au site https://www.google.com/recaptcha/admin et enregistrer un site (dans notre cas, puisqu'on teste en localhost. Pour le libellé on met : localhost et pour le domaine, on met : localhost. Puis on clique sur enregistrer, comme vous voyez une nouvelle page s'ouvre.

On récupére la clé public ainsi que la clé privée.

4 étape: 

On ouvre l'application URL.Validation.Client, dans le fichier web.config du projet URL.Validation.Client, on replace la valeur de la clé "reCaptcha.Key.Secret" par la clé privée fournie par google.

Puis on ouvre le fichier /Scripts/App/url.app.js, et on replace la valeur de la propriété $scope.publicKey par la clé public fournie par google.

5 étape:

On lance les deux applications URL.Validation.API et URL.Validation.Client.

6 étape:

Enfin, saisir votre url et cocher la case à cocher de Catpcha et enfin valider votre url en cliquant sur le bouton "valider"
